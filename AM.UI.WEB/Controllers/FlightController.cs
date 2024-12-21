using AM.Core.Domain;
using AM.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        readonly IFlightService flightService;
        readonly IPlaneService planeService;


        public FlightController(IFlightService flightService,IPlaneService planeService) //injection de service
        {
            this.flightService = flightService;
            this.planeService = planeService;
        }
        // GET: FlightController
        public ActionResult Index(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return View(flightService.GetAll());
            return View(flightService.GetAll().Where(f => f.FlightDate.CompareTo(DateTime.Parse(filter)) == 0));
        }

        public ActionResult SortFlight()
        {

            return View("Index", flightService.SortFlights());
        }


        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            var planes = planeService.GetAll();
            ViewBag.Planes = new SelectList(planes, "PlaneId", "PlaneId");
            return View();
        }
        //ViewBag => relation entre contr et la vue


        // POST: FlightController/Create
        [HttpPost]

        public ActionResult Create(Flight f, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    f.Pilot = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);

                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads"));
                    }

                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(f);
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}