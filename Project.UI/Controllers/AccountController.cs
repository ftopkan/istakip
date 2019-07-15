using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Project.UI.Models;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entities.Models;
using Project.DAL.Repositories.UnitOfWork;

namespace Project.UI.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Login()
        {
            var context = new AppDbContext();
            var roleStore = new RoleStore<AppRole>(context);
            var roleManager = new RoleManager<AppRole>(roleStore);

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new AppRole { Name = "Admin" });

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new AppRole { Name = "User" });
            var userStore = new UserStore<AppUser>(context);
            var userManager = new UserManager<AppUser>(userStore);

            if (userManager.FindByName("Admin") == null)
            {
                userManager.Create(new AppUser
                {
                    Email = "admin@admin.com",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin"
                }, "qwe123");

                var userId = userManager.FindByName("admin").Id;

                userManager.AddToRole(userId, "Admin");
            }

            if (HttpContext.GetOwinContext().Authentication.User.Identity.IsAuthenticated && HttpContext.GetOwinContext().Authentication.User.IsInRole("Admin"))
                return RedirectToAction("Index", "Admin");

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVm data)
        {
            if (ModelState.IsValid)
            {
                var context = new AppDbContext();
                var userStore = new UserStore<AppUser>(context);
                var userManager = new UserManager<AppUser>(userStore);

                var user = userManager.FindByName(data.UserName);
                if (user != null)
                {
                    if (userManager.CheckPassword(user, data.Password))
                    {
                        var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        HttpContext.GetOwinContext().Authentication.SignIn(
                            new AuthenticationProperties
                            {
                                IsPersistent = true
                            }, identity);
                        return RedirectToAction("RedirectPage");
                    }
                    else
                    {
                        return Redirect("#");
                    }
                }
            }
            return View();
        }


        public ActionResult RedirectPage()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.IsInRole("User"))
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }


        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/account/login");
        }

        public ActionResult Profile()
        {
            ProfileVm profileVm = new ProfileVm
            {
                User = unitOfWork.Membership.Users.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault(),
                AllDemands = unitOfWork.Demands.Get().Count,
                CompletedDemands = unitOfWork.Demands.Get(x => x.ResultDemand.isFinished == true).Count,
                UncompletedDemands = unitOfWork.Demands.Get(x=> x.ResultDemand.isFinished == false).Count
            };
            return View(profileVm);
        }

        public ActionResult EditProfile(string userId)
        {
            var user = unitOfWork.Membership.Users.FindById(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(AppUser appUser, string userId)
        {
            var user = unitOfWork.Membership.Users.FindById(userId);
            if (ModelState.IsValid)
            {
                user.PhoneNumber = appUser.PhoneNumber;
                user.Email = appUser.Email;

                unitOfWork.Membership.Users.Update(user);
                return RedirectToAction("Profile", "Account");
            }
            return View(user);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVm data)
        {
            var userId = User.Identity.GetUserId();
            var appUser = unitOfWork.Membership.Users.FindById(userId);
            if (unitOfWork.Membership.Users.CheckPassword(appUser, data.Password))
            {
                if (data.NewPassword==data.NewPasswordConfirm)
                {
                    unitOfWork.Membership.Users.ChangePassword(userId, data.Password, data.NewPassword);
                }
            }
            return RedirectToAction("Profile", "Account");
        }
    }
}