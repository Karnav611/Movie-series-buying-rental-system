using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLWebSeriesImageRepository : IWebSeriesImageRepository
    {
        private readonly ApplicationDbContext context;
        public SQLWebSeriesImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        WebSeriesImage IWebSeriesImageRepository.GetImage(int Id)
        {
            return context.WebSeriesImages.Include(m => m.WebSeries).FirstOrDefault(x => x.Id == Id);
        }
        IEnumerable<WebSeriesImage> IWebSeriesImageRepository.GetWebSeriesImages(int WebSeriesId)
        {
            return context.WebSeriesImages.Include(m => m.WebSeries).Where(x => x.WebSeriesId == WebSeriesId).ToList();
        }
        WebSeriesImage IWebSeriesImageRepository.AddWebSeriesImage(WebSeriesImage WebSeriesImage)
        {
            context.WebSeriesImages.Add(WebSeriesImage);
            context.SaveChanges();
            return WebSeriesImage;
        }
        WebSeriesImage IWebSeriesImageRepository.UpdateWebSeriesImage(WebSeriesImage WebSeriesImageChanges)
        {
            WebSeriesImage webseriesimage = context.WebSeriesImages.Find(WebSeriesImageChanges.Id);
            webseriesimage.WebSeries = WebSeriesImageChanges.WebSeries;
            webseriesimage.Path = WebSeriesImageChanges.Path;
            context.SaveChanges();
            return webseriesimage;
        }
        WebSeriesImage IWebSeriesImageRepository.DeleteWebSeriesImage(int Id)
        {
            WebSeriesImage webseriesimage = context.WebSeriesImages.Find(Id);
            if (webseriesimage != null)
            {
                context.WebSeriesImages.Remove(webseriesimage);
                context.SaveChanges();
            }
            return webseriesimage;
        }
        IEnumerable<WebSeriesImage> IWebSeriesImageRepository.GetAllImages()
        {
            return context.WebSeriesImages.Include(m => m.WebSeries);
        }
        IEnumerable<WebSeries> IWebSeriesImageRepository.GetWebSeriess()
        {
            return context.WebSeriess;
        }
    }
}
