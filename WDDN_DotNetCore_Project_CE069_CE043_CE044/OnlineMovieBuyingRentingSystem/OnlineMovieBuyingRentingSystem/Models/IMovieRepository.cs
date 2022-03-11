using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IMovieRepository
    {
        Movie GetMovie(int Id);
        Movie AddMovie(Movie Movie);
        Movie UpdateMovie(Movie Movie);
        Movie DeleteMovie(int Id);
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Movie> GetMoviesByGenre(int GenreId);
        IEnumerable<Genre> GetGenres();
        IEnumerable<Movie> GetHomeMovies();
        IEnumerable<Cast> GetCast(int Id);
        IEnumerable<Actor> GetActors();
        MoviePurchase AddMoviePurchase(MoviePurchase MoviePurchase);
        MovieRent AddMovieRent(MovieRent MovieRent);
    }
}
