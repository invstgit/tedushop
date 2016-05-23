using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IUnitOfWork _unitOfWork;
        private IPostCategoryRepository _objRepository;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _unitOfWork = new UnitOfWork(_dbFactory);
            _objRepository = new PostCategoryRepository(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var res = _objRepository.GetAll().ToList();

            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "test post category name";
            postCategory.Alias = "test-post-category-alias";
            postCategory.Status = true;

            var res = _objRepository.Add(postCategory);
            _unitOfWork.Commit();

            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.ID);
            Assert.AreEqual("test post category name", res.Name);
            Assert.AreEqual("test-post-category-alias", res.Alias);
            Assert.AreEqual(true, res.Status);
        }
    }
}