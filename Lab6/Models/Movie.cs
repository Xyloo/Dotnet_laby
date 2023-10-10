﻿using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytuł może mieć maksymalnie 50 znaków")]
        public string Title { get; set; }

        [UIHint("LongText")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }

        [UIHint("Stars")]
        [Range(1, 5, ErrorMessage = "Ocena musi być liczbą z zakresu 1-5")]
        public int Rating { get; set;}

        [UIHint("TrailerHyperlink")]
        public string? TrailerLink { get; set; }

        public Genre Genre { get; set; }
    }
}
