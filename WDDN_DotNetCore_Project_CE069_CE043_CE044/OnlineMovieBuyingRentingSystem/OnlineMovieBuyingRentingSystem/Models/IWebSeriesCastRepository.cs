using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IWebSeriesCastRepository
    {
        WebSeriesCast AddWebSeriesCast(WebSeriesCast WebSeriesCast);
        WebSeriesCast UpdateWebSeriesCast(WebSeriesCast WebSeriesCast);
        WebSeriesCast DeleteWebSeriesCast(int Id);
        WebSeriesCast GetWebSeriesCast(int Id);
        IEnumerable<WebSeriesCast> GetAllWebSeriesCast();
        IEnumerable<WebSeriesCast> GetWebSeriessCast(int WebSeriesId);
        IEnumerable<WebSeries> GetWebSeriess();
        IEnumerable<Actor> GetActors();
    }
}
