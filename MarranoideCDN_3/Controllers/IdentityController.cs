using MarranoideCDN_3.Application;
using MarranoideCDN_3.Models;
using MarranoideCDN_3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Controllers
{
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return Redirect(Url.Action("Index", "Home"));
        }

        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Logout(string sessionToken)
        {
            Session session = RepoSessions.Get(x => x.SessionToken == sessionToken);
            session.SessionToken = null;
            RepoSessions.Update(session);

            HttpContext.Response.Cookies.Delete("sessionToken");
            HttpContext.Response.Cookies.Delete("IDaccount");
            return Redirect(Url.Action("Index", "Home"));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitLogin(string Username, string Password)
        {
            if (RepoAccounts.IsPasswordCorrect(Username, Password))
            {
                Account account = RepoAccounts.Get(x => x.Username == Username);
                if (RepoSessions.Exist(account.IDAccount))
                {
                    Session session = RepoSessions.Get(account.IDAccount);
                    session.LastLogin = DateTime.Now;
                    session.SessionToken = Security.SHA256Hash(ApplicationManager.GenerateGUID);
                    RepoSessions.Update(session);

                    HttpContext.Response.Cookies.Append("sessionToken", session.SessionToken);
                    HttpContext.Response.Cookies.Append("IDaccount", account.IDAccount);
                }
                else
                {
                    Session session = new Session()
                    {
                        IDSession = ApplicationManager.GenerateGUID,
                        IDAccount = account.IDAccount,
                        SessionToken = Security.SHA256Hash(ApplicationManager.GenerateGUID),
                        LastLogin = DateTime.Now
                    };
                    RepoSessions.Add(session);

                    HttpContext.Response.Cookies.Append("sessionToken", session.SessionToken);
                    HttpContext.Response.Cookies.Append("IDaccount", account.IDAccount);
                }
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(Url.Action("Login", "Identity"));
        }
    }
}
