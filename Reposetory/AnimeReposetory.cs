using AnimeMVCExam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AnimeMVCExam.Reposetory
{
    // this class with the IAnime interface is Generic. it can be used wihtout effect on which application uses it.
    public class AnimeReposetory : IAnimes
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            Anime anime = db.Animes.Find(id);
            db.Animes.Remove(anime);
            db.SaveChanges();
        }

        public Anime Find(int id)
        {
            return db.Animes.Find(id);
           
        }

        public List<Anime> GetAll()
        {
            return db.Animes.ToList();
        }

        public void InsertOrUpdate(Anime anime)
        {
            
            if (anime.AnimeId == 0)
            {
                db.Animes.Add(anime);
            }
            else
            {
                db.Entry(anime).State = EntityState.Modified;
                
                
            }
            db.SaveChanges();
        }

        public IOrderedQueryable OrderByTitle()
        {
            return from p in db.Animes
                               orderby p.Title ascending
                               select p;
        }
        public IOrderedQueryable OrderByEpisodes()
        {
            return from p in db.Animes
                   orderby p.Episodes ascending
                   select p;
        }
    }
}