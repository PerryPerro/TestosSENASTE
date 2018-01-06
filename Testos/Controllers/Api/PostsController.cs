using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testos.Models;

namespace Testos.Controllers
{
    
    public class PostsController : ApiController
    {
      
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }

      
        public class PostListItem
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public virtual ApplicationUser From { get; set; }
            public virtual ApplicationUser To { get; set; }
   
        }

        [HttpGet]
        public List<Post> GetAll(string id)
        {

            var posts = db.Posts.Where(x => x.From.Id == id);

            return posts.ToList();
        }



        

        public IHttpActionResult Get(int id)
        {
            var post= db.Posts.FirstOrDefault((p) => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpGet]
        public List<PostListItem> List()
        {
            return db.Posts.ToList()
                .Select(post => new PostListItem
                {
                    Id = post.Id,
                    Text = post.Text,
                    From = post.From,
                    To = post.To,
            
                })
                .ToList();
        }

        public void SkapaPost(Post post, string id)
        {
            var userName = User.Identity.Name;
            var user = db.Users.Single(x => x.UserName == userName);
            post.From = user;

            var toUser = db.Users.Single(x => x.Id == id);
            post.To = toUser;

            
            db.Posts.Add(post);
            db.SaveChanges();

            //return RedirectToAction("Index", new { id = id });
        }

    }
        
    }
