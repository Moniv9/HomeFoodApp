﻿using System;
using System.Web;
using System.Web.Mvc;
using HomeFood.DAL;
using HomeFood.Models;

namespace HomeFood.Controllers
{
    public class AccountController : Controller
    {

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
                    City = city,
                    Location = new Location(),
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
        public JsonResult Login(string phone, string pwd)
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
                    return Json(new { User = userDetail, status = 200 }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}