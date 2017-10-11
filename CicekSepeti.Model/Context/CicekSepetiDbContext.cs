using System.Data.Entity;

namespace CicekSepeti.Model.Context
{
    //The definition of db context for our project
    public class CicekSepetiDbContext : DbContext
    {
        public CicekSepetiDbContext() : base("name=CicekSepetiDbContext")
        {
        }

        //Add the following models to the db context to create tables using entity framework code first
        public DbSet<Flower> Flowers { get; set; }

        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<BouquetSize> BouquetSizes { get; set; }
        public DbSet<FlowersInBouquet> FlowersInBouquets { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //We can add other constraints to the tables in the database
        }

        //We can comment out the following code to add created date, modified date, createdby and modifiedby columns to our tables
        //(We also need to add IAuditableEntity as base class for the models of tabled we want to add)

        //public override int SaveChanges()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IAuditableEntity
        //                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));
        //    foreach (var entry in modifiedEntries)
        //    {
        //        if (entry.Entity is IAuditableEntity entity)
        //        {
        //            string identityName = Thread.CurrentPrincipal.Identity.Name;
        //            DateTime now = DateTime.UtcNow;
        //            if (entry.State == System.Data.Entity.EntityState.Added)
        //            {
        //                entity.CreatedBy = identityName;
        //                entity.CreatedDate = now;
        //            }
        //            else
        //            {
        //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //            }
        //            entity.UpdatedBy = identityName;
        //            entity.UpdatedDate = now;
        //        }
        //    }
        //    return base.SaveChanges();
        //}
    }
}