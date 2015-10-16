using System;
using System.Web;
using System.Web.Mvc;

namespace HomeFood.Controllers
{
    public class HomeController : Controller
    {

        public JsonResult GetCities()
        {
            try
            {
                return Json(new { Cities = Cities.GetCities(), status = 200 }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetVirtualHotels(string userLocation, string category)
        {

            return Json(new object(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetHotelDetail(string providerPhone)
        {

            return Json(new object(), JsonRequestBehavior.AllowGet);
        }

    }
}
