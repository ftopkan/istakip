using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.DAL.Context;
using Project.DAL.Repositories;
using Project.DAL.Repositories.UnitOfWork;
using Project.Entities.Models;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyDemands()
        {
            var userId = User.Identity.GetUserId();
            var demand = UnitOfWork.Demands.Get(x=>x.UserId==userId);
            return View(demand);
        }
        public ActionResult TakeDemand(int demandId)
        {
            var demand = UnitOfWork.Demands.GetById(demandId);
            demand.UserId = User.Identity.GetUserId();
            UnitOfWork.Demands.Update(demand);
            UnitOfWork.Save();
            return RedirectToAction("MyDemands", "User");
        }
        public JsonResult SendDemand(int demandId, bool isFinished,string message)
        {
            var resultDemand = new ResultDemand();
            resultDemand.ResultDemandId = demandId;
            resultDemand.isFinished = isFinished;
            resultDemand.EndDate = DateTime.Now;
            resultDemand.Message = message;
            UnitOfWork.ResultDemands.Insert(resultDemand);
            UnitOfWork.Save();
            return Json(1);
        }
    }
}