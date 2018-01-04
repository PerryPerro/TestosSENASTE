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

    public class BookController : ApiController
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
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
                    Filename = post.Filename,
                    ContentType = post.ContentType,
                    File = post.File
                })
                .ToList();
        }
    }
        
    }
