using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    //[Authorize]
    public class CarsController : Controller
    {
        private readonly ShoppingContext context;

        public CarsController(ShoppingContext context)
        {
            this.context = context;
        }

        //GET /cars
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 6;
            var cars = context.Cars.OrderByDescending(x => x.Id).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Cars.Count() / pageSize);

            return View(await cars.ToListAsync());
        }

        //GET /cars/category
        public async Task<IActionResult> CarsByCategory(string categorySlug, int p = 1)
        {
            Category category = await context.Categories.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();

            if (category == null) return RedirectToAction("Index");

            int pageSize = 6;
            var cars = context.Cars.OrderByDescending(x => x.Id)
                .Where(x => x.CategoryId == category.Id)
                .Skip((p - 1) * pageSize)
                .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Cars.Where(x => x.CategoryId == category.Id).Count() / pageSize);
            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = categorySlug;

            return View(await cars.ToListAsync());
        }
    }
}
