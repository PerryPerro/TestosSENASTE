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
            
            return View();
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

        //Hämtar sparade bilden på den användare som skickas med i parametern
        public ActionResult Image(string id)
        {
            var User = db.Users.Single(x => x.Id == id);
            return File(User.ProfilePic, User.ContentType);
        }
    }
}