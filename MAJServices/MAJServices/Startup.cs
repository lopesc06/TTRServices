using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MAJServices.Entities;
using MAJServices.Services;
using MAJServices.Models;

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
            services.AddScoped<IDepartmentInfoRepository, DepartmentInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<User, UserWithoutPostsDto>();
                cfg.CreateMap<UserForCreationDto, User>();
                cfg.CreateMap<User, UserWithoutPostsDto>();
            });
            app.UseMvc();
        }
    }
}
