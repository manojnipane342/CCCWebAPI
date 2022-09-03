using Common.ViewModels.PaginationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IManager<T>
    {
        T Create(T item);

        List<T> GetList();

        //PagedResult<T> GetListPage(int PageNo, int PageSize);

        T Get(int id);

        void Update(T item);

        bool UpdateStatus(int Id);

        void Delete(int id);
        
    }
}

