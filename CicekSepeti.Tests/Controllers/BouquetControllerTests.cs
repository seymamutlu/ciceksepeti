using CicekSepeti.Service;
using CicekSepeti.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Controllers
{
    [TestClass]
    public class BouquetControllerTests
    {
        private Mock<IBouquetService> mockBouquetService;
        private Mock<IFlowerService> mockFlowerService;
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockBouquetService = mockRepository.Create<IBouquetService>();
            mockFlowerService = mockRepository.Create<IFlowerService>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var bouquetController = CreateBouquetController();
        }

        private BouquetController CreateBouquetController()
        {
            return new BouquetController(
                mockBouquetService.Object,
                mockFlowerService.Object);
        }
    }
}