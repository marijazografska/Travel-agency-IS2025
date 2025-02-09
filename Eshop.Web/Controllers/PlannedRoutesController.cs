using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Domain.Domain;
using EShop.Repository;
using EShop.Service.Interface;

namespace Eshop.Web.Controllers
{

    public class PlannedRoutesController : Controller
    {
        private readonly IPlannedRouteService plannedRouteService;
        private readonly IItineraryService itineraryService;

        public PlannedRoutesController(IPlannedRouteService plannedRouteService, IItineraryService itineraryService)
        {
            this.plannedRouteService = plannedRouteService;
            this.itineraryService = itineraryService;
        }

        // GET: PlanningRoutes
        public IActionResult Index()
        {
            return View(plannedRouteService.GetAllPlanningRoutes());
        }

        // GET: plannedRoute/Details/Id
        public IActionResult Details(Guid? id)
        {
            var route = plannedRouteService.GetDetailsForPlanningRoute(id);
            return View(route);
        }

        // GET: Agencies/Create/3
        //Path Variable Id is from the Itinerary!!
        public IActionResult Create(Guid? id)
        {
            Itinerary itinerary = itineraryService.GetDetailsForItinerary(id);
            if (itinerary == null)
            {
                return NotFound("Itinerary not found.");
            }


            ViewBag.ItineraryId = id;
            ViewBag.Count = itinerary.getInitialSize();

            var model = plannedRouteService.InitializePlannedRoutes(itinerary);

            return View(model);
            
               
        }
        public IActionResult CanNotAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(List<PlannedRoute> planningRoutes)
        {
            Itinerary itinerary = itineraryService.GetDetailsForItinerary(planningRoutes[0].ItineraryId);
            itinerary.PlannedRoutes.Clear();
            foreach (var route in planningRoutes)
            {
                plannedRouteService.CreateNewPlanningRoute(route);
            }

            return RedirectToAction("Index", "Itineraries");
        }

        // GET: plannedRoute/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var route = plannedRouteService.GetDetailsForPlanningRoute(id);
            ViewBag.ItineraryId = route.ItineraryId;
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // POST: plannedRoute/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PlannedRoute plannedRoute)
        {
            if (id != plannedRoute.Id)
            {
                return NotFound();
            }

            PlannedRoute previousRoute = plannedRouteService.GetDetailsForPlanningRoute(id);
            plannedRouteService.UpdateExistingPlanningRoute(previousRoute, plannedRoute);

            return RedirectToAction("Index", "Itineraries");
            //if (ModelState.IsValid)
            //{
            //    try
            //    {

            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        throw;
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(plannedRoute);
        }

        // GET: PlannedRoute/Delete/5
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var agency = plannedRouteService.GetDetailsForPlanningRoute(Id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // POST: PlannedRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var plannedRoute = plannedRouteService.GetDetailsForPlanningRoute(id);
            if (plannedRoute != null)
            {
                plannedRouteService.DeletePlanningRoute(id);
            }

            return RedirectToAction("Details", "Itineraries", new { id = plannedRoute.ItineraryId });
        }
    }
}
    
