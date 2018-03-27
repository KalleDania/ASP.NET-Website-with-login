using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _18Marts.ViewModels
{
    public class ContactViewModel
    {
        public string InputAccessRequestWho { get; set; }
        public string InputAccessRequestMail { get; set; }
        public string InputFeedback { get; set; }
    }
}
