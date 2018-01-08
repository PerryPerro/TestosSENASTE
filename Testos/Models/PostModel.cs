using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testos.Models
{
    public class PostModel
    {
        public string Id { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public class PostItem
    {
        public string to { get; set; }
        public string from { get; set; }
        public string text { get; set; }
    }
}