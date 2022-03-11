using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface ICastRepository
    {
        Cast AddCast(Cast Cast);
        Cast UpdateCast(Cast Cast);
        Cast DeleteCast(int Id);
        Cast GetCast(int Id);
        IEnumerable<Cast> GetAllCast();
        IEnumerable<Cast> GetMovieCast(int MovieId);
        IEnumerable<Movie> GetMovies();
        IEnumerable<Actor> GetActors();
    }
}
