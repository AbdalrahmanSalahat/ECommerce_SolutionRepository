using Azure.Core;
using Azure;
using BLL.Services.Interfaces;
using DAL.Db_ContextFolder;
using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class CategoryService : GenericService<CategoryRequest, CategorytResponse, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository GenericService) : base(GenericService)
        {

        }
    }
    }
        