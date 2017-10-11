using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using CicekSepeti.Model;
using CicekSepeti.Repository;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BouquetRepositoryTests
    {
        private DbConnection _connection;
        private CicekSepetiDbContextTest _databaseContext;
        private List<Bouquet> _listBouquet;
        private List<BouquetSize> _listBouquetSize;
        private List<FlowersInBouquet> _listFlowersInBouquet;
        private BouquetRepository _objRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _connection = DbConnectionFactory.CreateTransient();
            _databaseContext = new CicekSepetiDbContextTest(_connection);
            _objRepo = new BouquetRepository(_databaseContext);

            _listBouquet = new List<Bouquet>
            {
                new Bouquet {Id = 1, Name = "Sihirli Güller"},
                new Bouquet {Id = 2, Name = "Papatya Rüyası"},
                new Bouquet {Id = 3, Name = "Orkide Aşkı"}
            };
            _listBouquetSize = new List<BouquetSize>
            {
                new BouquetSize {Id = 1, BouquetId = 1, Price = 10, SizeId = 0, Bouquet = _listBouquet[0]},
                new BouquetSize {Id = 2, BouquetId = 1, Price = 15, SizeId = 1, Bouquet = _listBouquet[0]},
                new BouquetSize {Id = 3, BouquetId = 1, Price = 20, SizeId = 2, Bouquet = _listBouquet[0]}
            };
            _listFlowersInBouquet = new List<FlowersInBouquet>
            {
                new FlowersInBouquet
                {
                    BouquetSizeId = 1,
                    BouquetSize = _listBouquetSize[0],
                    Flower = new Flower {Id = 1, Name = "Gül"},
                    FlowerCount = 10,
                    FlowerId = 1,
                    Id = 0
                },
                new FlowersInBouquet
                {
                    BouquetSizeId = 1,
                    BouquetSize = _listBouquetSize[0],
                    Flower = new Flower {Id = 2, Name = "Papatya"},
                    FlowerCount = 25,
                    FlowerId = 2,
                    Id = 1
                },
                new FlowersInBouquet
                {
                    BouquetSizeId = 1,
                    BouquetSize = _listBouquetSize[0],
                    Flower = new Flower {Id = 3, Name = "Orkide"},
                    FlowerCount = 50,
                    FlowerId = 3,
                    Id = 2
                }
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void GetAll()
        {
//Act
            var result = _objRepo.GetAll().ToList();
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Sihirli Güller", result[0].Name);
            Assert.AreEqual("Papatya Rüyası", result[1].Name);
            Assert.AreEqual("Orkide Aşkı", result[2].Name);
        }

        private BouquetRepository CreateBouquetRepository()
        {
            return new BouquetRepository(_databaseContext);
        }
    }
}