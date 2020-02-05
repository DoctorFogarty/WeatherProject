using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherWeb.DAL;

namespace WeatherWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }

        public JsonResult ValidateZipCode(string ZipCode)
        {
            WeatherWebDB db = new WeatherWebDB();
            return Json(db.ValidateZipCode(Convert.ToInt32(ZipCode)), JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetWeatherData(string ZipCode)
        {
            WeatherWebDB db = new WeatherWebDB();
            return Json(db.GetWeatherData(Convert.ToInt32(ZipCode)), JsonRequestBehavior.DenyGet);
        }

    }
}