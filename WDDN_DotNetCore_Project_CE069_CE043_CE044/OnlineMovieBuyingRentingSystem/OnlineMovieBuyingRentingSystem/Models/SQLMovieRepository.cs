using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLMovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext context;
        public SQLMovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Movie IMovieRepository.GetMovie(int Id)
        {
            //return context.Movies.Find(Id);
            return context.Movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == Id);
        }
        Movie IMovieRepository.AddMovie(Movie Movie)
        {
            context.Movies.Add(Movie);
            context.SaveChanges();
            return Movie;
        }
        Movie IMovieRepository.UpdateMovie(Movie MovieChanges)
        {
            Movie movie = context.Movies.Find(MovieChanges.Id);
            movie.Title = MovieChanges.Title;
            movie.Description = MovieChanges.Description;
            movie.Genre = MovieChanges.Genre;
            movie.IMDBRating = MovieChanges.IMDBRating;
            movie.Poster = MovieChanges.Poster;
            movie.TrailerLink = MovieChanges.TrailerLink;
            movie.RentLink = MovieChanges.RentLink;
            movie.MovieFilePath = MovieChanges.MovieFilePath;
            movie.PurchasePrice = MovieChanges.PurchasePrice;
            movie.RentPrice = MovieChanges.RentPrice;
            context.SaveChanges();
            return movie;
        }
        Movie IMovieRepository.DeleteMovie(int Id)
        {
            Movie movie = context.Movies.Find(Id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }
        IEnumerable<Movie> IMovieRepository.GetAllMovies()
        {
            //IEnumerable<Movie> temp = context.Movies.Include(m => m.Genre);
            return context.Movies.Include(m => m.Genre);
        }
        IEnumerable<Movie> IMovieRepository.GetHomeMovies()
        {
            //IEnumerable<Movie> temp = context.Movies.Include(m => m.Genre);
            return context.Movies.Include(m => m.Genre).Take(2);
        }
        IEnumerable<Movie> IMovieRepository.GetMoviesByGenre(int GenreId)
        {
            return context.Movies.Include(m => m.Genre).Where(m => m.GenreId == GenreId).ToList();
        }
        IEnumerable<Genre> IMovieRepository.GetGenres()
        {
            return context.Genres;
        }
        IEnumerable<Cast> IMovieRepository.GetCast(int MovieId)
        {
            //var ii = MovieId;
            //return context.Casts.ToList();
            return context.Casts.Where(m => m.MovieId == MovieId).Include(m => m.Movie).Include(a => a.Actor).ToList();
        }
        IEnumerable<Actor> IMovieRepository.GetActors()
        {
            return context.Actors;
        }
        MoviePurchase IMovieRepository.AddMoviePurchase(MoviePurchase MoviePurchase)
        {
            context.MoviePurchases.Add(MoviePurchase);
            context.SaveChanges();
            return MoviePurchase;
        }
        MovieRent IMovieRepository.AddMovieRent(MovieRent MovieRent)
        {
            context.MovieRents.Add(MovieRent);
            context.SaveChanges();
            return MovieRent;
        }
    }
}
