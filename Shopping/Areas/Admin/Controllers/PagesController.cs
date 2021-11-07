﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly ShoppingContext context;

        public PagesController(ShoppingContext context)
        {
            this.context = context;
        }

        //GET /admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        //GET /admin/pages/details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if(page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        //GET /admin/pages/create
        public IActionResult Create() => View();

        //POST /admin/pages/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if(slug != null)
                {
                    ModelState.AddModelError("", "Этот заголовок уже существует.");
                    return View(page);
                }

                context.Add(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "Запись успешно добавлена!";

                return RedirectToAction("Index");
            }

            return View(page);
        }

        //GET /admin/pages/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        //POST /admin/pages/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");

                var slug = await context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Этот заголовок уже существует.");
                    return View(page);
                }

                context.Update(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "Запись успешно добавлена!";

                return RedirectToAction("Edit", new { id = page.Id });
            }

            return View(page);
        }

        //GET /admin/pages/delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                TempData["Error"] = "Страница не существует!";
            }
            else
            {
                context.Pages.Remove(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "Запись успешно удалена!";
            }

            return RedirectToAction("Index");
        }
    }
}