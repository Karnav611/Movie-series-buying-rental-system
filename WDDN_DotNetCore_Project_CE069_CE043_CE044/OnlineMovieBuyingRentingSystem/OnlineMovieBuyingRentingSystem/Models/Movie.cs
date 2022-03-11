using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please Enter IMDB Rating")]
        public string IMDBRating { get; set; }

        public string Poster { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Trailer Link")]
        public string TrailerLink { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Rent Link")]
        public string RentLink { get; set; }

        public string MovieFilePath { get; set; }
        [NotMapped]
        public IFormFile MovieFile { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Purchase Price")]
        public int PurchasePrice { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Rent Price")]
        public string RentPrice { get; set; }
        public ICollection<Cast> Cast { get; set; }
    }
}
