using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.DAL
{
    public class Trip
    {
        public int Id { get; set; }
        public int RiderId { get; set; }
        public int PickupLocationId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public int DropOffLocationId { get; set; }
        public int TripStatusId { get; set; }

    }
}
