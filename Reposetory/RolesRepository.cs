using AnimeMVCExam.Controllers;
using AnimeMVCExam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeMVCExam.Reposetory
{
    public class RolesRepository : IRolesRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public void Create(FormCollection collection)
        {
           
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                db.SaveChanges();          
           
        }

        public void delete(string RoleName)
        {       
            db.Roles.Remove(Find(RoleName));
            db.SaveChanges();
        }

        public void Edit(IdentityRole role)
        {
            db.Entry(role).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IdentityRole Find(string RoleName)
        {
            
            return db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public List<IdentityRole> GetAll()
        {
            string UserName = "nick2463";
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Debug.WriteLine(db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault());
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id); // works
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.Id);
            return db.Roles.ToList();
        }

        public List<SelectListItem> RoleListUpdate()
        {
            return db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
        }
        public void RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var account = new AccountController();
            account.UserManager.AddToRole(user.Id, RoleName);
        }
        public IList<string> getRoles(string UserName)
        {
            
                ApplicationUser user = getUser(UserName);
                var account = new AccountController();
            Debug.WriteLine(user.Id);
            Debug.WriteLine(account.UserManager.GetRoles(user.Id));

            return account.UserManager.GetRoles(user.Id);

            
            
        }
        public void RemoveUserRole(string UserName, string RoleName)
        {
            var account = new AccountController();
            ApplicationUser user = getUser(UserName);
            

            account.UserManager.RemoveFromRole(user.Id, RoleName);
        }
        public bool RoleCheck(string UserName, string RoleName)
        {

            ApplicationUser user = getUser(UserName);
            var account = new AccountController();
            
            
            if (account.UserManager.IsInRole(user.Id, RoleName))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public ApplicationUser getUser(string UserName)
        {
            return db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault(); // works
            
        }
    }
}