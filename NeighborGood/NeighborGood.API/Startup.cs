using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeighborGood.API.Services;
using NeighborGood.API.Services.Interfaces;
using NeighborGood.API.Validation;
using NeighborGood.Models.DTOs.Requests;
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
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<GeoLocation>();

            services.AddDbContext<NeighborGoodContext>(opts => opts.UseSqlServer(Configuration["DockerSQLServerConnectionString"])
                                                                 .UseLazyLoadingProxies());

            services.AddIdentity<User, Role>()
               .AddUserManager<UserManager<User>>()
               .AddRoleManager<RoleManager<Role>>()
               .AddSignInManager<SignInManager<User>>()
               .AddEntityFrameworkStores<NeighborGoodContext>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<IAnnouncementRepository<UserRegisterRequest, AnnouncementFilter>, AnnouncementRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterUserRequestValidator>()
                .RegisterValidatorsFromAssemblyContaining<LoginValidator>());
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NeighborGood API");
            });

            app.UseRouting();
            app.UseCors("CORS");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<NeighborGoodContext>();
                if (context.Database.CanConnect())
                {
                    context.Database.GetPendingMigrationsAsync();
                }
            }
        }
    }
}