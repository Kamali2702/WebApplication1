using System.ComponentModel.DataAnnotations;

namespace MovieCatalogueAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Language { get; set; }

        [Range(1, 1000)]
        public int DurationMinutes { get; set; }

        [Range(1888, 2100)]
        public int ReleaseYear { get; set; }
    }
}