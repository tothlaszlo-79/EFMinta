using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    public interface IMainCRUD<T>
    {
        bool Create(T adat);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByID(int id);
        bool Modify(T adat);
        bool Delete(int id);
    }
}
