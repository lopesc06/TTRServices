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
using MAJServices.Services.Interfaces;
using MAJServices.Services.InterfacesImplementation;
using MAJServices.Models.User;
using MAJServices.Models.FirebaseCM;

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
            var connectionString = Environment.GetEnvironmentVariable("AzureDBString");
            //var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<InfoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IPostInfoRepository, PostInfoRepository>();
            services.AddScoped<IFileInfoRepository, FileInfoRepository>();
            services.AddScoped<IFirebaseCMInfoRepository,FirebaseCMInfoRepository>();
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
                     ValidIssuer = Environment.GetEnvironmentVariable("JwtIssuer"),
                     ValidAudience = Environment.GetEnvironmentVariable("JwtAudience"),
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Llave_secreta"))),
                     ClockSkew = TimeSpan.Zero
                 });
            services.AddAuthorization(options => {
                options.AddPolicy("Publishers", policy => policy.RequireAuthenticatedUser().RequireRole("SuperAdmin", "Admin","Subadmin"));
                options.AddPolicy("ElevatedPrivilages", policy => policy.RequireAuthenticatedUser().RequireRole("SuperAdmin", "Admin"));
                //options.AddPolicy("LowPrivilages", policy => policy.RequireAuthenticatedUser().RequireRole("Subadmin"));
                //options.AddPolicy("SuperUser", policy => policy.RequireAuthenticatedUser().RequireClaim("name", "Arturo"));
            });
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
            app.UseAuthentication();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserIdentity, UserDto>();
                cfg.CreateMap<UserIdentity, UserWithoutPostsDto>();
                cfg.CreateMap<UserForUpdateDto, UserIdentity>();
                cfg.CreateMap<UserIdentity, UserForUpdateDto>();
                cfg.CreateMap<UserForCreationDto, UserIdentity>();
                cfg.CreateMap<PostForCreationDto, Post>();
                cfg.CreateMap<Post, PostForCreationDto>();
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<Post, PostWithoutUserDto>();
                cfg.CreateMap<PostForUpdateDto, Post>();
                cfg.CreateMap<UserSubscriptionDto, UserSubscription>()
                   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                   .ForMember(dest => dest.DepartmentAcronym, opt => opt.MapFrom(src => src.DepartmentName));
                cfg.CreateMap<UserSubscription, UserSubscriptionDto>()
                   .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentAcronym))
                   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
                cfg.CreateMap<FirebaseCMForCreationDto, FirebaseCM>();
            });
            app.UseMvc();
        }
    }
}
