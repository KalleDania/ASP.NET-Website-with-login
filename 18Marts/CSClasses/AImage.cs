using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18Marts.CSClasses
{
    public class AImage
    {
        public string FileName { get; set; }
        public string AzureUrl { get; set; }

        public AImage(string _fileName, string _azureUrl)
        {
            FileName = _fileName;
            AzureUrl = _azureUrl;
        }
    }
}
