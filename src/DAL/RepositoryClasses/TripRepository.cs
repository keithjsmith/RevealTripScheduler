using System;
using System.Collections.Generic;
using System.Text;
using DAL.DomainRepositories;
using DomainModels.DAL;

namespace DAL.RepositoryClasses
{
    public class TripRepository : ITripRepository
    {
        private static List<Trip> _trips;

        public TripRepository()
        {
            if (_trips == null)
            {
                _trips = new List<Trip>();
            }
        }

        public IEnumerable<Trip> All => _trips;

        public void Add(Trip entity)
        {
            _trips.Add(entity);
        }

        public void Cancel(int entityId)
        {
            Trip entity = _trips.Find(s => s.Id == entityId);
            entity.TripStatusId = 2;
        }
    }
}
