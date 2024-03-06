using Microsoft.AspNetCore.Mvc;
using to_do.Data;
using to_do.Models;
//using System.Collections.Generic;

namespace to_do.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
          //  var objectllist = _db.CATEGORIES.ToList();
            IEnumerable<Category> categories = _db.CATEGORIES;
            return View(categories);
        }
        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
            }
            if(ModelState.IsValid)
            {
                _db.CATEGORIES.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
                //return RedirectToAction("Index" ,"Home"); <= to go into index method of home controller
            }
            return View(obj);

        }

        //get
        public IActionResult Edit(int? Id)
        {
            throw new Exception("Error in Details View");

            if(Id==null || Id == 0)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id.Value);
               // return NotFound();
            }
            var categoryFromDb = _db.CATEGORIES.Find(Id);

            if(categoryFromDb == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id.Value);

               
            }

            return View(categoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name","the DisplayOrder can not exactly match the name");
            }

            if(ModelState.IsValid)
            {
                _db.CATEGORIES.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
            
        }

        //get
        public IActionResult Delete(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.CATEGORIES.Find(Id);
            return View(categoryFromDb);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int ? Id)
        {
            var obj = _db.CATEGORIES.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.CATEGORIES.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
