using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class FileController : Controller
    {
//---------------------------Upload post's files into blob storage------------------------------------// 
        [HttpPost("{iduser}/post/{idPost}/files")]
        public async Task<IActionResult> SavePostsFile(string iduser,string idpost,IEnumerable<IFormFile> files)
        {
            if(files == null || !files.Any()){
                return BadRequest("files should not be empty");
            }

            //set the connections string
            string storageConnectionString = Environment.GetEnvironmentVariable("AzureBlobStorage");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            
            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();

            // Create a reference to the container 
            CloudBlobContainer BlobContainer = BlobClient.GetContainerReference("postsfiles-"+iduser+"-"+idpost);
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

            List<object> addedFiles = new List<object>();

            foreach(IFormFile file in files){

                //Get a reference to the blob
                CloudBlockBlob blockBlob = BlobContainer.GetBlockBlobReference(file.FileName);

                //Create or overwrite the blob with the contents of a local file
                using (var filestream = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(filestream);
                }
                addedFiles.Add(new
                {
                    name = blockBlob.Name,
                    uri = blockBlob.Uri,
                    size = blockBlob.Properties.Length
                });
            }
            return Json(addedFiles);
        }

//---------------------------Upload User's Profile Image into blob storage------------------------------------//
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
