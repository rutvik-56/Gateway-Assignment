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
    public class HMSController : ApiController
    {
        
        private readonly IHotelManager _hotelManager;

        public HMSController(IHotelManager hotelManager)
        {
           _hotelManager = hotelManager;
        }

         
        public List<HotelModel> GetHotels()
        {
            return _hotelManager.GetAllHotels();
        }

        public HotelModel Get(int id)
        {
            return _hotelManager.GetHotel(id);
        }

        public string Post([FromBody]HotelModel value)
        {
            return _hotelManager.CreateHotel(value);
        }

        public string Put( [FromBody]HotelModel value)
        {
            return _hotelManager.UpdateHotel(value);
        }

        public void Delete(int id)
        {
        }
    }
}
