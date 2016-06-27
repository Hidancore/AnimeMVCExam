using AnimeMVCExam.Models;
using AnimeMVCExam.Reposetory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeMVCExam.Controllers
{
    public class AnimeController : Controller
    {
        // GET: Anime

        // at jeg laver en bind.To i ninject på IAnime til AnimeRepository. betyder at når jeg kalder interfaced ind er det lidt det samme som at have AnimeReposetory og alle des metoder her 
        //inde.
        private IAnimes animeRepo;

        public AnimeController(IAnimes animeRepo)
        {
            this.animeRepo = animeRepo;
        }

        public ActionResult Index()
        {
            
            List<Anime> animes = animeRepo.GetAll();
            return View(animes);
        }
        public ActionResult OrderByTitle()
        {
            var Animes = animeRepo.OrderByTitle();
            return View(Animes);
        }
        public ActionResult OrderByEpisodes()
        {
            var Episodes = animeRepo.OrderByEpisodes();
            return View(Episodes);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            Debug.WriteLine("poooo");
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Anime anime)
        {
            //if no broken rules, defined in student
            if (ModelState.IsValid)
            {
                animeRepo.InsertOrUpdate(anime);
                

                // can also be return RedirectToAction("a view of my chosing"); 
                return View("Thanks");
            }
            return View();

        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            //Find the student from the id 
            //and send to view.

            return View(animeRepo.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Models.Anime anime)
        {
            if (ModelState.IsValid)
            {
                animeRepo.InsertOrUpdate(anime);
                /*db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
             
            return View(animeRepo.Find(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            animeRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //Find the student from the id 
            //and send to view.

            return View(animeRepo.Find(id));
        }

    }
}