using DAL.Db_ContextFolder;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Classes
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
      public CategoryRepository(ApplicationDbContext context) : base(context)
        {



        }
    }
}
