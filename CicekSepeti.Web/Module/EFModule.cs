using System.Data.Entity;
using Autofac;
using CicekSepeti.Model.Context;
using CicekSepeti.Repository;

namespace CicekSepeti.Web.Module
{
    //Autofac registiration for entity framework module
    public class EfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(CicekSepetiDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}