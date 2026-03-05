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
    public interface ICartService
    {
        public int AddtoCart( CartRequest CartRequest,int UserId);
        /*CartSummaryResponse CartSummaryResponse(string UserId);*/
    }
}
