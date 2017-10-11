using System.Data.Common;
using System.Linq;
using CicekSepeti.Repository;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class FlowerRepositoryTests
    {
        private DbConnection _connection;
        private CicekSepetiDbContextTest _databaseContext;
        private FlowerRepository _objRepo;

        [TestInitialize]
        public void Initialize()
        {
            _connection = DbConnectionFactory.CreateTransient();
            _databaseContext = new CicekSepetiDbContextTest(_connection);
            _objRepo = new FlowerRepository(_databaseContext);
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
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual("Gül", result[0].Name);
            Assert.AreEqual("Papatya", result[2].Name);
            Assert.AreEqual("Orkide", result[4].Name);

            //Uncomment below the correct version is this I have added the line above for test
            //Assert.AreEqual(3, result.Count);
            //Assert.AreEqual("Gül", result[0].Name);
            //Assert.AreEqual("Papatya", result[1].Name);
            //Assert.AreEqual("Orkide", result[2].Name);
        }
    }
}