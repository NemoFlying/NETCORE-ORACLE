using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DemoCore.Entity;
using DemoCore.IRepositories;
using EntityFrameworkCoreOracle.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreOracle
{
    public class EntityFrameworkModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRepository<Customer>>().ImplementedBy<Repository<Customer>>().LifestyleTransient());
        }
    }
}
