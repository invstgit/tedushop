using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup menuGroup);

        MenuGroup Update(MenuGroup menuGroup);

        MenuGroup Delete(int id);

        MenuGroup GetById(int id);

        IEnumerable<MenuGroup> GetAll();

        void SaveChanges();
    }

    public class MenuGroupService : IMenuGroupService
    {
        private IMenuGroupRepository _menuGroupRepository;
        private IUnitOfWork _unitOfWork;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork unitOfWork)
        {
            _menuGroupRepository = menuGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public MenuGroup Add(MenuGroup menuGroup)
        {
            return _menuGroupRepository.Add(menuGroup);
        }

        public MenuGroup Delete(int id)
        {
            return _menuGroupRepository.Delete(id);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }

        public MenuGroup GetById(int id)
        {
            return _menuGroupRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public MenuGroup Update(MenuGroup menuGroup)
        {
            return _menuGroupRepository.Update(menuGroup);
        }
    }
}