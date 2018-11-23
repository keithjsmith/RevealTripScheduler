using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.DAL
{
    public class TripStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        //sample data
        // Id : 1
        // Status : Active
        // Id : 2
        // Status : Canceled
    }
}
