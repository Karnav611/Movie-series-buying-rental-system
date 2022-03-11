using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMovieBuyingRentingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<WebSeries> WebSeriess { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<WebSeriesCast> WebSeriesCasts { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<WebSeriesImage> WebSeriesImages { get; set; }
        public DbSet<MoviePurchase> MoviePurchases { get; set; }
        public DbSet<MovieRent> MovieRents{ get; set; }
        public DbSet<WebSeriesRent> WebSeriesRents { get; set; }
        public DbSet<WebSeriesPurchase> WebSeriesPurchases { get; set; }
    }
}
