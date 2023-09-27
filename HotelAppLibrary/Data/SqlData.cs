using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
                                                        new { startDate, endDate },
                                                        connectionStringName,
                                                        true);
        }

        public void BookGuest(string firstName,
                              string lastName,
                              DateTime startDate,
                              DateTime endDate,
                              int roomTypeId) 
        {
            var guest = _db.LoadData<GuestModel, dynamic>("dbo.spGuests_Insert",
                                                          new { firstName, lastName },
                                                          connectionStringName,
                                                          true).First();

            var roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypes where Id = @Id",
                                                                new { Id = roomTypeId },
                                                                connectionStringName).First();

            var totalDays = endDate.Date.Subtract(startDate.Date).Days;

            var availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
                                                                  new { startDate, endDate, roomTypeId },
                                                                  connectionStringName,
                                                                  true);

            _db.SaveData("dbo.spBookings_Insert",
                         new 
                         { 
                             roomId = availableRooms.First().Id,
                             guestId = guest.Id,
                             startDate,
                             endDate,
                             totalCost = totalDays * roomType.Price
                         },
                         connectionStringName,
                         true);
        }

    }
}
