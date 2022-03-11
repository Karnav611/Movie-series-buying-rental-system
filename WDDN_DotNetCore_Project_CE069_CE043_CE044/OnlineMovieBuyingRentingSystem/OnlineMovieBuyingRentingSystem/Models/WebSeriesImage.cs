using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class WebSeriesImage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select WebSeries")]
        public int WebSeriesId { get; set; }
        public WebSeries WebSeries { get; set; }

        public string Path { get; set; }
        [NotMapped]
        public IFormFile WebSeriesImageFile { get; set; }
    }
}
