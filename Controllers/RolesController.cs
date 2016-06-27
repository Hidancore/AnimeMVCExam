using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using AnimeMVCExam.Models;
using AnimeMVCExam.Reposetory;

namespace AnimeMVCExam.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        IRolesRepository rolesRepo;

        public RolesController(IRolesRepository rolesRepo)
        {
            this.rolesRepo = rolesRepo;
        }
        // GET: Roles
        public ActionResult Index()
        {
            return View(rolesRepo.GetAll());
            
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                rolesRepo.Create(collection);
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(string RoleName)
        {
            rolesRepo.delete(RoleName);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string roleName)
        {
            

            return View(rolesRepo.Find(roleName));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                rolesRepo.Edit(role);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            rolesRepo.RoleAddToUser(UserName, RoleName);

            ViewBag.ResultMessage = "Role created successfully !";

            
            ViewBag.Roles = rolesRepo.RoleListUpdate();

            return View("ManageUserRoles");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult GetRoles(string UserName)
        //{
        //    if (!string.IsNullOrWhiteSpace(UserName))
        //    {


        //        ViewBag.RolesForThisUser = rolesRepo.getRoles(UserName);

        //        // prepopulat roles for the view dropdown

        //        ViewBag.Roles = rolesRepo.RoleListUpdate();
        //    }
        //    return View("ManageUserRoles");
        //}

        //forsøg på at se om ikke det er fordi jeg har lavet det om til dependency injection. dog virker metoden her heller ikke. så tror jeg giver op.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var account = new AccountController();

                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {

            if (rolesRepo.RoleCheck(UserName, RoleName))
            {
                rolesRepo.RemoveUserRole(UserName, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }

            ViewBag.Roles = rolesRepo.RoleListUpdate();

            return View("ManageUserRoles");
        }

        public ActionResult ManageUserRoles()
        {
            // prepopulat roles for the view dropdown
            
            ViewBag.Roles = rolesRepo.RoleListUpdate();
            return View();
        }
    }
}