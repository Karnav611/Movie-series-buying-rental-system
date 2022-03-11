using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLMovieImageRepository : IMovieImageRepository
    {
        private readonly ApplicationDbContext context;
        public SQLMovieImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        MovieImage IMovieImageRepository.GetImage(int Id)
        {
            return context.MovieImages.Include(m => m.Movie).FirstOrDefault(x => x.Id == Id);
        }
        IEnumerable<MovieImage> IMovieImageRepository.GetMovieImages(int MovieId)
        {
            return context.MovieImages.Include(m => m.Movie).Where(x => x.MovieId == MovieId).ToList();
        }
        MovieImage IMovieImageRepository.AddMovieImage(MovieImage MovieImage)
        {
            context.MovieImages.Add(MovieImage);
            context.SaveChanges();
            return MovieImage;
        }
        MovieImage IMovieImageRepository.UpdateMovieImage(MovieImage MovieImageChanges)
        {
            MovieImage movieimage = context.MovieImages.Find(MovieImageChanges.Id);
            movieimage.Movie = MovieImageChanges.Movie;
            movieimage.Path = MovieImageChanges.Path;
            context.SaveChanges();
            return movieimage;
        }
        MovieImage IMovieImageRepository.DeleteMovieImage(int Id)
        {
            MovieImage movieimage = context.MovieImages.Find(Id);
            if (movieimage != null)
            {
                context.MovieImages.Remove(movieimage);
                context.SaveChanges();
            }
            return movieimage;
        }
        IEnumerable<MovieImage> IMovieImageRepository.GetAllImages()
        {
            return context.MovieImages.Include(m => m.Movie);
        }
        IEnumerable<Movie> IMovieImageRepository.GetMovies()
        {
            return context.Movies;
        }
    }
}
