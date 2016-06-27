using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AnimeMVCExam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace AnimeMVCExam.manual
{
    public class Configuration //: DbMigrationsConfiguration<Models.ApplicationDbContext>
    {

    //    public manualInput()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }

    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    //        String[] roleNames = { "Admin", "Moderator", "Member" };
    //        IdentityResult RoleResult;
    //        foreach (var roleName in roleNames)
    //        {
    //            if (!RoleManager.RoleExists(roleName))
    //            {
    //                RoleResult = RoleManager.Create(new IdentityRole(roleName));
    //            }
    //        }
    //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    //        UserManager.AddToRole("32fafd27-7244-43c6-8bed-eddcab805160", "Admin");
    //    }
        
    }
}