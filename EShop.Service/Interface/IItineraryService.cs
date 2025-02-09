using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IItineraryService
    {
        List<Itinerary> GetAllItineraries();
        Itinerary GetDetailsForItinerary(Guid? id);
        bool CreateNewItinerary(Itinerary i);
        void UpdateExistingItinerary(Itinerary i);
        void DeleteItinerary(Guid id);
        //TravelPackageId
        Itinerary GetItineratyForProduct(Guid? id);
    }
}
