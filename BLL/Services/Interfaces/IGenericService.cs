using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
   public  interface IGenericService<TRequest,TResponse, TEntity>
    {
        public TResponse GetID(int  id);

        public int Add(TRequest AddProduct);
        public IEnumerable<TResponse> GetAll();
        int Remove(int  id);
        int Update(int id, TRequest UpdateProduct);
    }
}
