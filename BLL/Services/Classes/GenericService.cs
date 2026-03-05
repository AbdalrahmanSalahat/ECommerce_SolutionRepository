using Azure.Core;
using Azure;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Classes;
using Mapster;
using DAL.DTO.DTOResponses;

namespace BLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity> where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repo;
        public GenericService(IGenericRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public int Add(TRequest Add)
        {
            var creation = Add.Adapt<TEntity>();
            return _repo.Add(creation);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var All = _repo.GetAll();
            return All.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse GetID(int id)
        {
            var Get = _repo.GetID(id);
            return Get.Adapt<TResponse>();
          
        }

        public int Remove(int id)
        {
            var get =  _repo.GetID(id);

            return _repo.Remove(get);
        }

        public int Update(int id, TRequest Update)
        {
            var get = _repo.GetID(id);
            if (get == null) { return 0; }

            var Updatevar = Update.Adapt(get);
          
            return _repo.Update(Updatevar);
        }
    }
}
