using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class Itinerary : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public List<PlannedRoute> PlannedRoutes { get; set; }

        public Itinerary()
        {
            PlannedRoutes = new List<PlannedRoute>(getInitialSize());
        }

        public int getInitialSize()
        {
            return (EndDate.Date - StartDate.Date).Days;
        }

    }
}
