using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CicekSepeti.Model;

namespace Test
{
    public class CicekSepetiDbContextTest : DbContext
    {
        public CicekSepetiDbContextTest()
            : base("Name=CicekSepetiDbContextTest")
        {
        }

        public CicekSepetiDbContextTest(bool enableLazyLoading, bool enableProxyCreation)
            : base("Name=CicekSepetiDbContextTest")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }

        public CicekSepetiDbContextTest(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<BouquetSize> BouquetSizes { get; set; }
        public DbSet<FlowersInBouquet> FlowersInBouquets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check         
            Database.SetInitializer(new AlwaysCreateInitializer());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(CicekSepetiDbContextTest context)
        {
            var listFlowers = new List<Flower>
            {
                new Flower {Id = 1, Name = "Gül"},
                new Flower {Id = 2, Name = "Papatya"},
                new Flower {Id = 3, Name = "Orkide"}
            };
            context.Flowers.AddRange(listFlowers);
            var listBouquets = new List<Bouquet>
            {
                new Bouquet {Id = 1, Name = "Sihirli Güller"},
                new Bouquet {Id = 2, Name = "Papatya Rüyası"},
                new Bouquet {Id = 3, Name = "Orkide Aşkı"}
            };
            context.Bouquets.AddRange(listBouquets);

            var listBouquetSize = new List<BouquetSize>
            {
                new BouquetSize {Id = 1, BouquetId = 1, Price = 10, SizeId = 0, Bouquet = listBouquets[0]},
                new BouquetSize {Id = 2, BouquetId = 1, Price = 15, SizeId = 1, Bouquet = listBouquets[0]},
                new BouquetSize {Id = 3, BouquetId = 1, Price = 20, SizeId = 2, Bouquet = listBouquets[0]}
            };
            context.BouquetSizes.AddRange(listBouquetSize);

            var listFlowersInBouquet = new List<FlowersInBouquet>
            {
                new FlowersInBouquet
                {
                    BouquetSizeId = 1,
                    BouquetSize = listBouquetSize[0],
                    Flower = new Flower {Id = 1, Name = "Gül"},
                    FlowerCount = 10,
                    FlowerId = 1,
                    Id = 0
                },
                new FlowersInBouquet
                {
                    BouquetSizeId = 1,
                    BouquetSize = listBouquetSize[0],
                    Flower = new Flower {Id = 2, Name = "Papatya"},
                    FlowerCount = 25,
                    FlowerId = 2,
                    Id = 1
                },
                new FlowersInBouquet
                {
                    BouquetSizeId = 1,
                    BouquetSize = listBouquetSize[0],
                    Flower = new Flower {Id = 3, Name = "Orkide"},
                    FlowerCount = 50,
                    FlowerId = 3,
                    Id = 2
                }
            };
            context.FlowersInBouquets.AddRange(listFlowersInBouquet);
            context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<CicekSepetiDbContextTest>
        {
            protected override void Seed(CicekSepetiDbContextTest context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<CicekSepetiDbContextTest>
        {
            protected override void Seed(CicekSepetiDbContextTest context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<CicekSepetiDbContextTest>
        {
            protected override void Seed(CicekSepetiDbContextTest context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}