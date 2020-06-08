using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models.ViewModels;
using System.Threading.Tasks;
using Recipes.Models;

namespace Recipes.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public static string login;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private ICustomerRepository customerRepository;// andrea


        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signMgr, ICustomerRepository customerRepo)
        {
            
            userManager = userMgr;
            signInManager = signMgr;
            customerRepository = customerRepo; // andrea
        }
        //Login
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        login = loginModel.Name;
                        if (loginModel.Name == "Admin")
                            return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                        //For Admin

                    }
                }
            }
            ModelState.AddModelError("", "Invalide name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            login = null;
            
            return Redirect(returnUrl);
        }

        //Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountViewModels.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var customer = new Customer { Name = model.Email, Email = model.Email };
                    customerRepository.SaveCustomer(customer); //Andrea
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}