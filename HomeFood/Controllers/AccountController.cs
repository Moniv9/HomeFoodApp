using System;
using System.Web;
using System.Web.Mvc;
using HomeFood.DAL;
using HomeFood.Models;

namespace HomeFood.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View("Dashboard", Session["user"]);
            }

            return View();
        }


        public ActionResult Dashboard()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Register(string phone, string pwd, string name, string city)
        {
            try
            {
                if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(city))
                    return Json(new { Error = "Invalid input", status = 405 }, JsonRequestBehavior.AllowGet);

                var foodProvider = new FoodProviderModel()
                {
                    Id = phone,
                    City = city.ToLower(),
                    Longititde = 77.391F,
                    Latitude = 28.5355F,
                    Name = name,
                    Password = pwd
                };

                IHomeFoodRepository repo = new HomeFoodRepository();
                repo.RegisterFoodProvider(foodProvider);

                return Json(new { status = 200 }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }


        }


        [HttpPost]
        public ActionResult Dashboard(string phone, string pwd)
        {
            try
            {
                if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pwd))
                    return Json(new { Error = "Invalid input", status = 405 }, JsonRequestBehavior.AllowGet);

                IHomeFoodRepository repo = new HomeFoodRepository();
                var userDetail = repo.GetUser(phone, pwd);

                if (userDetail == null)
                    return Json(new { Message = "Invalid password or phone number", status = 405 }, JsonRequestBehavior.AllowGet);
                else
                {
                    Session["user"] = userDetail;
                    return View("Dashboard", userDetail);
                }

            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
