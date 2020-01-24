using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UserManager.API.Extensions;
using UserManager.Repository;
using UserManager.Repository.Implementation;
using UserManager.Repository.Interface;

namespace UserManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<UserManagerDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("UserManagerDb"),
                                            opt => opt.MigrationsAssembly("UserManager.Repository")));

            services.AddScoped<Application.UserManager>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSwaggerDocument(options =>
                  options.Title = "User Manager API"
                );

            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {          
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                       
            app.UseDbMigration();

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
