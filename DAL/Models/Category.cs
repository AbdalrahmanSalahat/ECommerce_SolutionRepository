using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   
    public class Category:BaseModel
    {

        public string? Name{ get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

    }
}
