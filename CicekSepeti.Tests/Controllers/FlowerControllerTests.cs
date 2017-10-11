using CicekSepeti.Service;
using CicekSepeti.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Controllers
{
    [TestClass]
    public class FlowerControllerTests
    {
        private Mock<IFlowerService> mockFlowerService;
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

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
            var flowerController = CreateFlowerController();
        }

        private FlowerController CreateFlowerController()
        {
            return new FlowerController(
                mockFlowerService.Object);
        }
    }
}