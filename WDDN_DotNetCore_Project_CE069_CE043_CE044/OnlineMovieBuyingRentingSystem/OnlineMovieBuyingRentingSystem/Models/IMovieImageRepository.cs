using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IMovieImageRepository
    {
        MovieImage GetImage(int Id);
        IEnumerable<MovieImage> GetMovieImages(int MovieId);
        MovieImage AddMovieImage(MovieImage IMovieImageRepository);
        MovieImage UpdateMovieImage(MovieImage IMovieImageRepository);
        MovieImage DeleteMovieImage(int Id);
        IEnumerable<MovieImage> GetAllImages();
        IEnumerable<Movie> GetMovies();
    }
}
