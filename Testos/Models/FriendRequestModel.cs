using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testos.Models
{
    public class FriendRequestModel
    {
        public List<FriendRequest> FriendList { get; set; }
    }
    public class SendFriendRequestModel
    {
        public ApplicationUser FriendFrom { get; set; }
        public ApplicationUser FriendTo { get; set; }
    }
}