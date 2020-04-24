using AlMajd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlMajd.Controllers
{
    public class TravellerController : Controller
    {
        // GET: Traveller
        AlMajdEntities door = new AlMajdEntities();

        [HttpPost]
        public ActionResult CreateNewTravel (TravellerInformations model)
        {
            try
            {
                bool response = false;
                if (!ModelState.IsValid) {
                    var List = door.ServiceType.ToList();
                    var ServiseList = new SelectList(List, "serviceId", "serviceName");
                    ViewBag.ServiseList = ServiseList;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                // build new object to save data to database
                TravellerInformations newTraveller = new TravellerInformations();

                newTraveller.travellerId = model.travellerId;
                newTraveller.dateOfTravel = DateTime.Now;
                newTraveller.fName = model.fName;
                newTraveller.lName = model.lName;
                newTraveller.numberDarebeh = model.numberDarebeh;
                newTraveller.numberOfTravellers = model.numberOfTravellers;
                newTraveller.serviceId = model.serviceId;
                newTraveller.travellerIdentify = model.travellerIdentify;

                door.TravellerInformations.Add(newTraveller);
                door.SaveChanges();           

                var List1 = door.ServiceType.ToList();
                var ServiseList1 = new SelectList(List1, "serviceId", "serviceName");
                ViewBag.ServiseList = ServiseList1;
                response = true;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}