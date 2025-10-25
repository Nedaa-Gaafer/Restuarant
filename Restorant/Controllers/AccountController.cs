using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restorant.DTOs.UserDtos;
using Restorant.Models;

namespace Restorant.Controllers
{
    public class AccountController : Controller
    {

       private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Register(UserRegister createUser)
        {
            if(ModelState.IsValid)
            {
                var user = createUser.Adapt<AppUser>();
                IdentityResult res = await _userManager.CreateAsync(user, createUser.Password);
                if (res.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
           
           
                return View("Register", createUser);
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            
            if (ModelState.IsValid)
            {
               var foundUser =  await _userManager.FindByNameAsync(userDto.UserName);
                if(foundUser != null)
                {
                  var found = await _userManager.CheckPasswordAsync(foundUser, userDto.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(foundUser, userDto.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "Invalid username or password");

            }

            return View("Login", userDto);
        }


        //public async Task<IActionResult> SignOut()
        //{
        //   await _signInManager.SignOutAsync();
        //    return View("Login"); // 
        //}


    }
}
