using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testos.Models;
using System.Data.Entity;
namespace Testos.Controllers
{
    public class PostController : BaseController
    {
        // GET: Post
        public ActionResult Index(string id)
        {
            var posts = db.Posts.Include(x => x.From).Where(x => x.To.Id == id).ToList();
            return View(new PostModel { Id = id, Posts = posts });

        }

        public ActionResult SkapaPost(Post post, string id, HttpPostedFileBase upload)
        {
            var userName = User.Identity.Name;

            var user = db.Users.Single(x => x.UserName == userName);

            post.From = user;

            var toUser = db.Users.Single(x => x.Id == id);
            post.To = toUser;

            db.Posts.Add(post);

            if (upload != null && upload.ContentLength > 0)
            {
                post.Filename = upload.FileName;
                post.ContentType = upload.ContentType;

                using (var reader = new BinaryReader(upload.InputStream))
                {
                    post.File = reader.ReadBytes(upload.ContentLength);
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }
    }
}