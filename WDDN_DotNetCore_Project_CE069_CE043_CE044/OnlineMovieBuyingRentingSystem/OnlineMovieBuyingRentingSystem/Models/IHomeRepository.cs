using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IHomeRepository
    {
        IEnumerable<Movie> GetMovies();
        IEnumerable<WebSeries> GetWebSeriess();
        Movie GetMovie(int Id);
        WebSeries GetWebSeries(int Id);
        IEnumerable<Cast> GetCast(int MovieId);
        IEnumerable<WebSeriesCast> GetWebSeriesCast(int WebSeriesId);
        IEnumerable<MovieImage> GetImages(int MovieId);
        IEnumerable<WebSeriesImage> GetWebSeriesImages(int WebSeriesId);
        IEnumerable<Genre> GetGenres();
        IEnumerable<Actor> GetActors();
        bool MoviePurchased(int Id,string useremail);
        bool MovieRented(int Id, string useremail);
        bool WebSeriesPurchased(int Id, string useremail);
        bool WebSeriesRented(int Id, string useremail);
        MoviePurchase AddMoviePurchase(MoviePurchase MoviePurchase);
        MovieRent AddMovieRent(MovieRent MovieRent);
        WebSeriesPurchase AddWebSeriesPurchase(WebSeriesPurchase WebSeriesPurchase);
        WebSeriesRent AddWebSeriesRent(WebSeriesRent WebSeriesRent);
    }
}
