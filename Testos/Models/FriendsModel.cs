using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testos.Models
{
    public class FriendsModel
    {
        public int Id { get; set; }
        public ApplicationUser FriendsFrom{ get; set; }
        public ApplicationUser  FriendsTo { get; set; }
        
    }
}