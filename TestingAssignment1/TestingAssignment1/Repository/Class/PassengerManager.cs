using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestingAssignment1.Database;
using TestingAssignment1.Repository.Interface;

namespace TestingAssignment1.Repository.Class
{
    public class PassengerManager : IPassengerManager
    {
        private readonly TestingEntities _db;
        public PassengerManager()
        {
            _db = new TestingEntities();
        }
        public int CreatePassenger(Passenger passengers)
        {
            try
            {
                _db.Passenger.Add(passengers);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeletePassenger(int id)
        {
            try
            {
                var passengerfromdb = _db.Passenger.Find(id);
                _db.Passenger.Remove(passengerfromdb);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Passenger GetPassenger(int id)
        {
            try
            {
                var passengerfromdb = _db.Passenger.Find(id);
                return passengerfromdb;
            }
            catch
            {
                return null;
            }

        }

        public int UpdatePassenger(int id, Passenger passenger)
        {
            try
            {
                var passengerfromdb = _db.Passenger.Find(id);
                passengerfromdb.FirstName = passenger.FirstName;
                passengerfromdb.LastName = passenger.LastName;
                passengerfromdb.Phone = passenger.Phone;
                _db.Entry(passengerfromdb).State = EntityState.Modified;
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}