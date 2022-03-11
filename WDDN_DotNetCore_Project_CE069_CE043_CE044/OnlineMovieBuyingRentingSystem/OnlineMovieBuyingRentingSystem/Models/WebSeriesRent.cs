using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class WebSeriesRent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WebSeriesId { get; set; }
        public WebSeries WebSeries { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}
