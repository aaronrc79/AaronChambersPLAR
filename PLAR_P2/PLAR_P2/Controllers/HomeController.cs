// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//     This file is the Controller that mananges all our routes. The routes that this file handles are
//     Index and VehicleList. The file handles the validation of inserting the vehicles and the fetching of data.
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PLAR_P2.Models;
using PLAR_P2.Classes;

namespace PLAR_P2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Post action for the index route. Checks if the model if valid,
        /// if the model is valid it assigns it to its respected object and inserts it into the databse.
        /// </summary>
        /// <param name="carBoatModel">The carBoatModel</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(CarBoatModel carBoatModel)
        {
            //Check if the model if valid
            if (ModelState.IsValid)
            {
                //Check if the vehicle is a car or boat
                if (carBoatModel.mileage.HasValue)
                {
                    //Create a car object
                    Car car = new Car(carBoatModel.manufacturer, carBoatModel.model, carBoatModel.productYear.ToString(), carBoatModel.mileage.ToString());
                    //Inserts the car object
                    DBL.InsertCar(car);


                }else
                {
                    //Create a boat object
                    Boat boat = new Boat(carBoatModel.manufacturer, carBoatModel.model, carBoatModel.productYear.ToString());
                    //Inserts the boat object
                    DBL.InsertBoat(boat);
                }
                //Return the view
                return View(new CarBoatModel());
            }else
            {
            //Return the index view with the model
            return View("Index", carBoatModel);
            }
        }

        /// <summary>
        /// Fetches the Vehicle list using our database helper methods and gives our page
        /// the list of vehicles
        /// </summary>
        /// <returns>A the View with the list of vehicles</returns>
        public IActionResult VehicleList()
        {

            //Get the list of vehicles
            var allVehicles = DBL.GetVehicleList();
            return View(allVehicles);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
