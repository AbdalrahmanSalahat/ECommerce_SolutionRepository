using DAL.DTO.DTORequsts;
using DAL.DTO.DTOResponses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IItemService:IGenericService<ItemRequest,ItemResponse,Item>
    {
        Task<int> CreateFile(ItemRequest itemRequest);
    }
}
