using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public int Add(cart cart);
      /*  public List<cart> GetCartByUserId(string UserId);*/
    }
}
