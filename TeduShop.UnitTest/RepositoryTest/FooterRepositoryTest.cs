using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class FooterRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IUnitOfWork _unitOfWork;
        private IFooterRepository _objRepository;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _unitOfWork = new UnitOfWork(_dbFactory);
            _objRepository = new FooterRepository(_dbFactory);
        }

        [TestMethod]
        public void Footer_Repository_GetAll()
        {
            var res = _objRepository.GetAll().ToList();

            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [TestMethod]
        public void Footer_Repository_Create()
        {
            Footer footer = new Footer();
            footer.ID = "id1";
            footer.Content = "<h1>Testing header</h1>";

            var res = _objRepository.Add(footer);
            _unitOfWork.Commit();

            Assert.IsNotNull(res);
            Assert.AreEqual("id1", res.ID);
            Assert.AreEqual("<h1>Testing header</h1>", res.Content);
        }
    }
}