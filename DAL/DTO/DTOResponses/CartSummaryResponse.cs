using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.DTOResponses
{
   public class CartSummaryResponse
    {
       public List<CartResponse> Cartlist { get; set; }=new List<CartResponse>();
    /*    public decimal Fullprice =>Cartlist.Sum(c => c.TotalPrice);*/
    }
}
