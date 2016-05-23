using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductTagService
    {
        ProductTag Add(ProductTag productTag);

        ProductTag Update(ProductTag productTag);

        ProductTag Delete(int id);

        ProductTag GetById(int id);

        IEnumerable<ProductTag> GetAll();

        void SaveChanges();
    }

    public class ProductTagService : IProductTagService
    {
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductTag Add(ProductTag productTag)
        {
            return _productTagRepository.Add(productTag);
        }

        public ProductTag Delete(int id)
        {
            return _productTagRepository.Delete(id);
        }

        public IEnumerable<ProductTag> GetAll()
        {
            return _productTagRepository.GetAll();
        }

        public ProductTag GetById(int id)
        {
            return _productTagRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public ProductTag Update(ProductTag productTag)
        {
            return _productTagRepository.Update(productTag);
        }
    }
}