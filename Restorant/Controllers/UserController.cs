//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Restorant.Models;
//using Restorant.ViewModels;

//namespace Restorant.Controllers
//{
//    public class UserController : Controller
//    {

//        private readonly UserManager<AppUser> _userManager;
//        private readonly SignInManager<AppUser> _signInManager;

//        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }
//        public IActionResult Rgister()
//        { 
//            var user = new UserRegister();
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Rgister(UserRegister user)
//        {
//           var newUser = new AppUser();
//            newUser.UserName = user.UserName;
//            newUser.Email = user.Email;
//            var result = await  _userManager.CreateAsync(newUser, user.Password);
//            if (result.Succeeded) 
//            {
//                await _signInManager.SignInAsync(newUser, isPersistent: false);
//                return RedirectToAction("Index", "Home");
//            }

//            else
//            {
//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError("", error.Description);
//                }
//                return View("Register");
//            }
//        }



//    }
//}
