using System;
using System.Collections.Generic;
using System.Text;
using DomainModels.DAL;

namespace DAL.DomainRepositories
{
    public interface ITripRepository : IRepository<Trip>
    {
        IEnumerable<Trip> All { get; }
    }
}
