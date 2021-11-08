using Microsoft.AspNetCore.Mvc;
using Shopping.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly ShoppingContext context;//ProductsController

        public CarsController(ShoppingContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
