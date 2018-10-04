using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MAJServices.Entities;
using MAJServices.Services;
using MAJServices.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MAJServices.Seeds;

namespace MAJServices
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //var connectionString = Configuration["AzureDBString"];
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<InfoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IPostInfoRepository, PostInfoRepository>();
            services.AddScoped<IDepartmentInfoRepository, DepartmentInfoRepository>();

            services.AddIdentity<UserIdentity, RoleIdentity>()
                 .AddEntityFrameworkStores<InfoContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["JwtIssuer"],
                     ValidAudience = Configuration["JwtAudience"],
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(Configuration["Llave_secreta"])),
                     ClockSkew = TimeSpan.Zero
                 });
            services.AddAuthorization(options => {
                options.AddPolicy("ElevatedPrivilages", policy => policy.RequireAuthenticatedUser().RequireRole("SuperAdmin", "Admin"));
                options.AddPolicy("LowPrivilages", policy => policy.RequireAuthenticatedUser().RequireRole("Subadmin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<UserIdentity> userManager, RoleManager<RoleIdentity> roleManager)
        {
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<InfoContext>();
            //    context.Database.Migrate();
            //}
            MyIdentityDataInitializer.SeedData(userManager, roleManager);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();
            app.UseAuthentication();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserIdentity, UserDto>();
                cfg.CreateMap<UserIdentity, UserWithoutPostsDto>();
                cfg.CreateMap<UserForUpdateDto, UserIdentity>();
                cfg.CreateMap<UserIdentity, UserForUpdateDto>();
                cfg.CreateMap<UserForCreationDto, UserIdentity>();
                cfg.CreateMap<UserIdentity, UserWithoutPostsDto>();
                cfg.CreateMap<PostForCreationDto, Post>();
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<Post, PostForCreationDto>();
                cfg.CreateMap<PostForUpdateDto, Post>();
            });
            app.UseMvc();
        }
    }
}
