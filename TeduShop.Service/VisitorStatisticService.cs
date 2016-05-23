using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IVisitorStatisticService
    {
        VisitorStatistic Add(VisitorStatistic visitorStatistic);

        VisitorStatistic Update(VisitorStatistic visitorStatistic);

        VisitorStatistic Delete(int id);

        VisitorStatistic GetById(int id);

        IEnumerable<VisitorStatistic> GetAll();

        void SaveChanges();
    }

    public class VisitorStatisticService : IVisitorStatisticService
    {
        private IVisitorStatisticRepository _visitorStatisticRepository;
        private IUnitOfWork _unitOfWork;

        public VisitorStatisticService(IVisitorStatisticRepository visitorStatisticRepository, IUnitOfWork unitOfWork)
        {
            _visitorStatisticRepository = visitorStatisticRepository;
            _unitOfWork = unitOfWork;
        }

        public VisitorStatistic Add(VisitorStatistic visitorStatistic)
        {
            return _visitorStatisticRepository.Add(visitorStatistic);
        }

        public VisitorStatistic Delete(int id)
        {
            return _visitorStatisticRepository.Delete(id);
        }

        public IEnumerable<VisitorStatistic> GetAll()
        {
            return _visitorStatisticRepository.GetAll();
        }

        public VisitorStatistic GetById(int id)
        {
            return _visitorStatisticRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public VisitorStatistic Update(VisitorStatistic visitorStatistic)
        {
            return _visitorStatisticRepository.Update(visitorStatistic);
        }
    }
}