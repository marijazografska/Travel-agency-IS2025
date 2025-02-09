using EShop.Domain.Domain;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class PlannedRouteService : IPlannedRouteService
    {
        private readonly IRepository<PlannedRoute> plannedRouteRepository;

        public PlannedRouteService(IRepository<PlannedRoute> plannedRouteRepository)
        {
            this.plannedRouteRepository = plannedRouteRepository;
        }

        public void CreateNewPlanningRoute(PlannedRoute pr)
        {
            plannedRouteRepository.Insert(pr);
        }

        public void DeletePlanningRoute(Guid pr)
        {
            plannedRouteRepository.Delete(plannedRouteRepository.Get(pr));
        }

        public List<PlannedRoute> GetAllPlanningRoutes()
        {
            return plannedRouteRepository.GetAll().ToList();
        }

        public PlannedRoute GetDetailsForPlanningRoute(Guid? id)
        {
            return plannedRouteRepository.Get(id);
        }

        //itinerartyID
        public PlannedRoute getPlanningRouteForItineraty(Guid id)
        {
            return plannedRouteRepository.GetAll()
                .SingleOrDefault(s => s.ItineraryId == id);
        }

        public List<PlannedRoute> InitializePlannedRoutes(Itinerary itinerary)
        {
            List<PlannedRoute> model = new List<PlannedRoute>(itinerary.getInitialSize());

            if (itinerary.PlannedRoutes.Count != itinerary.getInitialSize())
            {
                model.AddRange(itinerary.PlannedRoutes);
            }

            for (int i = model.Count; i < itinerary.getInitialSize(); i++)
            {
                PlannedRoute plannedRoute = new PlannedRoute
                {
                    Activities = new List<Activity>(5)
                };

                for (int j = 0; j < 5; j++)
                {
                    plannedRoute.Activities.Add(new Activity());
                }

                model.Add(plannedRoute);
            }

            return model;
        }

        public void UpdateExistingPlanningRoute(PlannedRoute previousRoute, PlannedRoute plannedRoute)
        {

            previousRoute.Activities.Clear();
            previousRoute.Activities = plannedRoute.Activities;
            previousRoute.RouteDescription = plannedRoute.RouteDescription;

            plannedRouteRepository.Update(previousRoute);
        }
    }
}
