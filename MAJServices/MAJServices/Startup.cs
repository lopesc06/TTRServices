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

namespace MAJServices
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
            services.AddMvc();
            //var connectionString = @"Server=tcp:majdbserver.database.windows.net,1433;Initial Catalog=MAJDB;Persist Security Info=False;User ID=ArturoEscutia;Password=Lopesc_06;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<InfoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IPostInfoRepository, PostInfoRepository>();
            services.AddScoped<IDepartmentInfoRepository, DepartmentInfoRepository>();

            services.AddIdentity<User, IdentityRole>()
                 .AddEntityFrameworkStores<InfoContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "yourdomain.com",
                     ValidAudience = "yourdomain.com",
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(Configuration["Llave_secreta"])),
                     ClockSkew = TimeSpan.Zero
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<InfoContext>();
                context.Database.Migrate();
            }
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
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<User, UserWithoutPostsDto>();
                cfg.CreateMap<UserForUpdateDto, User>();
                cfg.CreateMap<User, UserForUpdateDto>();
                cfg.CreateMap<UserForCreationDto, User>();
                cfg.CreateMap<User, UserWithoutPostsDto>();
                cfg.CreateMap<PostForCreationDto, Post>();
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<Post, PostForCreationDto>();
                cfg.CreateMap<PostForUpdateDto, Post>();
            });
            app.UseMvc();
        }
    }
}
