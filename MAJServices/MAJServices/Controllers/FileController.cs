using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using MAJServices.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class FileController : Controller
    {
        private IFileInfoRepository _fileInfoRepository;
        public FileController(IFileInfoRepository fileInfoRepository)
        {
            _fileInfoRepository = fileInfoRepository;
        }
        
//---------------------------Upload post's files into blob storage------------------------------------// 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPost("{iduser}/post/{idPost}/files")]
        public async Task<IActionResult> SavePostsFile(string idUser,int idPost,IEnumerable<IFormFile> files)
        {
            var userId = User.FindFirst("username").Value;
            if (!_fileInfoRepository.UserExists(userId))
            {
                return NotFound("Usuario Deshabilitado");
            }
            var postEntity = _fileInfoRepository.RetrievePost(idPost);
            if (postEntity == null )
            {
                return NotFound();
            }
            if (files == null || !files.Any()){
                return BadRequest("files should not be empty");
            }
            _fileInfoRepository.ClearPreviousFiles(idPost);
            
            //set the connections string
            string storageConnectionString = Environment.GetEnvironmentVariable("AzureBlobStorage");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            
            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();

            // Create a reference to the container 
            CloudBlobContainer BlobContainer = BlobClient.GetContainerReference("postsfiles-"+idUser+"-"+idPost);
            bool containerExists = await BlobContainer.ExistsAsync();
            if (!containerExists)
            {
                await BlobContainer.CreateAsync();

                // Set the permissions so the blobs are public. 
                BlobContainerPermissions permissions = new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                await BlobContainer.SetPermissionsAsync(permissions);
            }

            foreach (IFormFile file in files){
                
                //Get a reference to the blob
                CloudBlockBlob blockBlob = BlobContainer.GetBlockBlobReference(file.FileName.Trim());
                
                //The default is application/octet-stream, which triggers a download in most browsers
                blockBlob.Properties.ContentType = file.ContentType;
                
                //Create or overwrite the blob with the contents of a local file
                using (var filestream = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(filestream);
                }
                var fileEntity = new FilePath{
                    FileName = blockBlob.Name.Trim(),
                    Path = blockBlob.Uri.ToString(),
                    PostId = idPost,
                };
                var fileDto = Mapper.Map<FilePathDto>(fileEntity);
                _fileInfoRepository.AddFileToPost(fileEntity);
            }
            
            if (!_fileInfoRepository.SaveFile())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return CreatedAtRoute("GetUserPost", new { idUser, idPost },Mapper.Map<PostWithoutUserDto>(postEntity));
        }

        //---------------------------Upload User's Profile Image into blob storage------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPost("{iduser}/Image")]
        public async Task<IActionResult> SaveProfileImage(string iduser,IFormFile file)
        {
            var userId = User.FindFirst("username").Value;
            if (!_fileInfoRepository.UserExists(userId))
            {
                return NotFound("Usuario Deshabilitado");
            }
            var userEntity = _fileInfoRepository.RetrieveUser(iduser);
            if(userEntity == null)
            {
                return NotFound();
            }
            if (file == null && (file.ContentType!= "image/png" || file.ContentType != "image/jpeg") )
            {
                return BadRequest("files should not be empty or png/jpg/jpeg format");
            }

            //set the connections string
            string storageConnectionString = Environment.GetEnvironmentVariable("AzureBlobStorage");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();

            // Create a reference to the container 
            CloudBlobContainer BlobContainer = BlobClient.GetContainerReference("profilephoto-"+iduser);
            bool containerExists = await BlobContainer.ExistsAsync();
            if (!containerExists){
                await BlobContainer.CreateAsync();

                // Set the permissions so the blobs are public. 
                BlobContainerPermissions permissions = new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                await BlobContainer.SetPermissionsAsync(permissions);
            }

            //Get a reference to the blob
            CloudBlockBlob blockBlob = BlobContainer.GetBlockBlobReference(file.FileName.Trim());

            //The default is application/octet-stream, which triggers a download in most browsers
            blockBlob.Properties.ContentType = file.ContentType;

            //Create or overwrite the blob with the contents of a local file
            using (var filestream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(filestream);
            }
            userEntity.UserImageUrl = blockBlob.Uri.ToString();
            if (!_fileInfoRepository.SaveFile())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return CreatedAtRoute("GetUser", new { id = userEntity.Id }, Mapper.Map<UserWithoutPostsDto>(userEntity));
        }
    }
}
