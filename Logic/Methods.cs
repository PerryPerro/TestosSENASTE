using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testos.Models;

namespace Logic
{
    public static class Methods
    {
        public static int CountRequests(string id)
        {
            int quantity;
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var list = db.FriendRequests.Where(e => e.To.Id == id);
                    quantity = list.Count();
                }
                return quantity;
            }
            catch
            {
                return 0;
            }
        }
    }
}
