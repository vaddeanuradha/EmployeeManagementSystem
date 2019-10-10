using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeUI.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            base.OnActionExecuting(context);
            ViewData["IsAdmin"] = HttpContext.User.Identity.Name == "jhon@gmail.com";
            //var User = HttpContext.User.Identity.Name;
            //var employee = new Employee();

            //if (User == employee.EmployeeRole.Role.RoleName)
            //{
            //    if (employee.EmployeeRole.Role.RoleId == 2)
            ////    {
                    //ViewData["IsManager"] = !string.IsNullOrEmpty(HttpContext.User.Identity.Name);
            //    }

            //}
            //if (User == employee.EmployeeRole.Role.RoleName)
            //{
            //    if (employee.EmployeeRole.Role.RoleId == 3)
            //    {
                    ViewData["IsStandardUser"] = !string.IsNullOrEmpty(HttpContext.User.Identity.Name);
            //    }
            //}
        }
    }
}
