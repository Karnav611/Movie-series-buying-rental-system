using OnlineMovieBuyingRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieBuyingRentingSystem.Models
{
    public class SQLActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext context;
        public SQLActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Actor IActorRepository.GetActor(int Id)
        {
            return context.Actors.Find(Id);
        }
        Actor IActorRepository.AddActor(Actor Actor)
        {
            context.Actors.Add(Actor);
            context.SaveChanges();
            return Actor;
        }
        Actor IActorRepository.UpdateActor(Actor ActorChanges)
        {
            Actor actor = context.Actors.Find(ActorChanges.Id);
            actor.Name = ActorChanges.Name;
            actor.Age = ActorChanges.Age;
            context.SaveChanges();
            return actor;
        }
        Actor IActorRepository.DeleteActor(int Id)
        {
            Actor actor = context.Actors.Find(Id);
            if (actor != null)
            {
                context.Actors.Remove(actor);
                context.SaveChanges();
            }
            return actor;
        }
        IEnumerable<Actor> IActorRepository.GetActors()
        {
            return context.Actors.ToList();
        }
    }
}
