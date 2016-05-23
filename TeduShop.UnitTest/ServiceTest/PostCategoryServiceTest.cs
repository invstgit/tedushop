using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _mockService;
        private List<PostCategory> _postCategories;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _postCategories = new List<PostCategory>()
            {
                new PostCategory() { ID=1, Name="Danh muc 1", Alias="Danh-muc-1", Status=true},
                new PostCategory() { ID=2, Name="Danh muc 2", Alias="Danh-muc-2", Status=true},
                new PostCategory() { ID=3, Name="Danh muc 3", Alias="Danh-muc-3", Status=true},
                new PostCategory() { ID=4, Name="Danh muc 4", Alias="Danh-muc-4", Status=true},
                new PostCategory() { ID=5, Name="Danh muc 5", Alias="Danh-muc-5", Status=true},
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup: _postCategories is result for call action method GetAll(null)
            _mockRepository.Setup(x => x.GetAll(null)).Returns(_postCategories);

            //call action
            var res = _mockService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(res);
            Assert.AreEqual(5, res.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory _postCategory = new PostCategory()
                                        {
                                            Name = "Danh muc 6",
                                            Alias = "Danh-muc-6",
                                            Status = true
                                        };

            //setup: result for call action method Add
            _mockRepository.Setup(x => x.Add(_postCategory)).Returns(new PostCategory() {
                ID = 6,
                Name = "Danh muc 6",
                Alias = "Danh-muc-6",
                Status = true
            });

            //call action
            var res = _mockService.Add(_postCategory);

            //compare
            Assert.IsNotNull(res);
            Assert.AreEqual(6, res.ID);

        }
    }
}