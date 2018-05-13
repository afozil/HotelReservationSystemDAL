using System;
using System.Configuration;

namespace HotelReservationSystemDAL.DAL
{
    public class DataAccessHelper
    {
        public static DataAccess GetDataAccess()
        {
            string dataAccessStringType = "HotelReservationSystemDAL.DAL.SqlDataAccess";
           Type dataAccessType = Type.GetType(dataAccessStringType);
                DataAccess dc = (DataAccess)Activator.CreateInstance(dataAccessType);
                return (dc);
            }
       
    }
}
