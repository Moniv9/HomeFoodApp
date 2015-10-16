using System;
using System.Web;
using System.Web.Mvc;

namespace HomeFood.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public JsonResult BookOrder(string consumerPhone, string providerPhone, string foodId, string foodTime)
        {

            return Json(new object(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetOrders(string providerPhone)
        {

            return Json(new object(), JsonRequestBehavior.AllowGet);
        }


    }
}
