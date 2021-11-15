using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Infrastructure
{
    public class ShoppingContext : IdentityDbContext<AppUser> //CmsShoppingCartContext=>ShoppingContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            :base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
