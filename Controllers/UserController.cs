using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sales.Interface;
using Sales.Models;
using Sales.ReposInterface;
using Sales.Repository;

namespace Sales.Controllers
{
    public class UserController : Controller
    {
        
        public IReposUser _ReposUser { get; }
        public UserController(IReposUser reposUser)
        {
            _ReposUser = reposUser;
        }
        public ActionResult ChangeLanguage(string culture)
        {
          
            HttpCookie cookie = new HttpCookie("culture", culture);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.ToString());
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View(new User());
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_ReposUser.MyAny(user.Username))
                    return View(user);


                TempData["Username"] = user.Username;
                TempData["Password"] = user.Password; 
                user.Password = Encryption.Encrypt(user.Password);
                _ReposUser.Add(user);
                _ReposUser.Save();
              

                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.Cookies["UserSession"] != null)
            {
                var username = Request.Cookies["UserSession"].Value;
                var user = _ReposUser.Search(username);
                if (user != null && user.SessionExpiry > DateTime.Now)
                {
                    Session["Username"] = user.Username;
                    return RedirectToAction("Index", "Home");
                }
            }

            
            if (TempData["Username"] != null && TempData["Password"] != null)
            {
                string username = TempData["Username"].ToString();
                string password = TempData["Password"].ToString();

                return Login(username, password);
            }

            return View(new User());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return View(new User());


            var encpassword = Encryption.Encrypt(password);
            //var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == encpassword);
            var user = _ReposUser.SearchWhitPassUser(username, encpassword);
            if (user != null)
            {
                if (user.SessionExpiry.HasValue && user.SessionExpiry > DateTime.Now)
                {
                    Session["Username"] = user.Username;
                    return RedirectToAction("Index", "Home");
                }

                user.SessionExpiry = DateTime.Now.AddHours(3);
                _ReposUser.Save();

                var cookie = new HttpCookie("UserSession")
                {
                    Value = user.Username,
                    Expires = DateTime.Now.AddHours(3) 
                };
                Response.Cookies.Add(cookie);


                Session["Username"] = user.Username;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = Sales.Resources.Resource.Invalid;
            return View(new User());
        }

        public ActionResult Logout()
        {
            var username = Session["Username"]?.ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var user = _ReposUser.Search(username);
                if (user != null)
                {
                    user.SessionExpiry = null;
                    _ReposUser.Save();
                }
            }

            Session.Abandon();

            if (Request.Cookies["UserSession"] != null)
            {
                var cookie = new HttpCookie("UserSession")
                {
                    Expires = DateTime.Now.AddDays(-1)   
                };
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Login", "User");
        }



    }
}
