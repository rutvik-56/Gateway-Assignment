using System.Collections.Generic;
using Hotel.Models;
using Hotel.DB.Files;

namespace Hotel.Bussiness.Interface
{
    public class HotelManager : IHotelFiles
    {
        private readonly IHotelFiles _hotelRepo;

        public HotelManager(IHotelFiles hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public string BookRoom(BookingModel model)
        {
            return _hotelRepo.BookRoom(model);
        }

        public string CreateHotel(HotelModel model)
        {
           return  _hotelRepo.CreateHotel(model);
        }

        public string CreateRoom(RoomBokkingModel model)
        {
            return _hotelRepo.CreateRoom(model);
        }

        public string DeleteBookRoom(int Id)
        {
            return _hotelRepo.DeleteBookRoom(Id);
        }

        public List<HotelModel> GetAllHotels()
        {
            return _hotelRepo.GetAllHotels();
        }

        public BookingModel GetBookRoom(int Id)
        {
            return _hotelRepo.GetBookRoom(Id);
        }

        public List<BookingModel> GetBookRooms()
        {
            return _hotelRepo.GetBookRooms();   
        }

        public HotelModel GetHotel(int id)
        {
            return _hotelRepo.GetHotel(id);
        }

        public RoomBokkingModel GetRoom(int Id)
        {
            return _hotelRepo.GetRoom(Id);
        }

        public List<RoomBokkingModel> GetRooms()
        {
            return _hotelRepo.GetRooms();
        }

        public string UpdateBookRoom(BookingModel model)
        {
            return _hotelRepo.UpdateBookRoom(model);
        }

        public string UpdateHotel(HotelModel model)
        {
            return _hotelRepo.UpdateHotel(model);
        }

        public string UpdateRoom(RoomBokkingModel model)
        {
            return _hotelRepo.UpdateRoom(model);
        }
    }
}
