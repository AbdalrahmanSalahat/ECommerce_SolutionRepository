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
   public class ItemRepository:GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
