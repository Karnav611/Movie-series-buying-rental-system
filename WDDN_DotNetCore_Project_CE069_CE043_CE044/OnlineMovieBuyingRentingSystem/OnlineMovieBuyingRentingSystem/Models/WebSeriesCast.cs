using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class WebSeriesCast
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select WebSeries")]
        public int WebSeriesId { get; set; }
        public WebSeries WebSeries { get; set; }

        [Required(ErrorMessage = "Please Enter Character Name")]
        public string CharacterName { get; set; }

        [Required(ErrorMessage = "Please Select Actor")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
