using System.Data.Entity;
using System.Web.Http;
using TestingAssignment1.Database;
using TestingAssignment1.Repository.Interface;

namespace TestingAssignment1.Controllers
{
    public class UserController : ApiController
    {
        private static IPassengerManager _passengerManager;
        public UserController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }
        // GET: User
       [HttpGet]
       public IHttpActionResult Get(int id)
        {
            var passenger=_passengerManager.GetPassenger(id);
            if (passenger != null)
            {
                return Ok(passenger);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: User/Create
        [HttpPost]
        public IHttpActionResult Create(Passenger passengers)
        {
            if (_passengerManager.CreatePassenger(passengers)==1)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }

       

        // POST: User/Edit/5
        [HttpPost]
        public IHttpActionResult Edit(int id, Passenger passenger)
        {
            if (_passengerManager.UpdatePassenger(id,passenger) == 1)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: User/Delete/5
        public IHttpActionResult Delete(int id)
        {
            if (_passengerManager.DeletePassenger(id) == 1)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
