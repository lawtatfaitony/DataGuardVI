using AttEnumCode;
using DataGuard.Identity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 

namespace DataGuard.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        private DataGuard.Context.ApplicationDbContext db = new DataGuard.Context.ApplicationDbContext();
        //代码 作废
        public bool IsInRole(string UserId, string RoleId)
        {
            if (Request.IsAuthenticated)
            {
                bool result = false;
                ApplicationUserRole userRole = db.UserRoles.Where(c => c.UserId == UserId && c.RoleId == RoleId).FirstOrDefault();

                if (userRole != null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                ViewBag.Role_Admin = result;
            }
            return false;
        }

        
    }
}