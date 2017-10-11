using System.Collections.Generic;
using CicekSepeti.Model;
using CicekSepeti.Repository;
using CicekSepeti.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class BouquetServiceTests
    {
        private List<Bouquet> _listBouquet;
        private List<BouquetSize> _listBouquetSize;
        private List<FlowersInBouquet> _listFlowersInBouquet;
        private Mock<IBouquetRepository> _mockBouquetRepository;
        private MockRepository _mockRepository;

        private Mock<IUnitOfWork> _mockUnitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockUnitOfWork = _mockRepository.Create<IUnitOfWork>();
            _mockBouquetRepository = _mockRepository.Create<IBouquetRepository>();
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

        [TestMethod]
        public void Bouquet_Get_All()
        {
            var service = CreateService();

            //Arrange
            _mockBouquetRepository.Setup(x => x.GetAll()).Returns(_listBouquet);
            //Act
            var results = service.GetAll() as List<Bouquet>;
            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        [TestCleanup]
        public void TestCleanup()
        {
            _mockRepository.VerifyAll();
        }

        private BouquetService CreateService()
        {
            return new BouquetService(
                _mockUnitOfWork.Object,
                _mockBouquetRepository.Object);
        }
    }
}