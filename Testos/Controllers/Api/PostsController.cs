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
            public string Filename { get; set; }
            public string ContentType { get; set; }
            public byte[] File { get; set; }
        }

        public IEnumerable<Post> GetAll()
        {
            var posts = db.Posts.ToList();
            return posts;
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
                    //Filename = post.Filename,C:\Users\Antie\Source\Repos\TestosSENASTE\Testos\Controllers\Api\PostsController.cs
                    //ContentType = post.ContentType,
                    //File = post.File
                })
                .ToList();
        }

    }
        
    }
