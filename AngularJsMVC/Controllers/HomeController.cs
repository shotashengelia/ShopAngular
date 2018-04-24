using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJsMVC.Models;

namespace AngularJsMVC.Controllers
{
    public class HomeController : Controller
    {

        TestEntities db = new TestEntities();

        //void CheckConnection() 
        //{
        //  if (db == null)
        //    {
        //        db = new TestEntities();
        //    }
        //}


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Product()
        {
            var GetCategory = db.Categories.ToList();
            GetCategory.Insert(0, new Category { id = 0, name = "აირჩიეთ კატეგორია" });
            ViewBag.GetCategory = GetCategory;
            ViewBag.SelectCategoryType = 0;

            return View();
        }
        [HttpPost]
        public JsonResult InsertProduct(ProductModel PM)
        {
            string result = string.Empty;
            bool success = false;
            try
            {
                var GetCategory = db.Categories.ToList();
                GetCategory.Insert(0, new Category { id = 0, name = "აირჩიეთ კატეგორია" });
                ViewBag.GetCategory = GetCategory;
                ViewBag.SelectCategoryType = 0;
                db.insertproducts(PM.Name, PM.Price, PM.Amount, PM.CategoryId);
                success = true;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(new { result, success }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Category()
        {
            //CheckConnection();


            return View();
        }
        [HttpPost]
        public JsonResult InsertCategory(string name)
        {
            string result = string.Empty;
            bool success = false;
            try
            {
                Category newCategory = new Category { name = name };
                db.Categories.Add(newCategory);
                db.SaveChanges();
                //db.InsertCategory(name);
                //data.AddCategory(name);
                success = true;
                result = "კატეგორია შეინახა წარმატებით!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(new { result, success }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCategories() 
        {
            
            List<Category> Ct = db.Categories.ToList();
            return Json(Ct);
        }
    }
}
