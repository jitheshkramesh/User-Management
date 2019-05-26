using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagementSystem.Models;

namespace UserManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        USERMANAGEMENTEntities db = new USERMANAGEMENTEntities();
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


        public ActionResult AddUser(int? id)
        {
            // Usermanagement
            ViewBag.latitude = 52.3800447;
            ViewBag.longitude = 9.728811599999972;
            ViewBag.MapApi = "";
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(FormCollection fc, HttpPostedFileBase photo, HttpPostedFileBase document) {
            if (ModelState.IsValid) {
                UserDetail user= new UserDetail();

                user.FirstName = fc["FirstName"];
                user.LastName = fc["LastName"];
                user.Address = fc["Address"];
                //user.FileAddress = fc["FileAddress"];

                user.CityName = fc["CityName"];
                user.Latitude = decimal.Parse(fc["Latitude"]);
                user.Longitude = decimal.Parse(fc["Longitude"]);
                user.Description = fc["Description"];
                //user.PhotoPath = fc["PhotoPath"];
                user.RegisterDate = DateTime.Now.ToLocalTime();
                user.mapAddress = fc["map"];


                if (photo != null && photo.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(photo.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Files/Images/"), DateTime.Now.ToLongDateString() + fileName);
                    photo.SaveAs(imgpath);
                    user.PhotoPath = DateTime.Now.ToLongDateString() + fileName;
                }

                if (document != null && document.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(document.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Files/Images/"), DateTime.Now.ToLongDateString() + fileName);
                    document.SaveAs(imgpath);
                    user.FileAddress = DateTime.Now.ToLongDateString() + fileName;
                }

                db.UserDetails.Add(user);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult UserList()
        {

            return View(db.UserDetails.ToList());
        }
    }
}