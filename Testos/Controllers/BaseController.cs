using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testos.Models;

namespace Testos.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }
        // Om användaren inte lagt upp en profilbild så får den en dummybild, annars visar den bilden användaren sparat.
        public FileContentResult Image(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var us = db.Users.Find(id);

                if (us.ProfilePic == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Content/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                // to get the user details to load user Image
                var user = db.Users.Single(x => x.Id == id);

                return new FileContentResult(user.ProfilePic, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Content/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }
    }
}