using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testos.Models;

namespace Logic
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public ApplicationUser From { get; set; }
        public ApplicationUser To { get; set; }
    }
}
