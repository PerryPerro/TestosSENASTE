using Logic;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testos.Models;

namespace Testos.Controllers
{
    public class FriendRequestController : BaseController
    {
        // GET: FriendRequest
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var listOfFriends = db.FriendRequests.Where(e => e.To.Id == user);
            return View( listOfFriends);
        }
        
        public ActionResult Accept(int id)
        {
            var request = db.FriendRequests.Find(id);
            var user1 = request.To;
            var user2 = request.From;
            var friend = new Friend
            {
                FirstUser = user2,
                SecondUser = user1
                
            };
            db.Friends.Add(friend);
            db.FriendRequests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index", "FriendRequest");
        }
       public ActionResult Decline(int id)
        {
            var request = db.FriendRequests.Find(id);
            db.FriendRequests.Remove(request);
            return RedirectToAction("Index", "FriendRequest");
        }

        public ActionResult SendRequest(string id)
        {
            var fromUser = User.Identity.GetUserId();

            var friendFrom = db.Users.Find(fromUser);
            var friendTo = db.Users.Find(id);

            var theRequest = new FriendRequest
            {
                From = friendFrom,
                To = friendTo
            };
            db.FriendRequests.Add(theRequest);
            db.SaveChanges();

            return RedirectToAction("SeeOtherProfile", "Profile", new { Id = id });
        }
    }
}