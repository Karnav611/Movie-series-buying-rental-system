using Microsoft.EntityFrameworkCore;
using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLCastRepository : ICastRepository
    {
        private readonly ApplicationDbContext context;
        public SQLCastRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Cast ICastRepository.GetCast(int Id)
        {
            return context.Casts.Include(m => m.Movie).Include(m => m.Actor).FirstOrDefault(x=>x.Id == Id);
        }
        IEnumerable<Cast> ICastRepository.GetMovieCast(int MovieId)
        {
            //return context.Casts.Find(MovieId);
            return context.Casts.Where(m => m.MovieId == MovieId).ToList();
        }
        Cast ICastRepository.AddCast(Cast Cast)
        {
            context.Casts.Add(Cast);
            context.SaveChanges();
            return Cast;
        }
        Cast ICastRepository.UpdateCast(Cast CastChanges)
        {
            Cast cast = context.Casts.Find(CastChanges.Id);
            cast.Movie = CastChanges.Movie;
            cast.CharacterName = CastChanges.CharacterName;
            cast.Actor = CastChanges.Actor;
            context.SaveChanges();
            return cast;
        }
        Cast ICastRepository.DeleteCast(int Id)
        {
            Cast cast = context.Casts.Find(Id);
            if (cast != null)
            {
                context.Casts.Remove(cast);
                context.SaveChanges();
            }
            return cast;
        }
        IEnumerable<Movie> ICastRepository.GetMovies()
        {
            return context.Movies.ToList();
        }
        IEnumerable<Actor> ICastRepository.GetActors()
        {
            return context.Actors.ToList();
        }
        IEnumerable<Cast> ICastRepository.GetAllCast()
        {
            return context.Casts.Include(m => m.Movie).Include(a => a.Actor).ToList();
        }
    }
}
