using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IMenuService
    {
        Menu Add(Menu menu);

        Menu Update(Menu menu);

        Menu Delete(int id);

        Menu GetById(int id);

        void SaveChanges();
    }

    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            _menuRepository = menuRepository;
            _unitOfWork = unitOfWork;
        }

        public Menu Add(Menu menu)
        {
            return _menuRepository.Add(menu);
        }

        public Menu Delete(int id)
        {
            return _menuRepository.Delete(id);
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public Menu Update(Menu menu)
        {
            return _menuRepository.Update(menu);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAllByGroupId(int groupID)
        {
            return _menuRepository.GetMulti(item => item.Status && item.GroupID == groupID);
        }

        public IEnumerable<Menu> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _menuRepository.GetMultiPaging(item => item.Status, out totalRow, page, pageSize);
        }
    }
}