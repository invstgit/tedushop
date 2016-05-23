using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ISystemConfigService
    {
        SystemConfig Add(SystemConfig systemConfig);

        SystemConfig Update(SystemConfig systemConfig);

        SystemConfig Delete(int id);

        SystemConfig GetById(int id);

        IEnumerable<SystemConfig> GetAll();

        void SaveChanges();
    }

    public class SystemConfigService : ISystemConfigService
    {
        private ISystemConfigRepository _systemConfigRepository;
        private IUnitOfWork _unitOfWork;

        public SystemConfigService(ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork)
        {
            _systemConfigRepository = systemConfigRepository;
            _unitOfWork = unitOfWork;
        }

        public SystemConfig Add(SystemConfig systemConfig)
        {
            return _systemConfigRepository.Add(systemConfig);
        }

        public SystemConfig Delete(int id)
        {
            return _systemConfigRepository.Delete(id);
        }

        public IEnumerable<SystemConfig> GetAll()
        {
            return _systemConfigRepository.GetAll();
        }

        public SystemConfig GetById(int id)
        {
            return _systemConfigRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public SystemConfig Update(SystemConfig systemConfig)
        {
            return _systemConfigRepository.Update(systemConfig);
        }
    }
}