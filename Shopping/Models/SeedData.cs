using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShoppingContext(serviceProvider.GetRequiredService<DbContextOptions<ShoppingContext>>()))
            {
                if(context.Pages.Any())
                {
                    return;
                }

                context.Pages.AddRange(
                    new Page 
                    { 
                        Title="Домашняя страница",
                        Slug = "home",
                        Content="Домашняя страница",
                        Sorting=0
                    },
                    new Page
                    {
                        Title = "О Нас",
                        Slug = "about-us",
                        Content = "Страница о Нас",
                        Sorting = 100
                    },
                    new Page
                    {
                        Title = "Услуги",
                        Slug = "services",
                        Content = "Страница услуги",
                        Sorting = 100
                    },
                    new Page
                    {
                        Title = "Контакты",
                        Slug = "contact",
                        Content = "Страница контакты",
                        Sorting = 100
                    }
                );
                context.SaveChanges();

            }
        }
    }
}
