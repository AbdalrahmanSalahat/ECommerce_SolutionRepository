using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public enum Status
    {
        Active = 1, InActive = 0
    }
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public Status? CurrentStatus { get; set; } = Status.Active;
   
    }
}
