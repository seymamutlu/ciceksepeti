using System.Collections.Generic;
using CicekSepeti.Model;
using CicekSepeti.Repository;
using CicekSepeti.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class FlowerServiceTests
    {
        private List<Flower> _listFlower;
        private Mock<IFlowerRepository> mockFlowerRepository;
        private MockRepository mockRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockUnitOfWork = mockRepository.Create<IUnitOfWork>();
            mockFlowerRepository = mockRepository.Create<IFlowerRepository>();
            _listFlower = new List<Flower>
            {
                new Flower {Id = 1, Name = "Gül", IsFlowering = true, IsLeafy = true, IsThorny = true},
                new Flower {Id = 2, Name = "Papatya", IsFlowering = true, IsThorny = false, IsLeafy = true},
                new Flower {Id = 3, Name = "Orkide", IsFlowering = true, IsThorny = false, IsLeafy = false}
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetAll()
        {
            var _service = CreateService();

            //Arrange
            mockFlowerRepository.Setup(x => x.GetAll()).Returns(_listFlower);
            //Act
            var results = _service.GetAll() as List<Flower>;
            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        private FlowerService CreateService()
        {
            return new FlowerService(
                mockUnitOfWork.Object,
                mockFlowerRepository.Object);
        }
    }
}