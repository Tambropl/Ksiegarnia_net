using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookShoppingCartMvcUI.Data;
using BookShoppingCartMvcUI.Models;
using System;
using System.Linq;

namespace BookShoppingCartMvcUI.Data
{
    public static class OrderStatusSeeder
    {
        public static void SeedOrderStatuses(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.OrderStatuses.Any())
                {
                    return;
                }

                var orderStatuses = new OrderStatus[]
                {
                    new OrderStatus { StatusId = 1, StatusName = "W trakcie realizacji" },
                    new OrderStatus { StatusId = 2, StatusName = "Wysłany" },
                    new OrderStatus { StatusId = 3, StatusName = "Dostarczony" },
                };

                context.OrderStatuses.AddRange(orderStatuses);
                context.SaveChanges();
            }
        }
    }
}
