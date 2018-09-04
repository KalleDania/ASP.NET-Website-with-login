using _18Marts.CSClasses;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Marts.ViewModels
{
    public class PrivateViewModel
    {
        static readonly PrivateViewModel instance = new PrivateViewModel();
        public static PrivateViewModel Instance
        {
            get
            {
                return instance;
            }
        }
        private PrivateViewModel()
        {
            currentItem = dropDownItemList[0];
        }

        public int ItemId { get; set; }


        public List<APrivateDropDownItem> dropDownItemList = new List<APrivateDropDownItem>()
                 {
                 new APrivateDropDownItem { Category="Design pattern",Name= "Design pattern: " + "Singleton", Description ="Singletons ensures that there are only one instance of a class", },
                 new APrivateDropDownItem { Category="Design pattern",Name= "Design pattern: " + "Builder"},
                 new APrivateDropDownItem { Category="Design pattern",Name= "Design pattern: " + "Factory"},
                 new APrivateDropDownItem { Category="Design pattern",Name= "Design pattern: " + "Observer"},
                 new APrivateDropDownItem { Category="Design pattern",Name= "Design pattern: " + "Decorator"},
                 new APrivateDropDownItem { Category="Design pattern",Name= "Design pattern: " + "MVC"},
                 new APrivateDropDownItem { Category="Syntax",Name= "Syntax: " + "Delegate"},
                 new APrivateDropDownItem { Category="Syntax",Name= "Syntax: " + "Generic metode"},
                 new APrivateDropDownItem { Category="Syntax",Name= "Syntax: " + "Lamda"},
                 new APrivateDropDownItem { Category="Cyber security",Name= "Cyber security: " + "Phishing"},
                 new APrivateDropDownItem { Category="Cyber security",Name= "Cyber security: " + "Encryptions"},
                 new APrivateDropDownItem { Category="Cyber security",Name= "Cyber security: " + "Password Fetching USB"}
                 };


        public APrivateDropDownItem currentItem;
    }
}

