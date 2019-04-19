using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DemoCore.Entity;
using DemoCore.IRepositories;
using EntityFrameworkCoreOracle.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EntityFrameworkCoreOracle
{
    public class EntityFrameworkModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IRepository<Customer>>()
            //    .ImplementedBy<Repository<Customer>>().LifestyleTransient());
            //註冊基本倉儲
            //AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(a => a.GetTypes().Where(t => t.BaseType == typeof(Entity)))
            //    .ToList().ForEach(item =>
            //    container.Register(
            //        Component.For<IRepository<item>>()
            //        .ImplementedBy<Repository<item>>().LifestyleTransient())
            //    );

            var kk = container.Register(Component.For(typeof(IRepository<>))
                .ImplementedBy(typeof(Repository<>)).LifeStyle.Transient);
            //container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly()).BasedOn<ITest>()
            //    .LifestyleTransient());
            //var kk = container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly()).Where(t => t.BaseType == typeof(ITest)).LifestyleTransient()) ;
            //var kk = Classes.FromAssembly(Assembly.GetExecutingAssembly()).BasedOn<IMyRepository>();
            //kk = container.Register(Component.For<ITest>()
            //    .ImplementedBy<Test>().LifestyleTransient());
            container.Register(Component.For<DbContext>().Instance(new DemoDbContextFactory().CreateDbContext()).LifestyleSingleton());
            kk = container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
                .BasedOn<ITransientDependency>()
                .WithService.DefaultInterfaces()
                .LifestyleTransient()
                );
        }
    }
}
