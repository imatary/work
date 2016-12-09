using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UMCWorkManager.Models;
using UMCWorkManager.ViewModels;

namespace UMCWorkManager.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;


        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: User
        [Authorize]
        public async Task<ActionResult> Employee(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != null)
                {
                    var employeeViewModel = new EmployeeViewModel();
                    var employee = UserManager.Users.SingleOrDefault(u => u.Id == id);
                    if (employee != null)
                    {
                        employeeViewModel.ApplicationUser = employee;
                        employeeViewModel.Users = await GetUsersInRoleAsync();
                        return View(employeeViewModel);
                    }
                    return RedirectToAction("Error404", "Error");
                }
                return RedirectToAction("Error404", "Error");
            }
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles ="Manager")]
        public async Task<ActionResult> Manager()
        {
            if (User.Identity.IsAuthenticated)
            {
                //var managerUser = UserManager.Users.SingleOrDefault(u => u.Id == HttpContext.User.Identity.GetUserId());
                var roleUser = new RoleUserViewModel();


                //roleUser.ManagerUser = managerUser;
                roleUser.ApplicationUsers = await GetUsersInRoleAsync();

                return View(roleUser);
            }

            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<List<ApplicationUser>> GetUsersInRoleAsync()
        {
            var users = new List<ApplicationUser>();
            foreach (var item in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(item.Id, "Employee"))
                {
                    users.Add(item);
                }
            }

            return users;
        }
    }
}