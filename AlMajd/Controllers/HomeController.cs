using AlMajd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlMajd.Controllers
{
    public class HomeController : Controller
    {
        AlMajdEntities door = new AlMajdEntities();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TravellersIndex()
        {
            var List = door.ServiceType.ToList();
            var ServiseList = new SelectList(List, "serviceId", "serviceName");
            ViewBag.ServiseList = ServiseList;

            var currencyVal = door.CurrencyValues.SingleOrDefault();
            
            TempData["nisCurVal"] = currencyVal.NISValue;
            TempData["jdCurVal"] = currencyVal.JDValue;
            TempData["euroCurVal"] = currencyVal.euroValue;
            TempData.Keep();
            var travellerlist = door.TravellerInformations.OrderByDescending(a => a.dateOfTravel).ToList();

            if (travellerlist.Any())
            {

                ViewBag.listTravllers = travellerlist;
                return View();
            }
            return View();
        }
        public ActionResult CommingIndex()
        {
            return View();
        }

    }
}