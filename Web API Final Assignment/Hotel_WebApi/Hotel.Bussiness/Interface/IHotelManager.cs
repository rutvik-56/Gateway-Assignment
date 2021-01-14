using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Bussiness.Interface
{
    public interface IHotelManager
    {
        List<HotelModel> GetAllHotels();
        HotelModel GetHotel(int id);
        string CreateHotel(HotelModel model);

        string UpdateHotel(HotelModel model);

        RoomBokkingModel GetRoom(int Id);
        List<RoomBokkingModel> GetRooms();
        string CreateRoom(RoomBokkingModel model);
        string UpdateRoom(RoomBokkingModel model);

        BookingModel GetBookRoom(int Id);
        List<BookingModel> GetBookRooms();
        string BookRoom(BookingModel model);
        string UpdateBookRoom(BookingModel model);
        string DeleteBookRoom(int Id);


    }
}
