using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLWebSeriesCastRepository : IWebSeriesCastRepository
    {
        private readonly ApplicationDbContext context;
        public SQLWebSeriesCastRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        WebSeriesCast IWebSeriesCastRepository.GetWebSeriesCast(int Id)
        {
            return context.WebSeriesCasts.Include(m => m.WebSeries).Include(m => m.Actor).FirstOrDefault(x => x.Id == Id);
        }
        IEnumerable<WebSeriesCast> IWebSeriesCastRepository.GetWebSeriessCast(int WebSeriesId)
        {
            //return context.WebSeriesCasts.Find(WebSeriesId);
            return context.WebSeriesCasts.Where(m => m.WebSeriesId == WebSeriesId).ToList();
        }
        WebSeriesCast IWebSeriesCastRepository.AddWebSeriesCast(WebSeriesCast WebSeriesCast)
        {
            context.WebSeriesCasts.Add(WebSeriesCast);
            context.SaveChanges();
            return WebSeriesCast;
        }
        WebSeriesCast IWebSeriesCastRepository.UpdateWebSeriesCast(WebSeriesCast WebSeriesCastChanges)
        {
            WebSeriesCast cast = context.WebSeriesCasts.Find(WebSeriesCastChanges.Id);
            cast.WebSeries = WebSeriesCastChanges.WebSeries;
            cast.CharacterName = WebSeriesCastChanges.CharacterName;
            cast.Actor = WebSeriesCastChanges.Actor;
            context.SaveChanges();
            return cast;
        }
        WebSeriesCast IWebSeriesCastRepository.DeleteWebSeriesCast(int Id)
        {
            WebSeriesCast cast = context.WebSeriesCasts.Find(Id);
            if (cast != null)
            {
                context.WebSeriesCasts.Remove(cast);
                context.SaveChanges();
            }
            return cast;
        }
        IEnumerable<WebSeries> IWebSeriesCastRepository.GetWebSeriess()
        {
            return context.WebSeriess.ToList();
        }
        IEnumerable<Actor> IWebSeriesCastRepository.GetActors()
        {
            return context.Actors.ToList();
        }
        IEnumerable<WebSeriesCast> IWebSeriesCastRepository.GetAllWebSeriesCast()
        {
            return context.WebSeriesCasts.Include(m => m.WebSeries).Include(a => a.Actor).ToList();
        }
    }
}
