using DataAccessLayer.DbContext1;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using DataAccessLayer.Interfaces.IEFRepos;
using DataAccessLayer.repos.EntityRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLogicLayer.services;
using BusinessLogicLayer.Interfaces.services;
using AutoMapper;
using BusinessLogicLayer.DTO;
using FluentValidation.AspNetCore;
using BusinessLogicLayer.validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Razor;

namespace University
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
            
            services.AddDbContext<MyDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("UniverCSharp"));
            });
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Group, GroupDTO>().ReverseMap();
            }, typeof(Startup));


            services.AddTransient<IEFGroupRepo, EFGroupRepo>();
            services.AddTransient<IEFStudentRepo, EFStudentRepo>();

            services.AddTransient<IUnitOfWork, EFUnitOfWork>();

            services.AddTransient<IEFGroupService, EFGroupService>();
            services.AddTransient<IEFStudentService, EFStudentService>();
            services.AddTransient<IValidator<StudentDTO>, StudentValidator>();
            services.AddTransient<IValidator<GroupDTO>, GroupValidator>();
        //    services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllersWithViews();

            services.Configure<RazorViewEngineOptions>(o =>
            {
                // {2} is area, {1} is controller,{0} is the action    
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("UI/Pages/{0}" + RazorViewEngine.ViewExtension);
            });       
    
        services.AddControllersWithViews();
            services.AddMvc(setup => {
                
            }).AddFluentValidation();


        }

        
         
         

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();//

            app.UseRouting();
            //app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();
                endpoints.MapBlazorHub();
                endpoints.MapRazorPages();
            });
        }
    }
}
