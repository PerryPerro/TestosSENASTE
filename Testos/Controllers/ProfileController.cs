using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testos.Models;
using Logic;
using System.Data.Entity;
using System.IO;
using Microsoft.AspNet.Identity.Owin;

namespace Testos.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        // Hämtar den inloggade användarens id genom User Identity och visar dess profil genom view.
       public ActionResult SeeProfile()
        {
                var idet = User.Identity.GetUserId();
            var user = db.Users.Find(idet);
            return View(user);
        }
        //
        public ActionResult EditProfile()
        {
            var idet = User.Identity.GetUserId();
            var user = db.Users.Find(idet);
            return View(user);
        }
        // Sparar ändringarna av den inloggade usern i databasen,
        [HttpPost]
        public ActionResult EditProfile([Bind(Exclude = "profilePic")] ApplicationUser user)
        {
            var idet = User.Identity.GetUserId();
            var us = db.Users.Find(idet);
            us.FirstName = user.FirstName;
            us.EfterNamn = user.EfterNamn;
            us.Age = user.Age;
            us.From = user.From;
            us.Gender = user.Gender;
            us.Filename = user.Filename;
            us.ContentType = user.ContentType;

            byte[] imageData = null;
            if(Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["profilPic"];
                using (var reader = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = reader.ReadBytes(poImgFile.ContentLength);
                }
                if(imageData.Length > 0)
                {
                    us.ProfilePic = imageData;
                }
            }
           

            db.SaveChanges();
            return View();
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
        // Visar en sparad användares profil.
        public ActionResult SeeOtherProfile(string id)
        {
            var user = db.Users.Find(id);
            var post = db.Posts.Include(x => x.From).Where(x => x.To.Id == id).ToList();
            //var post = db.Posts.ToList().Where(x => x.Id == id);

            return View(new ProfileModel { Id = id, User = user, posts = post });

        }
        public ActionResult ListOFUsers(string searchString)
        {
            var users = db.Users.ToList();
            return View(db.Users.Where(x => x.FirstName.Contains(searchString) || searchString == null).ToList());

        }

  
        // hämtar ett användar id och visar dess vänner.
        public ActionResult ViewFriends(string id)
        {
            var toUser = db.Users.Find(id);
            var Friends = db.Friends.ToList().Where(e => e.SecondUser == toUser);
            return View(Friends);
        }
        
        // Ändrar propertyn searchable till false på användaren. 
        public ActionResult SearchableOn()
        {
            var user = User.Identity.GetUserId();
            db.Users.Find(user).searchable = false;
            db.SaveChanges();

            return RedirectToAction("SeeProfile", "Profile", new { id = user });
        }

        public ActionResult SearchableOff()
        {
            var user = User.Identity.GetUserId();
            db.Users.Find(user).searchable = true;
            db.SaveChanges();

            return RedirectToAction("SeeProfile", "Profile", new { id = user });

        }
        
    }
}