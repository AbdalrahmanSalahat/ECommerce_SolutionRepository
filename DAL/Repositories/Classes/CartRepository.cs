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
   public class CartRepository:ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(cart cart)
        {
            _context.Carts.Add(cart);
            return _context.SaveChanges();
        }

       /* public List<cart> GetCartByUserId(string UserId)
        {
          _context.Carts.Include<cart>().Where(c => c.UserId == int.Parse(UserId)).ToList();
        }*/
    }
}
