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
    public class HomeViewModel
    {
        private static AImage meme;
        public static AImage Meme
        {
            get
            {
                if (meme == null)
                {

                    foreach (var item in HomeViewModel.FileList)
                    {
                        if (item.FileName.Contains("TheElon"))
                        {
                            meme = item;
                            break;
                        }
                    }
                }
                return me;
            }
        }



        private static AImage me;
        public static AImage Me
        {
            get
            {
                if (me == null)
                {
                    foreach (var item in FileList)
                    {
                        if (item.FileName.Contains("MeSortHvid"))
                        {
                            me = item;
                            break;
                        }
                    }
                }
                return me;
            }
        }

        public static int CurrentImageSize = 20;
        public static int DefaultImageSize = 20;

        private string firstFileName;
        public string FirstFileName
        {
            get
            {
                if (firstFileName == null)
                {
                    firstFileName = FileList[0].FileName;
                };
                return firstFileName;
            }
        }
        private string firstAzureUrl;
        public string FirstAzureUrl
        {
            get
            {
                if (firstAzureUrl == null)
                {
                    firstAzureUrl = FileList[0].AzureUrl;
                };
                return firstAzureUrl;
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
                    //fileList.Add(new AImage("test name", "test url"));

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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=iamkaspernielsenstorage;AccountKey=zcIvxM7HfrOMhDFnXTzLOUEwztBVPgTUuMrzMRfUgQ1L53Hka2Ye4f6YCwvpFYJqaurUbl4HoOXhS1njlWZw0A==");
            Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            /// Creates if doesnt exist
            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("myimages");



            //if (await container.ExistsAsync())
            //{
            /*    await*/
            ListBlobsSegmentedInFlatListing(container);
            //}

            //else



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
                //fileList[0] = new AImage("new test name", " færdig nået new test url");

                foreach (var blobItem in resultSegment.Results)
                {
                    Debug.WriteLine("\t{0}", blobItem.StorageUri.PrimaryUri);

                    StringBuilder sb = new StringBuilder().Append(blobItem.StorageUri.PrimaryUri.ToString()).Replace("https://iamkaspernielsenstorage.blob.core.windows.net/myimages/", "");
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



        //public static DateTime currentTime = DateTime.Now;
        //public static DateTime NowTime = DateTime.Now;

        //public static string StartBackgroundThread
        //{
        //    get
        //    {
        //        var backgroundTask = Task.Run(() => Update());

        //        return null;
        //    }
        //}




    }
}
