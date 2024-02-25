using EntityFrameworkDB.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EntityFrameworkDB.DAO
{
    public interface IDAO
    {
        MODEL.Actor GetActor(ushort id);

        List<MODEL.Actor> GetActors(string inicial);

        List<MODEL.Film> GetFilms();

        List<MODEL.Film> GetFilms(int actorId);

        void SaveActor(TextBox txtFirstName, TextBox txtLastName);

        void DeleteActor(MODEL.Actor actor);

        void UpdateActor(Actor actor);

        void DeleteActorMovies(ushort actorId);
    }
}
