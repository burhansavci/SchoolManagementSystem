using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SMS.BLL.Service;
using SMS.Models.Identity;
using SMS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Controllers
{
    public class AccountController : Controller
    {
        DataService service = new DataService();
        public ActionResult SignIn()
        {
            //Test

            if (HttpContext.GetOwinContext().Authentication.User.Identity.IsAuthenticated)
                return Redirect("/panel");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginVm data)
        {
            if (ModelState.IsValid)
            {
                var userManager = service.UnitOfWork.Members.Users;
                var user = service.UnitOfWork.Members.Users.FindByName(data.UserName);

                if (user != null && user.IsActive == true)
                {
                    if (userManager.CheckPassword(user, data.Password))
                    {
                        var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        HttpContext.GetOwinContext().Authentication.SignIn(
                            new AuthenticationProperties
                            {
                                IsPersistent = true
                            }, identity);

                        return Redirect("/panel");
                    }
                }
            }

            return View();
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/");
        }
    }
}