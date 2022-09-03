using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IGetManager<T>
    {
        List<T> GetList();

        T Get(int id);
    }
}
