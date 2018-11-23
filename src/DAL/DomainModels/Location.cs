using System;

namespace DomainModels.DAL
{
    public class Location
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Longitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; } //zip as a string makes it easier to handle -####

    }
}
