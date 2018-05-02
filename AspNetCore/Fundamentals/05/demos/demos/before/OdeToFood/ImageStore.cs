using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class ImageStore
    {
        private readonly CloudBlobClient _client;
        private readonly Uri _baseUri = new Uri("https://pscourse.blob.core.windows.net/");

        public ImageStore()
        {
            _client = new CloudBlobClient(_baseUri,
                new StorageCredentials("pscourse", "RimgkGqJ0cplkHdNYkP6JPXqgiTyExOAxC8pETxexz8Wpm71Lsn6l38pbZSQi4DqydJ/faFXox8Knh/yTtvVXw=="));
        }

        public Uri UriFor(string id)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.Now.AddMinutes(-15),
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(30)
            };
            CloudBlobContainer container = _client.GetContainerReference("images");
            CloudBlob blob = container.GetBlockBlobReference(id);
            string sasToken = blob.GetSharedAccessSignature(sasPolicy);

            return new Uri(_baseUri, $"/images/{id}{sasToken}");
        }

        public async Task<string> SaveImageAsync(Stream stream)
        {
            string id = Guid.NewGuid().ToString();
            CloudBlobContainer container = _client.GetContainerReference("images");
            CloudBlockBlob blob = container.GetBlockBlobReference(id);
            await blob.UploadFromStreamAsync(stream);
            return id;
        }
    }
}