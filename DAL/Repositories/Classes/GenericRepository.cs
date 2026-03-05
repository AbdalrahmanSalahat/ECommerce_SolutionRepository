using Azure.Core;
using DAL.Db_ContextFolder;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseModel
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(T AddEntity)
        {
            _context.Add(AddEntity);
            return _context.SaveChanges();

        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            return _context.Set<T>().ToList();
        }

        public T GetID(int id)
        {
            return _context.Set<T>().Find(id);

        }

        public int Remove(T RemoveEntity)
        {
            _context.Remove(RemoveEntity);
            return _context.SaveChanges();
        }

        public int Update(T UpdateEntity)
        {
            _context.Update(UpdateEntity);
            return _context.SaveChanges();
        }
    }
}
