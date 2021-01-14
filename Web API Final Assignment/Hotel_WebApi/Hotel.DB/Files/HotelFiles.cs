using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DB.Files;
using Hotel.Models;

namespace Hotel.DB.Repository
{
    public class HotelFiles : IHotelFiles
    {
        private readonly DBfolder.HMSEntities dbcontext;

        public HotelFiles()
        {
            dbcontext = new DBfolder.HMSEntities();
        }

        public string CreateHotel(HotelModel item)
        {

            try
            {
                if (item != null)
                {
                    DBfolder.Hotel hotel = new DBfolder.Hotel();


                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreateDate = DateTime.Now;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive =item.IsActive;

                    dbcontext.Hotel.Add(hotel);
                    dbcontext.SaveChanges();

                    return "Hotel Added SuccesFully";
                }
                return "Data Is Not There!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<HotelModel> GetAllHotels()
        {
            List<HotelModel> list = new List<HotelModel>();

            var data = dbcontext.Hotel.OrderBy(x => x.HotelName).ToList();

            if (data != null)
            {
                foreach (var item in data)
                {
                    HotelModel hotel = new HotelModel();

                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreateDate = item.CreateDate;
                    hotel.UpdateDate = item.UpdateDate;
                    hotel.UpdatedBy = item.UpdatedBy;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;

                    list.Add(hotel);
                }

            }
                return list;
        }

        public HotelModel GetHotel(int id)
        {
            try
            {
                var item = dbcontext.Hotel.Find(id);
                if (item !=null)
                {
                    HotelModel hotel = new HotelModel();

                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreateDate = item.CreateDate;
                    hotel.UpdatedBy = item.UpdatedBy;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;

                    return hotel;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
        public string UpdateHotel(HotelModel model)
        {
             try
            {
                var item = dbcontext.Hotel.Find(model.Hotel_Id);
                if (item != null)
                {
                    DBfolder.Hotel hotel = new DBfolder.Hotel();


                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;
                    hotel.UpdateDate = item.UpdateDate;
                    hotel.UpdatedBy = item.UpdatedBy;

                    dbcontext.SaveChanges();

                    return "Hotel Updated SuccesFully";
                }
                return "Data Is Not There!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string CreateRoom(RoomBokkingModel entity)
        {
            try
            {
                if (entity != null)
                {
                   DBfolder.Room dealer = new DBfolder.Room();

                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.Room_Id = entity.Room_Id;
                    dealer.RoomName = entity.RoomName;
                    dealer.Category = entity.Category;
                    dealer.Price = entity.Price;
                    dealer.IsActive = entity.IsActive;
                    dealer.CreateDate = DateTime.Now;
                    dealer.CreatedBy = entity.CreatedBy;

                    dbcontext.Room.Add(dealer);
                    dbcontext.SaveChanges();

                    return "Successfully added Room!";
                }

                return "Model is null!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
         
        public List<RoomBokkingModel> GetRooms()
        {
            var entities = dbcontext.Room.ToList();

            List<RoomBokkingModel> list = new List<RoomBokkingModel>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    RoomBokkingModel dealer = new RoomBokkingModel();

                    ///TODO: Problem why manually?                     
                    dealer.Hotel_Id = item.Hotel_Id;
                    dealer.RoomName = item.RoomName;
                    dealer.Category = item.Category;
                    dealer.IsActive = item.IsActive;
                    dealer.Price = item.Price;
                    dealer.CreateDate = item.CreateDate;
                    dealer.UpdateDate = item.UpdateDate;
                    dealer.IsActive = item.IsActive;
                    dealer.CreatedBy = item.CreatedBy;
                    dealer.UpdatedBy = item.UpdatedBy;

                    list.Add(dealer);

                }
            }


            return list;

        }


        public RoomBokkingModel GetRoom(int Id)
        {
            var item = dbcontext.Room.Find(Id);


            RoomBokkingModel dealer = new RoomBokkingModel();

            if (item != null)
            {
                ///TODO: Problem why manually?                     
                ///TODO: Problem why manually?                     
                dealer.Hotel_Id = item.Hotel_Id;
                dealer.RoomName = item.RoomName;
                dealer.Category = item.Category;
                dealer.IsActive = item.IsActive;
                dealer.Price = item.Price;
                dealer.CreateDate = item.CreateDate;
                dealer.UpdateDate = item.UpdateDate;
                dealer.IsActive = item.IsActive;
                dealer.CreatedBy = item.CreatedBy;
                dealer.UpdatedBy = item.UpdatedBy;


            }

            return dealer;
        }


        public string UpdateRoom(RoomBokkingModel item)
        {
            try
            {
                var dealer = dbcontext.Room.Find(item.Hotel_Id);

                if (item != null)
                {
                    dealer.Hotel_Id = item.Hotel_Id;
                    dealer.RoomName = item.RoomName;
                    dealer.Category = item.Category;
                    dealer.IsActive = item.IsActive;
                    dealer.Price = item.Price;
                     dealer.UpdateDate = DateTime.Now;
                    dealer.IsActive = item.IsActive;
                     dealer.UpdatedBy = item.UpdatedBy;


                    dbcontext.SaveChanges();

                    return "Updated Room!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }




        public string BookRoom(BookingModel entity)

        {
            try
            {
                if (entity != null)
                {
                    DBfolder.Book dealer = new DBfolder.Book();

                    dealer.Booking_Id = entity.Booking_Id;
                     dealer.Room_Id = entity.Room_Id;
                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.StatusOfBooking = entity.StatusOfBooking;
                    dealer.IsActive = entity.IsActive;
                    
                    dbcontext.Book.Add(dealer);
                    dbcontext.SaveChanges();

                    return "Successfully Book!";
                }

                return "Model is null!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBookRoom(int Id)
        {
            try
            {

                var entity = dbcontext.Book.Find(Id);

                if (entity != null)
                {

                    dbcontext.Book.Remove(entity);
                    dbcontext.SaveChanges();

                    return "Booking  Deleted!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<BookingModel> GetBookRooms()
        {
            var entities = dbcontext.Book.ToList();

            List<BookingModel> list = new List<BookingModel>();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    BookingModel dealer = new BookingModel();

                    ///TODO: Problem why manually?                     
                    dealer.Booking_Id = entity.Booking_Id;
                    dealer.Room_Id = entity.Room_Id;
                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.StatusOfBooking = entity.StatusOfBooking;
                    dealer.IsActive = entity.IsActive;

                    list.Add(dealer);

                }
            }


            return list;

        }


        public BookingModel GetBookRoom(int Id)
        {
            var entity = dbcontext.Book.Find(Id);


            BookingModel dealer = new BookingModel();

            if (entity != null)
            {
                ///TODO: Problem why manually?                     
                dealer.Booking_Id = entity.Booking_Id;
                dealer.Room_Id = entity.Room_Id;
                dealer.Hotel_Id = entity.Hotel_Id;
                dealer.StatusOfBooking = entity.StatusOfBooking;
                dealer.IsActive = entity.IsActive;


            }

            return dealer;
        }


        public string UpdateBookRoom(BookingModel entity)
        {
            try
            {
                var dealer = dbcontext.Book.Find(entity.Booking_Id);

                if (entity != null)
                {
                    dealer.Booking_Id = entity.Booking_Id;
                    dealer.Room_Id = entity.Room_Id;
                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.StatusOfBooking = entity.StatusOfBooking;
                    dealer.IsActive = entity.IsActive;



                    dbcontext.SaveChanges();

                    return "Updated!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
