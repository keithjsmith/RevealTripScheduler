using DAL.DomainRepositories;
using DAL.RepositoryClasses;
using DomainModels.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevealUnitTests
{
    [TestClass]
    public class TripsRepoTests
    {
        private static ITripRepository _trips;

        //Small sample set of unit tests

        [TestInitialize]
        public void Setup()
        {
            if (_trips == null)
            {
                _trips = new TripRepository();
                _trips.Add(FirstTrip());
                _trips.Add(SecondTrip());
                _trips.Add(ThirdTrip());
            }
        }

        [TestMethod]
        public void GetAllTrips()
        {
            var tripCount = _trips.All.Where(s => s.TripStatusId != 2);
            Assert.AreEqual(tripCount.Count(), 3);
        }

        [TestMethod]
        public void GetSingleTrip()
        {
            var secondTrip = _trips.All.FirstOrDefault(s => s.Id == 2 && s.TripStatusId != 2);
            Assert.IsNotNull(secondTrip);
        }

        [TestMethod]
        public void CancelTrip()
        {
            _trips.Cancel(2);
            var tripCount = _trips.All.Where(s => s.TripStatusId != 2);
            Assert.AreEqual(tripCount.Count(), 2, "Total trip count incorrect");
            var secondTrip = _trips.All.FirstOrDefault(s => s.Id == 2 && s.TripStatusId != 2);
            Assert.IsNull(secondTrip, "Trip not canceled properly");
        }

        [TestCleanup]
        public void Cleanup()
        {
            //dispose of any resources, close connections, etc
        }

        #region Test Data Assembly
        private Trip FirstTrip()
        {
            return new Trip()
            {
                Id = 1,
                DropOffLocationId = 1,
                PickupDateTime = DateTime.Now,
                PickupLocationId = 2,
                RiderId = 5,
                TripStatusId = 1
            }
            ;
        }

        private Trip SecondTrip()
        {
            return new Trip()
            {
                Id = 2,
                DropOffLocationId = 2,
                PickupDateTime = DateTime.Now,
                PickupLocationId = 2,
                RiderId = 4,
                TripStatusId = 1
            }
            ;
        }

        private Trip ThirdTrip()
        {
            return new Trip()
            {
                Id = 3,
                DropOffLocationId = 3,
                PickupDateTime = DateTime.Now,
                PickupLocationId = 2,
                RiderId = 2,
                TripStatusId = 1
            }
            ;
        }
        #endregion
    }
}
