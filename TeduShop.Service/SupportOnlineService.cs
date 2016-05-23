using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ISupportOnlineService
    {
        SupportOnline Add(SupportOnline supportOnline);

        SupportOnline Update(SupportOnline supportOnline);

        SupportOnline Delete(int id);

        SupportOnline GetById(int id);

        IEnumerable<SupportOnline> GetAll();

        void SaveChanges();
    }

    public class SupportOnlineService : ISupportOnlineService
    {
        private ISupportOnlineRepository _supportOnlineRepository;
        private IUnitOfWork _unitOfWork;

        public SupportOnlineService(ISupportOnlineRepository supportOnlineRepository, IUnitOfWork unitOfWork)
        {
            _supportOnlineRepository = supportOnlineRepository;
            _unitOfWork = unitOfWork;
        }

        public SupportOnline Add(SupportOnline supportOnline)
        {
            return _supportOnlineRepository.Add(supportOnline);
        }

        public SupportOnline Delete(int id)
        {
            return _supportOnlineRepository.Delete(id);
        }

        public IEnumerable<SupportOnline> GetAll()
        {
            return _supportOnlineRepository.GetAll();
        }

        public SupportOnline GetById(int id)
        {
            return _supportOnlineRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public SupportOnline Update(SupportOnline supportOnline)
        {
            return _supportOnlineRepository.Update(supportOnline);
        }
    }
}