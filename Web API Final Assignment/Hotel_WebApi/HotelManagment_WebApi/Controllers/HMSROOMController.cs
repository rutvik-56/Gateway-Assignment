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
    public class HMSROOMController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HMSROOMController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        public List<RoomBokkingModel> Get()
        {
            return _hotelManager.GetRooms();
        }

        public RoomBokkingModel Get(int id)
        {
            return _hotelManager.GetRoom(id);
        }

        public string Post([FromBody]RoomBokkingModel value)
        {
            return _hotelManager.CreateRoom(value);
        }

        public string Put( [FromBody]RoomBokkingModel value)
        {
            return _hotelManager.UpdateRoom(value);
        }

       }

}
