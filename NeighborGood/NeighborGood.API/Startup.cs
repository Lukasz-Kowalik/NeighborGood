using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeighborGood.API.Services;
using NeighborGood.API.Services.Interfaces;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL;
using NeighborGood.MSSQL.Repositories;

namespace NeighborGood.API
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
           
            //services.AddDbContext<NeighborGoodContext>(opts => opts.UseSqlServer(Configuration["DataBaseConnectionString"])
            //                                                     .UseLazyLoadingProxies());

            services.AddIdentity<User,IdentityRole>()
               .AddUserManager<UserManager<User>>()
               .AddSignInManager<SignInManager<User>>()
               .AddEntityFrameworkStores<NeighborGoodContext>()
               .AddDefaultTokenProviders();

            services.AddScoped<IUserService,UserService>();
            services.AddDbContext<NeighborGoodContext>(opts => opts.UseSqlServer(Configuration["DataBaseConnectionString"])
                                                                 .UseLazyLoadingProxies());
            
            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<IAnnouncementRepository<Announcement>, AnnouncementRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<NeighborGoodContext>();
                context.Database.EnsureCreated();
            }

            app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NeighborGood API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}