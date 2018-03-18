using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Marts.CSClasses
{
     public class Manager_Blobs
{
    private static List<AImage> fileList;
    public static List<AImage> FileList
    {
        get
        {
            if (fileList == null)
            {
                MainAsync();
            }
            return fileList;
        }
    }

    static async Task MainAsync(/*string[] args*/)
    {
        var fileList = new List<AImage>();

        //.. code to connect to the azure account and container
        // Parse the connection string and return a reference to the storage account.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        string containerName = "myimages";
        /// Creates if doesnt exist
        // Retrieve a reference to a container.
        CloudBlobContainer container = blobClient.GetContainerReference(containerName);


        //if (await container.ExistsAsync())
        //{
        /*    await*/
        ListBlobsSegmentedInFlatListing(container, containerName);
        //}

        //else
        //Console.WriteLine($"Your container with the name:{"myimages"} does not exist!!!");

        //Console.WriteLine("press any key to exit...");
        //Console.ReadLine();
    }

    async public static Task ListBlobsSegmentedInFlatListing(CloudBlobContainer container, string _containerName)
    {
        //List blobs to the console window, with paging.
        Console.WriteLine("List blobs in pages:");

        int i = 0;
        BlobContinuationToken continuationToken = null;
        BlobResultSegment resultSegment = null;

        //Call ListBlobsSegmentedAsync and enumerate the result segment returned, while the continuation token is non-null.
        //When the continuation token is null, the last page has been returned and execution can exit the loop.
        do
        {
            //This overload allows control of the page size. You can return all remaining results by passing null for the maxResults parameter,
            //or by calling a different overload.
            resultSegment = await container.ListBlobsSegmentedAsync("", true, BlobListingDetails.All, 10, continuationToken, null, null);
            if (resultSegment.Results.Count<IListBlobItem>() > 0)
            {
                //Console.WriteLine("Page {0}:", ++i);
            }
            foreach (var blobItem in resultSegment.Results)
            {
                Console.WriteLine("\t{0}", blobItem.StorageUri.PrimaryUri);

                // Get clean itemname.
                StringBuilder itemName = new StringBuilder();
                itemName.Append(blobItem.StorageUri.PrimaryUri.ToString().Replace("https://iamkaspernielsenstorage.blob.core.windows.net/" + _containerName, ""));
                string itemAzureUrl = blobItem.StorageUri.PrimaryUri.ToString();
                fileList.Add(new AImage(itemName.ToString(), itemAzureUrl));
            }
            //Console.WriteLine();

            //Get the continuation token.
            continuationToken = resultSegment.ContinuationToken;
        }
        while (continuationToken != null);
    }

}
}
