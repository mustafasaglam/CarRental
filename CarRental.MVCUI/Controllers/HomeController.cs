using CarRental.Business.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        CarManager carManager = new CarManager(new EfCarDal());
        CarRentalContext db = new CarRentalContext();
        // GET: Home
        public ActionResult Index()
        {
            var car = db.Cars;
           
            return View(car);
            
        }
    }
}