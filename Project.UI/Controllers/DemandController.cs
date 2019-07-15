using Project.DAL.Repositories.UnitOfWork;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class DemandController : Controller
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();
        // GET: Demand
        public ActionResult Index()
        {
            var demand = UnitOfWork.Demands.Get(x=>x.User.UserName!=User.Identity.Name);
            return View(demand);
        }

        public ActionResult Create()
        {
            var users = UnitOfWork.Membership.Users.Users.Where(x=>x.UserName!=User.Identity.Name).ToList();
            ViewBag.UserList = users;
          
            return View();  
        }

        [HttpPost]
        public ActionResult Create(Demand demand)
        {
            if (ModelState.IsValid)
            {
              
                UnitOfWork.Demands.Insert(demand);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
          
            return View();
        }

        public ActionResult Edit(int demandId)
        {
            var demand = UnitOfWork.Demands.GetById(demandId);
            ViewBag.UserList = UnitOfWork.Membership.Users.Users.Where(x => x.UserName != User.Identity.Name).ToList();
            return View(demand);
        }

        [HttpPost]
        public ActionResult Edit(Demand demand,int demandId)
        {
            if (ModelState.IsValid)
            {
                var model = UnitOfWork.Demands.GetById(demandId);
                model.Title = demand.Title;
                model.Description = demand.Description;
                model.UserId = demand.UserId;
                UnitOfWork.Demands.Update(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
                return View();
           
        }
        public ActionResult Delete( int demandId)
        {
            UnitOfWork.ResultDemands.Delete(demandId);
            UnitOfWork.Demands.Delete(demandId);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult GetDemandByUserId(string userId)
        {
            var demands = UnitOfWork.Demands.Get(x => x.UserId == userId).ToList();
            return View(demands);
        }

        public ActionResult Result(string userId)
        {
            var resultDemands = UnitOfWork.ResultDemands.Get(x => x.Demand.UserId==userId).ToList();
            return View(resultDemands);
        }
    }
}