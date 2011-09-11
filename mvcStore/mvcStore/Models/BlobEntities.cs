using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace mvcStore.Models
{
    public class BlobEntities
    {
        public static CloudBlobClient blobStorage;
        private static bool storageInitialized = false;
        private static object gate = new Object();

        public BlobEntities()
        {
            if (storageInitialized)
            {
                return;
            }

            lock (gate)
            {
                if (storageInitialized)
                {
                    return;
                }
                    // read account configuration settings
                    var storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");

                    // create blob container for images
                    blobStorage = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobStorage.GetContainerReference("productimages");
                    container.CreateIfNotExist();

                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);

                storageInitialized = true;
            }
        }

        public string Upload(HttpPostedFileBase hpfb)
        {
            // upload the image to blob storage
            string uniqueBlobName = string.Format("productimages/image_{0}{1}", Guid.NewGuid().ToString(), System.IO.Path.GetExtension(hpfb.FileName));
            CloudBlockBlob blob = blobStorage.GetBlockBlobReference(uniqueBlobName);
            blob.Properties.ContentType = hpfb.ContentType;
            blob.UploadFromStream(hpfb.InputStream);
            System.Diagnostics.Trace.TraceInformation("Uploaded image '{0}' to blob storage as '{1}'", hpfb.FileName, blob.Uri.AbsoluteUri);
            return blob.Uri.AbsoluteUri;
        }
    }
}