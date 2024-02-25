using EntityFrameworkDB.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EntityFrameworkDB.DAO
{
    public class DAOManager : IDAO
    {
        public enum Format { Curt, Llarg };
        private MODEL.PELISContext context = null;
        
        public DAOManager(MODEL.PELISContext context)
        {
            this.context = context;
        }

        public MODEL.Actor GetActor(ushort id)
        {
            return context.Actor.Find(id);
        }

        public List<MODEL.Actor> GetActors(string inicial)
        {
            List<MODEL.Actor> lstActors;
            if(inicial != "*")
            {
                lstActors = context.Actor.ToList<MODEL.Actor>().Where(l => l.LastName.StartsWith(inicial.ToString())).OrderBy(lstActors => lstActors.LastName).ThenBy(lstActors => lstActors.FirstName).ToList();
            }
            else
            {
                lstActors = context.Actor.ToList<MODEL.Actor>().OrderBy(l => l.LastName).ThenBy(l => l.FirstName).ToList();
            }
            return lstActors;
        }

        public List<MODEL.Film> GetFilms()
        {
            List<MODEL.Film> lstFilms = context.Film.ToList<MODEL.Film>();
            return lstFilms;
        }

        public List<MODEL.Film> GetFilms(int actorId)
        {
            List<MODEL.Film> lstFilms = (from f in context.Film 
                                         join fa in context.FilmActor on f.FilmId equals fa.FilmId
                                         where fa.ActorId == actorId select f).ToList<MODEL.Film>();
            return lstFilms;
        }

        public void SaveActor(TextBox txtFirstName, TextBox txtLastName)
        {
            MODEL.Actor actor = new MODEL.Actor();
            actor.FirstName = txtFirstName.Text;
            actor.LastName = txtLastName.Text;
            actor.LastUpdate = DateTime.Now;
            context.Actor.Add(actor);
            context.SaveChanges();
        }

        public void DeleteActor(MODEL.Actor actor)
        {
            context.Actor.Remove(actor);
            context.SaveChanges();
        }

        public void UpdateActor(Actor actor)
        {
            context.Actor.Update(actor);
            context.SaveChanges();
        }

        public void DeleteActorMovies(ushort actorId)
        {
            List<MODEL.FilmActor> lstFilmActor = context.FilmActor.Where(fa => fa.ActorId == actorId).ToList<MODEL.FilmActor>();
            foreach (MODEL.FilmActor fa in lstFilmActor)
            {
                context.FilmActor.Remove(fa);
            }
            context.SaveChanges();
        }
    }
}
