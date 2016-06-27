using AnimeMVCExam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeMVCExam.Reposetory
{
    public interface IRolesRepository
    {
        List<IdentityRole> GetAll();
        void Create(FormCollection collection);
        void Edit(IdentityRole role);
        void delete(string RoleName);
        IdentityRole Find(string RoleName);
        void RoleAddToUser(string UserName, string RoleName);
        List<SelectListItem> RoleListUpdate();
        IList<string> getRoles(string UserName);
        void RemoveUserRole(string UserName, string RoleName);
        ApplicationUser getUser(string UserName);
        bool RoleCheck(string UserName, string RoleName);
    }
}