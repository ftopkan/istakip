using Project.DAL.Repositories.UnitOfWork;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class PackageController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var packages = unitOfWork.Packages.Get();
            return View(packages);
        }

        public ActionResult CreatePackage()
        {
            var model = unitOfWork.Products.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePackage(string packageName, string packagePrice, int[] productIds)
        {
            if (ModelState.IsValid)
            {
                var package = new Package();
                package.PackageName = packageName;
                package.PackagePrice = Convert.ToDecimal(packagePrice);
                package.PackageKey = Guid.NewGuid().ToString();
                unitOfWork.Packages.Insert(package);
                unitOfWork.Save();
                var packageId = unitOfWork.Packages.Get(x => x.PackageKey == package.PackageKey).FirstOrDefault().PackageId;

                for (int i = 0; i < productIds.Length; i++)
                {
                    var packageProduct = new PackageProduct();
                    packageProduct.PackageId = packageId;
                    packageProduct.ProductId = productIds[i];
                    unitOfWork.PackageProducts.Insert(packageProduct);
                }
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeletePackage(int packageId)
        {
            unitOfWork.Packages.Delete(packageId);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}