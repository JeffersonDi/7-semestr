using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly ShoppingContext context;//ProductsController
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarsController(ShoppingContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        //GET /admin/cars
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 6;
            var cars = context.Cars.OrderByDescending(x => x.Id).Include(x => x.Category).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Cars.Count() / pageSize);

            return View(await cars.ToListAsync());
        }

        //GET /admin/cars/create
        public IActionResult Create() 
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");

            return View();
        }

        //POST /admin/cars/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");

            if (ModelState.IsValid)
            {
                car.Slug = car.Name.ToLower().Replace(" ", "-");
                //car.Sorting = 100;

                var slug = await context.Cars.FirstOrDefaultAsync(x => x.Slug == car.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Эта позиция уже существует.");
                    return View(car);
                }

                string imageName = "noimage.png";
                if(car.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "media/cars");
                    imageName = Guid.NewGuid().ToString() + "_" + car.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await car.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }

                car.Image = imageName;

                context.Add(car);
                await context.SaveChangesAsync();

                TempData["Success"] = "Запись успешно добавлена!";

                return RedirectToAction("Index");
            }

            return View(car);
        }
    }
}
