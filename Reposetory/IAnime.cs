using AnimeMVCExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeMVCExam.Reposetory
{
    public interface IAnimes
    {
        List<Anime> GetAll();
        Anime Find(int id);
        void Delete(int id);
        void InsertOrUpdate(Anime anime);
        IOrderedQueryable OrderByTitle();
        IOrderedQueryable OrderByEpisodes();
    }
}