using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnimeMVCExam.Models.Injection;

namespace AnimeMVCExam.Controllers
{
    public class injectController : Controller
    {
        private IColor color;

        public injectController(IColor color)
        {
            this.color = color;
        }
        // GET: inject
        public ActionResult Index()
        {
            string color = this.color.getColor();
            return View(color as object);
        }
    }
}