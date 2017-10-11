using CicekSepeti.Service;
using CicekSepeti.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Controllers
{
    [TestClass]
    public class HomeControllerTests
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
            var homeController = CreateHomeController();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                mockBouquetService.Object,
                mockFlowerService.Object);
        }
    }
}