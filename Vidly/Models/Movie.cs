﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
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
        [Range(0,1000)]
        public short NumberInStock { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

    }
}