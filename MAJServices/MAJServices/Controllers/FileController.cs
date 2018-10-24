using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
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
        private IPostInfoRepository _postInfoRepository;
        public FileController(IPostInfoRepository postInfoRepository)
        {
            _postInfoRepository = postInfoRepository;
        }
        
//---------------------------Upload post's files into blob storage------------------------------------// 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPost("{iduser}/post/{idPost}/files")]
        public async Task<IActionResult> SavePostsFile(string idUser,int idPost,IEnumerable<IFormFile> files)
        {
            if(!_postInfoRepository.PostExist(idUser, idPost))
            {
                return NotFound();
            }
            var postEntity = _postInfoRepository.GetUserPost(idUser, idPost);
            if (files == null || !files.Any()){
                return BadRequest("files should not be empty");
            }

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

            List<FilePathDto> addedFiles = new List<FilePathDto>();

            foreach(IFormFile file in files){

                //Get a reference to the blob
                CloudBlockBlob blockBlob = BlobContainer.GetBlockBlobReference(file.FileName);

                //Create or overwrite the blob with the contents of a local file
                using (var filestream = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(filestream);
                }
                var fileEntity = new FilePath{
                    FileName = blockBlob.Name,
                    Path = blockBlob.Uri.ToString(),
                    PostId = idPost,
                };
                var fileDto = Mapper.Map<FilePathDto>(fileEntity);
                addedFiles.Add(fileDto);
                postEntity.FilePaths.Add(fileEntity);
            }
            
            if (!_postInfoRepository.SavePost())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return CreatedAtRoute("GetUserPost", new { idUser = idUser, idPost = idPost },Mapper.Map<PostWithoutUserDto>(postEntity));
        }

        //---------------------------Upload User's Profile Image into blob storage------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPost("{iduser}/Image")]
        public async Task<IActionResult> SaveProfileImage(string iduser,IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("files should not be empty");
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
            CloudBlockBlob blockBlob = BlobContainer.GetBlockBlobReference(file.FileName);

            //Create or overwrite the blob with the contents of a local file
            using (var filestream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(filestream);
            }
            return Json(new
            {
                name = blockBlob.Name,
                uri = blockBlob.Uri,
                size = blockBlob.Properties.Length
            });
        }
    }
}
