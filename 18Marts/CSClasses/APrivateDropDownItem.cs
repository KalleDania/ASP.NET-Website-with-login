using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18Marts.CSClasses
{
    public class APrivateDropDownItem
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<string> VideoUrls { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
