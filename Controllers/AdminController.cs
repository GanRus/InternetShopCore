using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetShopCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        #region Справочники

        public IActionResult GroupCategories()
        {
            var categoryList = db.GroupCategories.ToList();

            return View(categoryList);
        }

        public IActionResult Categories()
        {
            var categoryList = db.Categories.Include(c => c.GroupCategory).ToList();

            return View(categoryList);
        }

        #endregion

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
            ViewBag.GroupCategoryList = GetCategoryList();

            return View();
        }

        private SelectList GetCategoryList()
        {
            var categoryList = db.GroupCategories.ToList();

            return new SelectList(categoryList, "GroupCategoryId", "Name");
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

        #region Редактирование данных

        [HttpGet]
        public async Task<IActionResult> EditGroupCategory(int? id)
        {
            if (id != null)
            {
                var groupCategory = await db.GroupCategories.FirstOrDefaultAsync(p => p.GroupCategoryId == id);

                if (groupCategory != null)
                    return View(groupCategory);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditGroupCategory([FromForm] GroupCategory groupCategory)
        {
            db.GroupCategories.Update(groupCategory);
            await db.SaveChangesAsync();

            return RedirectToAction("GroupCategories");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id != null)
            {
                var category = await db.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);

                ViewBag.GroupCategoryList = GetCategoryList();

                if (category != null)
                    return View(category);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory([FromForm] Category category)
        {
            db.Categories.Update(category);
            await db.SaveChangesAsync();

            return RedirectToAction("Categories");
        }

        #endregion

        #region Удаление данных

        [HttpGet]
        public async Task<IActionResult> DeleteGroupCategory(int? id)
        {
            if (id != null)
            {
                var groupCategory = await db.GroupCategories.FirstOrDefaultAsync(p => p.GroupCategoryId == id);

                if (groupCategory != null)
                {
                    //перед удалением делаем проверку на наличие связанных записей в таблице категорий
                    var category = await db.Categories.FirstOrDefaultAsync(p => p.GroupCategoryId == groupCategory.GroupCategoryId);

                    if (category != null)
                    {
                        TempData["error"] = "Невозможно удалить запись, так как имеются связанные записи в таблице категорий";
                        return RedirectToAction("GroupCategories");
                    }

                    db.GroupCategories.Remove(groupCategory);
                    await db.SaveChangesAsync();

                    TempData["success"] = "Запись успешно удалена";
                }

                return RedirectToAction("GroupCategories");
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id != null)
            {
                var category = await db.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);

                if (category != null)
                {
                    //перед удалением делаем проверку на наличие связанных записей в таблице категорий
                    var product = await db.Products.FirstOrDefaultAsync(p => p.CategoryId == category.CategoryId);

                    if (product != null)
                    {
                        TempData["error"] = "Невозможно удалить запись, так как имеются связанные записи в таблице продуктов";
                        return RedirectToAction("Categories");
                    }

                    db.Categories.Remove(category);
                    await db.SaveChangesAsync();

                    TempData["success"] = "Запись успешно удалена";
                }

                return RedirectToAction("Categories");
            }

            return NotFound();
        }
        #endregion

    }
}
