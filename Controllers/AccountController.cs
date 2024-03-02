
using EnterpriceWeb.Models;
using EnterpriceWeb.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace EnterpriceWeb.Controllers
{
    public class AccountController:Controller
    {
        private readonly AppDbConText _dbContext;
        private readonly RepoAccount _repoAccount;
        public AccountController(AppDbConText dbContext)
        {
            _dbContext = dbContext;
            _repoAccount = new RepoAccount(dbContext);
            
        }
        //Register Account
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                if (_repoAccount.register(_user)== null)
                {
                    _dbContext.users.Add(_user);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }

        //Login Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string gmail, string password, RepoAccount repoAccount)
        {
            if (ModelState.IsValid)
            {
                var data = repoAccount.login(gmail,password);
                if (data.Count()==0)
                {
                    HttpContext.Session.SetString("gmail", data.FirstOrDefault().us_gmail);
                    HttpContext.Session.SetInt32("UserId", data.FirstOrDefault().us_id);

                    return RedirectToAction("~/Home/Private");
                }
                else
                {
                    TempData["erorr"] = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        //Logout Account
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        //Provide Permissions Account

        //Delete Account
    }
}
