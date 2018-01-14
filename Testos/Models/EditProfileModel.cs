using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testos.Models
{
    public class EditProfileModel
    {
        public byte[] ProfilePic { get; set; }
        public string FirstName { get; set; }
        public string EfterNamn { get; set; }
        public int Age { get; set; }
        public string From { get; set; }
        public string Gender { get; set; }

    }
}