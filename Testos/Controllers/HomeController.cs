using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testos.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var users = db.Users.ToList().Where(x => x.Id != User.Identity.GetUserId());     
            return View(users);
        }

        public ActionResult ListOFUsers(string searchString)
        {
            var users = db.Users.ToList();
            return View(db.Users.Where(x => x.FirstName.Contains(searchString) || searchString == null).ToList());

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Söker och hämtar ut all användardata ur användardatabasen om deras firstname matchar söksträngen
        public ActionResult SearchUsers(string searchString)
        {

            return View(db.Users.Where(x => x.FirstName.Contains(searchString) || searchString == null).ToList());
        }


    }
}