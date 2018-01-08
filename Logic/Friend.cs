using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testos.Models;

namespace Logic
{
   public class Friend
    {
        public int Id { get; set; }
        public virtual ApplicationUser FirstUser { get; set; }
        public virtual ApplicationUser SecondUser { get; set; }
    }
}
