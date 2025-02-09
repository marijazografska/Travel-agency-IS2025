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
    public class ItineraryService : IItineraryService
    {
        private readonly IRepository<Itinerary> itineraryRepository;
        private readonly IRepository<Product> ProductRepository;

        public ItineraryService(IRepository<Itinerary> itineraryRepository, IRepository<Product> ProductRepository)
        {
            this.itineraryRepository = itineraryRepository;
            this.ProductRepository = ProductRepository;
        }

        public bool CreateNewItinerary(Itinerary i)
        {
            if (i.StartDate.CompareTo(i.EndDate) >= 0)
            {
                return false;
            }
            List<Itinerary> itineraries = itineraryRepository.GetAll().ToList();
            itineraryRepository.Insert(i);
            
            Product product = ProductRepository.Get(i.ProductId);
            product.ItineraryId = i.Id;
            product.AlreadyhasItinerary = true;
            ProductRepository.Update(product);
            
            return true;

            
        }

        public void DeleteItinerary(Guid id)
        {
            Itinerary itinerary = itineraryRepository.Get(id);
            Product product = ProductRepository.Get(itinerary.ProductId);

            itineraryRepository.Delete(itinerary);

            product.AlreadyhasItinerary = false;
            product.ItineraryId = null;
            ProductRepository.Update(product);
        }

        public List<Itinerary> GetAllItineraries()
        {
            return itineraryRepository.GetAll().ToList();
        }

        public Itinerary GetDetailsForItinerary(Guid? id)
        {
            return itineraryRepository.Get(id);
        }

        public Itinerary GetItineratyForProduct(Guid? id)
        {
            return itineraryRepository.GetAll().SingleOrDefault(s => s.ProductId == id);
        }

        public void UpdateExistingItinerary(Itinerary i)
        {
            itineraryRepository.Update(i);
        }
    }
}
