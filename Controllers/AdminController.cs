using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetShopCore.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AddGroupCategory()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            ViewBag.GroupCategoryList = db.GroupCategories.ToList();
            return View();
        }
    }
}
