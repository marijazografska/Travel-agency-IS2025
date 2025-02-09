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
            //for (int j = 0; j < itineraries.Count(); j++)
            //{
                //Itinerary itinerary = itineraries.ElementAt(j);
                //if (itinerary.ProductId.Equals(i.ProductId))
                //{
                    //return false;
                //}
            //}
            Product Product = ProductRepository.Get(i.ProductId);
            //Product.AlreadyhasItinerary = true;
            ProductRepository.Update(Product);
            itineraryRepository.Insert(i);
            return true;


            //itineraryRepository.Insert(i);
            //Itinerary itinerary = itineraryRepository.Get(i.Id);
            //if (!itinerary.Product.AlreadyhasItinerary)
            //{
            //    itinerary.Product.AlreadyhasItinerary = true;
            //    ProductRepository.Update(ProductRepository.Get(itinerary.ProductId));
            //    return true;
            //}
            //itineraryRepository.Delete(itinerary);
            //return false;
        }

        public void DeleteItinerary(Guid id)
        {
            Itinerary itinerary = itineraryRepository.Get(id);
            Product Product = ProductRepository.Get(itinerary.ProductId);
            if (Product != null)
            {
                //Product.AlreadyhasItinerary = false;
                ProductRepository.Update(Product);
            }
            itineraryRepository.Delete(itinerary);
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
