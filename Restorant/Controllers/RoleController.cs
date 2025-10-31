using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restorant.DTOs.UserDtos;

namespace Restorant.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManger;

        public RoleController(RoleManager<IdentityRole> roleManger)
        {
            this.roleManger = roleManger;
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddRole(Role role)
        {
            if(ModelState.IsValid)
            {
              IdentityResult result = await roleManger.CreateAsync(new IdentityRole(role.RoleName));
                if(result.Succeeded)
                {
                    ViewBag.sucess = true;
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("AddRole", role);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminAuton()
        {
            return View();
        }
    }
}
