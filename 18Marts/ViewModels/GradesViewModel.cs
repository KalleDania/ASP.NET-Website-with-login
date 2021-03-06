﻿using _18Marts.CSClasses;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Marts.ViewModels
{
    public class GradesViewModel
    {
        private static AImage grades;
        public static AImage Grades
        {
            get
            {
                if (grades == null)
                {
                    foreach (var item in FileList)
                    {
                        if (item.FileName.Contains("Grades"))
                        {
                            grades = item;
                            break;
                        }
                    }
                }
                return grades;
            }
        }

        private static AImage references; 
        public static AImage References
        {
            get
            {
                if (references == null)
                {
                    foreach (var item in FileList)
                    {
                        if (item.FileName.Contains("References"))
                        {
                            references = item;
                            break;
                        }
                    }
                }
                return references;
            }
        }
     

        private static List<AImage> fileList;
        public static List<AImage> FileList
        {
            get
            {
                if (fileList == null)
                {
                    fileList = new List<AImage>();

                    //https://social.msdn.microsoft.com/Forums/en-US/590b9b59-4130-45cf-850b-39f38e9c063c/executing-code-only-after-async-method-is-completed?forum=winappswithcsharp
                    MainAsync();

                }
                while (!finished)
                {

                }
                return fileList;
            }
        }

        static bool finished = false;

        //https://stackoverflow.com/questions/45872496/passing-data-from-view-to-controller-asp-net-core-razor-pages
        static async Task MainAsync(/*string[] args*/)
        {

            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse("account info here");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            /// Creates if doesnt exist
            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("myimages");

            ListBlobsSegmentedInFlatListing(container);


            Debug.WriteLine($"Your container with the name:{"myimages"} does not exist!!!");

            Debug.WriteLine("press any key to exit...");
            //Console.ReadLine();
        }
        async public static Task ListBlobsSegmentedInFlatListing(CloudBlobContainer container)
        {

            //List blobs to the console window, with paging.
            Debug.WriteLine("List blobs in pages:");

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

                if (resultSegment.Results.Count<IListBlobItem>() > 0) { Debug.WriteLine("Page {0}:", ++i); }

                foreach (var blobItem in resultSegment.Results)
                {
                    Debug.WriteLine("\t{0}", blobItem.StorageUri.PrimaryUri);

                    StringBuilder sb = new StringBuilder().Append(blobItem.StorageUri.PrimaryUri.ToString()).Replace("asset url here", "");
                    string itemName = sb.ToString();
                    string azureUrl = blobItem.StorageUri.PrimaryUri.ToString();

                    fileList.Add(new AImage(itemName, azureUrl));
                }

                finished = true;
                Debug.WriteLine("");



                //Get the continuation token.
                continuationToken = resultSegment.ContinuationToken;
            }
            while (continuationToken != null);

        }

    }
}
