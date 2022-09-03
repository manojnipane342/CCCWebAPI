using Common.Models;
using Common.ViewModels.PaginationModel;
using Core.Helpers;
using Core.Interface;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Implementation
{
    public class RolesManager : IGetManager<RoleModel>
    {
        private IRepository<RoleModel> _repository { get; set; }
        public RolesManager(IRepository<RoleModel> repository)
        {
            _repository = repository;
        }

        public RoleModel Get(int id)
        {
            return _repository.GetById(id);
        }

        public List<RoleModel> GetList()
        {
            return _repository.TableNoTracking.ToList();
        }
    }
}