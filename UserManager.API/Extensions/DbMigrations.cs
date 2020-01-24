using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Repository;
using UserManager.Repository.SampleData;

namespace UserManager.API.Extensions
{
    public static class DbMigrationExtensions
    {
        public static void UseDbMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<UserManagerDbContext>();
                dbContext.Database.Migrate();
                dbContext.InitializeData();
            }
        }
    }
}
