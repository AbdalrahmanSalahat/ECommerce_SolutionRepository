using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [PrimaryKey( nameof(ProductId),nameof(UserId))]
   public class cart
    {

        
        public int ProductId { get; set; }
        public Item Item { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Count{ get; set; }


    }
}
