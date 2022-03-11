using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IWebSeriesImageRepository
    {
        WebSeriesImage GetImage(int Id);
        IEnumerable<WebSeriesImage> GetWebSeriesImages(int WebSeriesId);
        WebSeriesImage AddWebSeriesImage(WebSeriesImage IWebSeriesImageRepository);
        WebSeriesImage UpdateWebSeriesImage(WebSeriesImage IWebSeriesImageRepository);
        WebSeriesImage DeleteWebSeriesImage(int Id);
        IEnumerable<WebSeriesImage> GetAllImages();
        IEnumerable<WebSeries> GetWebSeriess();
    }
}
