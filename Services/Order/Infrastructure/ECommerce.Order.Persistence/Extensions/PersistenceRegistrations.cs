using ECommerce.Order.Application.Features.CQRS.Handlers;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistence.Concrete;
using ECommerce.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Persistence.Extensions
{
    public static class PersistenceRegistrations
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
