using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLWebSeriesRepository : IWebSeriesRepository
    {
        private readonly ApplicationDbContext context;
        public SQLWebSeriesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        WebSeries IWebSeriesRepository.GetWebSeries(int Id)
        {
            return context.WebSeriess.Include(m => m.Genre).FirstOrDefault(x => x.Id == Id);
        }
        WebSeries IWebSeriesRepository.AddWebSeries(WebSeries WebSeries)
        {
            context.WebSeriess.Add(WebSeries);
            context.SaveChanges();
            return WebSeries;
        }
        WebSeries IWebSeriesRepository.UpdateWebSeries(WebSeries WebSeriesChanges)
        {
            WebSeries movie = context.WebSeriess.Find(WebSeriesChanges.Id);
            movie.Title = WebSeriesChanges.Title;
            movie.Description = WebSeriesChanges.Description;
            movie.Genre = WebSeriesChanges.Genre;
            movie.IMDBRating = WebSeriesChanges.IMDBRating;
            movie.Poster = WebSeriesChanges.Poster;
            movie.TrailerLink = WebSeriesChanges.TrailerLink;
            movie.RentLink = WebSeriesChanges.RentLink;
            movie.WebSeriesFilePath = WebSeriesChanges.WebSeriesFilePath;
            movie.PurchasePrice = WebSeriesChanges.PurchasePrice;
            movie.RentPrice = WebSeriesChanges.RentPrice;
            context.SaveChanges();
            return movie;
        }
        WebSeries IWebSeriesRepository.DeleteWebSeries(int Id)
        {
            WebSeries movie = context.WebSeriess.Find(Id);
            if (movie != null)
            {
                context.WebSeriess.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }
        IEnumerable<WebSeries> IWebSeriesRepository.GetAllWebSeriess()
        {
            //IEnumerable<WebSeries> temp = context.WebSeriess.Include(m => m.Genre);
            return context.WebSeriess.Include(m => m.Genre);
        }
        IEnumerable<WebSeries> IWebSeriesRepository.GetHomeWebSeriess()
        {
            //IEnumerable<WebSeries> temp = context.WebSeriess.Include(m => m.Genre);
            return context.WebSeriess.Include(m => m.Genre).Take(2);
        }
        IEnumerable<WebSeries> IWebSeriesRepository.GetWebSeriessByGenre(int GenreId)
        {
            return context.WebSeriess.Include(m => m.Genre).Where(m => m.GenreId == GenreId).ToList();
        }
        IEnumerable<Genre> IWebSeriesRepository.GetGenres()
        {
            return context.Genres;
        }
        IEnumerable<WebSeriesCast> IWebSeriesRepository.GetWebSeriesCast(int WebSeriesId)
        {
            //var ii = WebSeriesId;
            //return context.WebSeriesWebSeriesCasts.ToList();
            return context.WebSeriesCasts.Where(m => m.WebSeriesId == WebSeriesId).Include(m => m.WebSeries).Include(a => a.Actor).ToList();
        }
        IEnumerable<Actor> IWebSeriesRepository.GetActors()
        {
            return context.Actors;
        }
        WebSeriesPurchase IWebSeriesRepository.AddWebSeriesPurchase(WebSeriesPurchase WebSeriesPurchase)
        {
            context.WebSeriesPurchases.Add(WebSeriesPurchase);
            context.SaveChanges();
            return WebSeriesPurchase;
        }
        WebSeriesRent IWebSeriesRepository.AddWebSeriesRent(WebSeriesRent WebSeriesRent)
        {
            context.WebSeriesRents.Add(WebSeriesRent);
            context.SaveChanges();
            return WebSeriesRent;
        }
    }
}
