using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IWebSeriesRepository
    {
        WebSeries GetWebSeries(int Id);
        WebSeries AddWebSeries(WebSeries WebSeries);
        WebSeries UpdateWebSeries(WebSeries WebSeries);
        WebSeries DeleteWebSeries(int Id);
        IEnumerable<WebSeries> GetAllWebSeriess();
        IEnumerable<WebSeries> GetWebSeriessByGenre(int GenreId);
        IEnumerable<Genre> GetGenres();
        IEnumerable<WebSeries> GetHomeWebSeriess();
        IEnumerable<WebSeriesCast> GetWebSeriesCast(int Id);
        IEnumerable<Actor> GetActors();
        WebSeriesPurchase AddWebSeriesPurchase(WebSeriesPurchase WebSeriesPurchase);
        WebSeriesRent AddWebSeriesRent(WebSeriesRent WebSeriesRent);
    }
}
