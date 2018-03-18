using Eksempel_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eksempel_1.ViewModels
{
    public class VideoEditViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(15)]
        public string Title { get; set; }
        public Genres Genre { get; set; }
    }
}
