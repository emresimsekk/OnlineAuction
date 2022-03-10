using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Core.Entities;
using OnlineAuction.UI.ViewsModel;
using System.Threading.Tasks;

namespace OnlineAuction.UI.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user!=null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password,false,false);

                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
                        //return RedirectToAction("Index");
                        return LocalRedirect(returnUrl);
                    }
                    {
                        ModelState.AddModelError("", "Email address is not valid or password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email address is not valid or password");
                }
            }

            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser newAppUser = new();

                newAppUser.UserName = signUpViewModel.Username;
                newAppUser.FirstName = signUpViewModel.FirstName;
                newAppUser.LastName = signUpViewModel.LastName;
                newAppUser.Email = signUpViewModel.Email;
                newAppUser.PhoneNumber = signUpViewModel.PhoneNumber;
                if (signUpViewModel.UserSelectTypeId==1)
                {
                    newAppUser.IsBuyer = true;
                    newAppUser.IsSeller = false;
                }
                else
                {
                    newAppUser.IsBuyer = false;
                    newAppUser.IsSeller = true;
                }

                var result = await _userManager.CreateAsync(newAppUser, signUpViewModel.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }


            return View(signUpViewModel);
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
