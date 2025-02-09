using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IPlannedRouteService
    {
        List<PlannedRoute> GetAllPlanningRoutes();
        PlannedRoute GetDetailsForPlanningRoute(Guid? id);
        void CreateNewPlanningRoute(PlannedRoute pr);
        void UpdateExistingPlanningRoute(PlannedRoute previousRoute, PlannedRoute plannedRoute);
        void DeletePlanningRoute(Guid id);
        //itinerartyID
        PlannedRoute getPlanningRouteForItineraty(Guid id);
        List<PlannedRoute> InitializePlannedRoutes(Itinerary itinerary);
    }
}
