using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IUserManager<T>
    {
        T Create(T item);
        List<T> GetList();

        T Get(int id);

        void Update(T item);

        void Delete(int id);

        UserModelVM LoginUser(string username, string Password);

        bool UpdateUserDeviceTokenId(int UserId, string DeviceTokenId);


    }
}
