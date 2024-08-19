using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BuisnessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entitiy);
        void TUpdate(T entitiy);
        void TDelete(int id);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
