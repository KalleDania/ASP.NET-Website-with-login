using Eksempel_1.ViewModels;
using Eksempel_1.Models;
using System.ComponentModel.DataAnnotations;

namespace Eksempel_1.Entities
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
