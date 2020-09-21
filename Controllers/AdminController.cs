using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetShopCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetShopCore.Controllers
{
    public class AdminController : Controller
    {
        private ShopContext db;

        public AdminController(ShopContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Добавление данных

        [HttpGet]
        public IActionResult AddGroupCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGroupCategory([FromForm] GroupCategory groupCategory)
        {
            if (ModelState.IsValid)
            {
                db.GroupCategories.Add(groupCategory);
                await db.SaveChangesAsync();
                TempData["success"] = "Запись успешно добавлена";
            }

            return RedirectToAction("AddGroupCategory");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var categoryList = db.GroupCategories.ToList();
            ViewBag.GroupCategoryList = new SelectList(categoryList, "GroupCategoryId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                TempData["success"] = "Запись успешно добавлена";
            }

            return RedirectToAction("AddCategory");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var categoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categoryList, "GroupCategoryId", "Name");

            var manufacturerList = db.Manufacturers.ToList();
            ViewBag.ManufacturerList = new SelectList(manufacturerList, "ManufacturerId", "Name");

            return View();
        }

        #endregion

        #region Справочники

        public IActionResult GroupCategories()
        {
            var categoryList = db.GroupCategories.ToList();

            return View(categoryList);
        }

        #endregion
    }
}
