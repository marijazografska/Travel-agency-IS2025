using EShop.Domain.Domain;
using EShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            if (typeof(T).IsAssignableFrom(typeof(Product)))
            {
                return entities.Include("Itinerary")
                     .Include("Itinerary.PlannedRoutes")
                     .Include("Itinerary.PlannedRoutes.Activities").AsEnumerable();
                     
            }
            if (typeof(T).IsAssignableFrom(typeof(PlannedRoute)))
            {
                return entities.Include("Itinerary")
                    .Include("Itinerary.Product").AsEnumerable();
            }
            if (typeof(T).IsAssignableFrom(typeof(Itinerary)))
            {
                return entities.Include("Product").Include("PlannedRoutes")
                    .Include("PlannedRoutes.Activities").AsEnumerable();
            }
            if (typeof(T).IsAssignableFrom(typeof(Order)))
            {
                return entities
                    .Include("EshopApplicationUser")
                    .Include("ProductInOrders")
                    .Include("ProductInOrders.Product.Itinerary")
                    .Include("ProductInOrders.Product.Itinerary.PlannedRoutes")
                    .Include("ProductInOrders.Product.Itinerary.PlannedRoutes.Activities")
                    .AsEnumerable();
            }
            return entities.AsEnumerable();
        }

        public T Get(Guid? id)
        {
            if (typeof(T).IsAssignableFrom(typeof(Product)))
            {
                return entities.Include("Itinerary")
                     .Include("Itinerary.PlannedRoutes")
                     .Include("Itinerary.PlannedRoutes.Activities").SingleOrDefault(s => s.Id == id);

            }
            if (typeof(T).IsAssignableFrom(typeof(PlannedRoute)))
            {
                return entities.Include("Itinerary")
                    .Include("Itinerary.Product").SingleOrDefault(s => s.Id == id);
            }
            if (typeof(T).IsAssignableFrom(typeof(Itinerary)))
            {
                return entities.Include("Product").Include("PlannedRoutes")
                    .Include("PlannedRoutes.Activities").SingleOrDefault(s => s.Id == id);
            }
            if (typeof(T).IsAssignableFrom(typeof(Order)))
            {
                return entities
                    .Include("EshopApplicationUser")
                    .Include("ProductInOrders")
                    .Include("ProductInOrders.Product.Itinerary")
                    .Include("ProductInOrders.Product.Itinerary.PlannedRoutes")
                    .Include("ProductInOrders.Product.Itinerary.PlannedRoutes.Activities")
                    .SingleOrDefault(s => s.Id == id);
            }


            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
