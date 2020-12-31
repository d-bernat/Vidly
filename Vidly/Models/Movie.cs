using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Migrations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public DateTime Added { get; set; }
        
        [Required]
        [Range(1,1000)]
        [Display(Name = "Number In Stock")]
        public short NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}