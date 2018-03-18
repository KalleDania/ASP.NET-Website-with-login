using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _18Marts.Entities
{

    public class Video
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(15)]
        [DataType(DataType.Password)]
        public string Title { get; set; }
        [Display(Name = "Film Genre")]
        public Genres Genre { get; set; }
    }
}
