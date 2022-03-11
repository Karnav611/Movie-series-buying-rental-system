using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLHomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext context;
        public SQLHomeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Movie IHomeRepository.GetMovie(int Id)
        {
            return context.Movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == Id);
        }
        IEnumerable<Movie> IHomeRepository.GetMovies()
        {
            return context.Movies.Include(m => m.Genre).Take(4);
        }
        IEnumerable<WebSeries> IHomeRepository.GetWebSeriess()
        {
            return context.WebSeriess.Include(m => m.Genre).Take(3);
        }
        WebSeries IHomeRepository.GetWebSeries(int Id)
        {
            return context.WebSeriess.Include(m => m.Genre).FirstOrDefault(x => x.Id == Id);
        }
        IEnumerable<Cast> IHomeRepository.GetCast(int MovieId)
        {
            return context.Casts.Where(m => m.MovieId == MovieId).Include(m => m.Movie).Include(a => a.Actor).ToList();
        }
        IEnumerable<WebSeriesCast> IHomeRepository.GetWebSeriesCast(int WebSeriesId)
        {
            return context.WebSeriesCasts.Where(m => m.WebSeriesId == WebSeriesId).Include(m => m.WebSeries).Include(a => a.Actor).ToList();
        }
        IEnumerable<MovieImage> IHomeRepository.GetImages(int MovieId)
        {
            return context.MovieImages.Where(m => m.MovieId == MovieId);
        }
        IEnumerable<WebSeriesImage> IHomeRepository.GetWebSeriesImages(int WebSeriesId)
        {
            return context.WebSeriesImages.Where(m => m.WebSeriesId == WebSeriesId);
        }
        IEnumerable<Genre> IHomeRepository.GetGenres()
        {
            return context.Genres;
        }
        IEnumerable<Actor> IHomeRepository.GetActors()
        {
            return context.Actors;
        }
        bool IHomeRepository.MoviePurchased(int Id,string useremail)
        {
            MoviePurchase p = context.MoviePurchases.FirstOrDefault(x => x.MovieId == Id && x.UserEmail == useremail);
            if(p==null)
                return false;
            return true;
        }
        bool IHomeRepository.MovieRented(int Id, string useremail)
        {
            MovieRent r = context.MovieRents.FirstOrDefault(x => x.MovieId == Id && x.UserEmail == useremail);
            if (r == null)
                return false;
            return true;
        }
        bool IHomeRepository.WebSeriesPurchased(int Id, string useremail)
        {
            WebSeriesPurchase p = context.WebSeriesPurchases.FirstOrDefault(x => x.WebSeriesId == Id && x.UserEmail == useremail);
            if (p == null)
                return false;
            return true;
        }
        bool IHomeRepository.WebSeriesRented(int Id, string useremail)
        {
            WebSeriesRent r = context.WebSeriesRents.FirstOrDefault(x => x.WebSeriesId == Id && x.UserEmail == useremail);
            if (r == null)
                return false;
            return true;
        }
        MoviePurchase IHomeRepository.AddMoviePurchase(MoviePurchase MoviePurchase)
        {
            context.MoviePurchases.Add(MoviePurchase);
            context.SaveChanges();
            return MoviePurchase;
        }
        MovieRent IHomeRepository.AddMovieRent(MovieRent MovieRent)
        {
            context.MovieRents.Add(MovieRent);
            context.SaveChanges();
            return MovieRent;
        }
        WebSeriesPurchase IHomeRepository.AddWebSeriesPurchase(WebSeriesPurchase WebSeriesPurchase)
        {
            context.WebSeriesPurchases.Add(WebSeriesPurchase);
            context.SaveChanges();
            return WebSeriesPurchase;
        }
        WebSeriesRent IHomeRepository.AddWebSeriesRent(WebSeriesRent WebSeriesRent)
        {
            context.WebSeriesRents.Add(WebSeriesRent);
            context.SaveChanges();
            return WebSeriesRent;
        }
    }
}
