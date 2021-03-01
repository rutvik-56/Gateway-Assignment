using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment1.Database;

namespace TestingAssignment1.Repository.Interface
{
    public interface IPassengerManager
    {
        Passenger GetPassenger(int id);
        int CreatePassenger(Passenger passenger);
        int UpdatePassenger(int id, Passenger passenger);
        int DeletePassenger(int id);
    
    }
}
