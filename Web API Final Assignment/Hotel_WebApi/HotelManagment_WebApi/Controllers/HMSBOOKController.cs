using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hotel.Bussiness.Interface;
using Hotel.Models;

namespace HotelManagmentApi.Controllers
{
    public class HMSBOOKController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HMSBOOKController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        public List<BookingModel> Get()
        {
            return _hotelManager.GetBookRooms(); ;
        }

        public BookingModel Get(int id)
        {
            return _hotelManager.GetBookRoom(id);
        }

        public string Post([FromBody]BookingModel value)
        {
            return _hotelManager.BookRoom(value);
        }

        public string Put( [FromBody]BookingModel value)
        {
            return _hotelManager.UpdateBookRoom(value);
        }

        public string Delete(int id)
        {
            return _hotelManager.DeleteBookRoom(id);
        }
    }
}
