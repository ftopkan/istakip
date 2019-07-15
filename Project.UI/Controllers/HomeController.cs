using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.DAL.Context;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
      //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {        
            return View();
        }
    }
}