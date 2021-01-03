using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime Added { get; set; }

        [Required]
        [Range(1, 1000)]
        public short NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}