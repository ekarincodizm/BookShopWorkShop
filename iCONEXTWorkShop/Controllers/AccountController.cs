using System.Text;
using System.Web;
using BookModel;
using iCONEXTWorkShop.Models;
using System.Web.Mvc;
using System.Web.Security;
using BookService;
using iCONEXTWorkShop.Helper;
using iCONEXTWorkShop.ViewModels;

namespace iCONEXTWorkShop.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginViewModel model)
        {
            HttpContext context = System.Web.HttpContext.Current;
            if (ModelState.IsValid)
            {
                LoginServiceModel loginServiceModel = new LoginServiceModel();
                loginServiceModel.Username = model.Username;
                loginServiceModel.Password = model.Password;
                loginServiceModel.RememberMe = model.RememberMe;
                LoginService loginService = new LoginService();
                var userData = loginService.GetUser(loginServiceModel.Username, loginServiceModel.Password);
                UserViewModel userView = new UserViewModel();
                userView.Id = userData.Id;
                userView.CritizenId = userData.CritizenId;
                userView.BirthDay = userData.BirthDay;
                userView.UserName = userData.UserName;
                userView.FirstName = userData.FirstName;
                userView.LastName = userData.LastName;
                userView.Password = userData.Password;
                userView.Email = userData.Email;
                userView.Address = userData.Address;
                userView.ZipCode = userData.ZipCode;
                userView.UserClassId = userData.UserClassId;
                userView.UserClassName = userData.UserName;
                if (userView.Id != null)
                {
                    SessionManager.UserData = userView;
                    if (userView.UserClassId == 2)
                    {
                        return RedirectToAction("Addbook", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountServiceModel accountServiceModel = new AccountServiceModel();
                accountServiceModel.FirstName = model.FirstName;
                accountServiceModel.LastName = model.LastName;
                accountServiceModel.Address = model.Address;
                accountServiceModel.BirthDay = model.BirthDay;
                accountServiceModel.CritizenId = model.CritizenId;
                accountServiceModel.Email = model.Email;
                accountServiceModel.UserName = model.UserName;
                accountServiceModel.Password = model.Password;

                AccountService accountService = new AccountService();
                if (accountService.RegisterAccount(accountServiceModel))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "UserName already exists.");
                    return View(model);
                }
            }
            ModelState.AddModelError(string.Empty, "UserName already exists.");
            return View(model);
        }
    }
}