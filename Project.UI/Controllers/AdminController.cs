using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.DAL.Context;
using Project.DAL.Repositories;
using Project.DAL.Repositories.UnitOfWork;
using Project.Entities.Models;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class AdminController : Controller
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult ListUser()
        {
            var users = UnitOfWork.Membership.Users.Users.Where(x=>x.UserName!=User.Identity.Name).ToList();
            return View(users);
        }
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(SignUpVm data)
        {
            if (ModelState.IsValid)
            {

                var context = new AppDbContext();
                var userStore = new UserStore<AppUser>(context);
                var userManager = new UserManager<AppUser>(userStore);

                if (data.Password==data.ConfirmPassword)
                {  
                    userManager.Create(new AppUser
                    {
                        Email = data.Email,
                        UserName = data.Email,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        PhoneNumber = data.PhoneNumber,
                        Title = data.Title            
                    }, data.Password);

                    var user = userManager.FindByName(data.Email);

                    userManager.AddToRole(user.Id, "User");

                    return RedirectToAction("ListUser", "Admin");
                }
                else
                {
                    ViewBag.Error = "Şifreler Uyuşmuyor.";
                    return View();
                }
                
            }

            return View();
        }

        public ActionResult EditUser(string userId)
        {
            var user = UnitOfWork.Membership.Users.FindById(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(AppUser appUser,string userId)
        {
            var user = UnitOfWork.Membership.Users.FindById(userId);
          if (ModelState.IsValid)
            {     
                user.FirstName = appUser.FirstName;
                user.LastName = appUser.LastName;
                user.PhoneNumber = appUser.PhoneNumber;
                user.Email = appUser.Email;
                user.Title = appUser.Title;

                UnitOfWork.Membership.Users.Update(user);
                return RedirectToAction("ListUser");
            }

            return View(user);
        }

        public ActionResult DeleteUser(string userId)
        {
            var user = UnitOfWork.Membership.Users.FindById(userId);
            UnitOfWork.Membership.Users.Delete(user);
            return RedirectToAction("ListUser");
        }
    }
}