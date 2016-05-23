using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostTagService
    {
        PostTag Add(PostTag postTag);

        PostTag Update(PostTag postTag);

        PostTag Delete(int id);

        PostTag GetById(int id);

        IEnumerable<PostTag> GetAll();

        void SaveChanges();
    }

    public class PostTagService : IPostTagService
    {
        private IPostTagRepository _postTagRepository;
        private IUnitOfWork _unitOfWork;

        public PostTagService(IPostTagRepository postTagRepository, IUnitOfWork unitOfWork)
        {
            _postTagRepository = postTagRepository;
            _unitOfWork = unitOfWork;
        }

        public PostTag Add(PostTag postTag)
        {
            return _postTagRepository.Add(postTag);
        }

        public PostTag Delete(int id)
        {
            return _postTagRepository.Delete(id);
        }

        public IEnumerable<PostTag> GetAll()
        {
            return _postTagRepository.GetAll();
        }

        public PostTag GetById(int id)
        {
            return _postTagRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public PostTag Update(PostTag postTag)
        {
            return _postTagRepository.Update(postTag);
        }
    }
}