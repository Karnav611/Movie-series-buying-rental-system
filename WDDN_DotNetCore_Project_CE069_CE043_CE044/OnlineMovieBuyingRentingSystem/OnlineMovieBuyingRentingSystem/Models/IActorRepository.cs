using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public interface IActorRepository
    {
        Actor AddActor(Actor Actor);
        Actor UpdateActor(Actor Actor);
        Actor DeleteActor(int Id);
        Actor GetActor(int Id);
        IEnumerable<Actor> GetActors();
    }
}
