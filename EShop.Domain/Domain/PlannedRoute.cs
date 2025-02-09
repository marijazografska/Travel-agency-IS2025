using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class PlannedRoute : BaseEntity
    {
        public string RouteDescription { get; set; }
        public List<Activity> Activities { get; set; }
        public Itinerary Itinerary { get; set; }
        public Guid ItineraryId { get; set; }
        public PlannedRoute()
        {
            this.Activities = new List<Activity>();
        }

    }
}
