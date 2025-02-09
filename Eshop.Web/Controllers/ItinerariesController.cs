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
    public class ItinerariesController : Controller
    {
            private readonly IItineraryService itineraryService;
            private readonly IProductService ProductService;

            public ItinerariesController(IProductService ProductService,
                IItineraryService itineraryService)
            {
                this.ProductService = ProductService;
                this.itineraryService = itineraryService;
            }

            // GET: Itineraries
            public IActionResult Index()
            {
                return View(itineraryService.GetAllItineraries());
            }

            // GET: Itineraries/Details/Id
            public IActionResult Details(Guid? id)
            {
                var itinerary = itineraryService.GetDetailsForItinerary(id);
                return View(itinerary);
            }

            // GET: Itineraries/Create
            public IActionResult Create()
            {
                var Products = ProductService.GetAllProducts();
                ViewData["ProductId"] = new SelectList(Products, "Id", "ProductName");
                return View();
            }
        /*
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Itinerary itinerary)
            {
                var result = itineraryService.CreateNewItinerary(itinerary);
                if (result == true)
                {
                //return RedirectToAction("Create", "Products", new { id = itinerary.Id });
                return View(itineraryService.GetAllItineraries());
            }
                return RedirectToAction("Error");

            } */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Itinerary itinerary)
        {
            var result = itineraryService.CreateNewItinerary(itinerary);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            var products = ProductService.GetAllProducts();
            ViewData["ProductId"] = new SelectList(products, "Id", "ProductName");
            return View(itinerary);
        }


        public IActionResult Error()
            {
                return View();
            }

            // GET: Itineraries/Edit/5
            public async Task<IActionResult> Edit(Guid? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var itinerary = itineraryService.GetDetailsForItinerary(id);
                if (itinerary == null)
                {
                    return NotFound();
                }
                var Products = ProductService.GetAllProducts();
                ViewData["ProductId"] = new SelectList(Products, "Id", "ProductName");
                return View(itinerary);
            }

            // POST: Itineraries/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Guid id, Itinerary itinerary)
            {
                if (id != itinerary.Id)
                {
                    return NotFound();
                }
                itineraryService.UpdateExistingItinerary(itinerary);
                return RedirectToAction(nameof(Index));

                //if (ModelState.IsValid)
                //{
                //    try
                //    {
                //        itineraryService.UpdateExistingItinerary(itinerary);
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        throw;
                //    }
                //    return RedirectToAction(nameof(Index));
                //}
                //return View(itinerary);
            }

            // GET: Itineraries/Delete/5
            public async Task<IActionResult> Delete(Guid Id)
            {
                if (Id == null)
                {
                    return NotFound();
                }

                var itinerary = itineraryService.GetDetailsForItinerary(Id);
                if (itinerary == null)
                {
                    return NotFound();
                }

                return View(itinerary);
            }

            // POST: Itineraries/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(Guid Id)
            {
                var itinerary = itineraryService.GetDetailsForItinerary(Id);
                if (itinerary != null)
                {
                    itineraryService.DeleteItinerary(Id);
                }

                return RedirectToAction(nameof(Index));
            }
        }
    }
