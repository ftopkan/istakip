using Project.DAL.Repositories.UnitOfWork;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            var products = unitOfWork.Products.Get();

            return View(products);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            unitOfWork.Products.Insert(product);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int productId)
        {
            var product = unitOfWork.Products.GetById(productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, int productId)
        {
            var productEdit = unitOfWork.Products.GetById(productId);
            productEdit.ProductName = product.ProductName;
            productEdit.ProductPrice = product.ProductPrice;
            unitOfWork.Products.Update(productEdit);
            unitOfWork.Save();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Delete(int productId)
        {
            unitOfWork.Products.Delete(productId);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}