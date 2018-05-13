using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace HotelReservationSystemDAL.DAL
{
    public abstract class DataAccess
    {
        protected string ConnectionString
        {
            get
            {
                AppSettingsReader _configReader = new AppSettingsReader();
                string connectionString = _configReader.GetValue("Main.ConnectionString", typeof(string)).ToString();

                if (String.IsNullOrEmpty(connectionString))
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"aspnet_staterKits_TimeTracker\" value=\"Server=(local);Integrated Security=True;Database=Issue_Tracker\" </connectionStrings>"));
                else
                    return (connectionString);
            }
        }

        /*** RoomTypes ***/
        public abstract List<RoomTypes> GetRoomTypes();

        /*** RoomType_Image ***/
        public abstract List<RoomType_Image> GetRoomTypeImages();

        /*** RoomType_OnlineDetails ***/
        public abstract List<RoomType_OnlineDetails> GetRoomTypesOnlineDetails();

    }
}
