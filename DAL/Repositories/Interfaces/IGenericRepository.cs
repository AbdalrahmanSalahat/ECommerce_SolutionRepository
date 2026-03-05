using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T:BaseModel
    {
        public T GetID(int id);
        public int Add(T AddProduct);
        public IEnumerable<T> GetAll(bool withTracking = false);
        int Remove(T RemoveProduct);
        int Update(T UpdateProduct);
    }
}
