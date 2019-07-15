using Microsoft.AspNet.Identity;
using Project.DAL.Repositories.UnitOfWork;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class OrderController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            var orders = unitOfWork.Orders.Get();
            return View(orders);
        }
        public ActionResult Create()
        {
            ViewBag.Packages = unitOfWork.Packages.Get();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                var user = unitOfWork.Membership.Users.FindByName(User.Identity.Name);
                order.CreatedById = user.Id;
                unitOfWork.Orders.Insert(order);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Packages = unitOfWork.Packages.Get();

            return View(order);
        }

        public ActionResult Edit(int orderId)
        {
            var order = unitOfWork.Orders.GetById(orderId);
            ViewBag.Packages = unitOfWork.Packages.Get();
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Orders.Update(order);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Packages = unitOfWork.Packages.Get();
            return View(order);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}