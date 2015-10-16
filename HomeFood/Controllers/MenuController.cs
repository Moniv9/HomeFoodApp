using System;
using System.Web;
using System.Web.Mvc;
using HomeFood.Models;
using HomeFood.DAL;

namespace HomeFood.Controllers
{
    public class MenuController : Controller
    {

        public JsonResult GetMenu()
        {
            return Json(new object(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddFoodItem(HttpPostedFileBase file, string providerPhone, string price, string name, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(price))
                    return Json(new { Error = "Invalid input", status = 405 }, JsonRequestBehavior.AllowGet);

                int foodPrice;
                if (!int.TryParse(price, out foodPrice))
                    return Json(new { Error = "Invalid price", status = 405 }, JsonRequestBehavior.AllowGet);

                var foodProvider = (FoodProviderModel)Session["user"];

                var menuModel = new FoodModel()
                {
                    ProviderPhone = foodProvider.Id,
                    Price = foodPrice,
                    Description = description,
                    Image = AddImage(file),
                    Name = name
                };

                IHomeFoodRepository repo = new HomeFoodRepository();
                repo.AddFoodItem(menuModel);

                return Json(new { Message = "Food item added successfully", status = 200 }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult AddRating(string providerPhone, string rating)
        {
            try
            {
                if (string.IsNullOrEmpty(providerPhone) || string.IsNullOrEmpty(rating))
                    return Json(new { Error = "Invalid input", status = 405 }, JsonRequestBehavior.AllowGet);

                int providerRating;
                if (!int.TryParse(rating, out providerRating) && providerRating > 0)
                    return Json(new { Error = "Invalid rating", status = 405 }, JsonRequestBehavior.AllowGet);

                IHomeFoodRepository repo = new HomeFoodRepository();
                repo.UpdateRating(providerPhone, providerRating);

                return Json(new { status = 200 }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }

        }


        #region Private


        private string AddImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Guid.NewGuid() + file.FileName;
                string path = Server.MapPath("~/Files/" + fileName);
                file.SaveAs(path);

                return "/Files/" + fileName;
            }

            //TODO : add default image
            return string.Empty;
        }


        #endregion

    }
}
