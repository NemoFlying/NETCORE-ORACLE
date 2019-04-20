using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Castle.MicroKernel.Registration;
using EntityFrameworkCoreOracle;
using Microsoft.EntityFrameworkCore;
using DemoCore.IRepositories;
using EntityFrameworkCoreOracle.Repositories;
using EntityFrameworkCoreOracle.DbInitial;

namespace DemoWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var kk = Configuration["ConnectionStrings:Default"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DemoDbContext>(option=> {
                option.UseOracle(Configuration["ConnectionStrings:Default"]);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IMyRepository, MyRepository>();

            services.AddSingleton(Configuration);

            //var kk = services.Reverse<DemoDbContext>();
            var ioContainer = new WindsorContainer();

            //自定义配置
            //将配置文件装入IOC[windsor]中
            //ioContainer.Register(Component.For<IConfiguration>()
            //    .Instance(Configuration).LifestyleSingleton());

            //注入连接Dbcontext
            ioContainer.Register(Component.For<DbContext>()
                .Instance(services.BuildServiceProvider().GetService<DemoDbContext>()));

            //载入 EntityFrameworkCoreOracle 模块
            ioContainer.Install(FromAssembly.Named("EntityFrameworkCoreOracle"));

            return WindsorRegistrationHelper.CreateServiceProvider(ioContainer, services);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitailDemo.InitDb(app.ApplicationServices.GetService<DemoDbContext>());
        }
    }
}
