using HomeFood.DAL;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

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


        public JsonResult GetVirtualHotels()
        {
            try
            {
                IHomeFoodRepository repo = new HomeFoodRepository();
                return Json(new { Data = repo.GetVirtualHotels("chandigarh"), status = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetHotelDetails(string providerPhone)
        {
            try
            {
                IHomeFoodRepository repo = new HomeFoodRepository();
                var userDetail = repo.GetUser(providerPhone);
                var hotelDetails = repo.GetVirtualHotelDetail(providerPhone);

                var result = new
                {
                    FoodProvider = userDetail,
                    HotelDetails = hotelDetails
                };

                return Json(new { Data = result, status = 200 }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }
           
        }

    }
}
