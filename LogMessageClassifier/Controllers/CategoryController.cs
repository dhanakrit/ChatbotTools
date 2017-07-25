using ChatLogContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogMessageClassifier.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (var db = new ChatLogDataContext())
            {
                // List all the categories
                var categories = db.Categories.ToList();

                return View(categories);
            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        
        public ActionResult Create(string categoryname)
        {
            using (var db = new ChatLogDataContext())
            {
                // Check if the same name exists
                var exists = db.Categories.Any(c => c.CategoryName == categoryname.Trim());

                if(!exists)
                {
                    db.Categories.InsertOnSubmit(new Category { CategoryName = categoryname, ModifiedDate = DateTime.Now });
                    db.SubmitChanges();
                }

                return RedirectToAction("Index");
            }
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (var db = new ChatLogDataContext())
                {
                    // Check if the same name exists
                    var exists = db.Categories.Any(c => c.CategoryName == collection["categoryname"].Trim());

                    if (!exists)
                    {
                        db.Categories.InsertOnSubmit(new Category() { CategoryName = collection["categoryname"], ModifiedDate = DateTime.Now });
                        db.SubmitChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new ChatLogDataContext())
            {
                // Find the specific item by ID
                var item = db.Categories.SingleOrDefault(c => c.Id == id);

                if (item != null)
                {
                    db.Categories.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }

                return RedirectToAction("Index");
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
