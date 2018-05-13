using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace HotelReservationSystemDAL
{
    public class WeekEnd
    {
        public WeekEnd(int weekEndNum, SqlDateTime start, SqlDateTime end)
        {
            weekEnd_Number = weekEndNum;
            startDate = start;
            endDate = end;
        }
        private int weekEnd_Number;
        private SqlDateTime startDate;
        private SqlDateTime endDate;
        private int numberOfDays;
        

        public int Weekend_Number
        {
            get { return weekEnd_Number; }
            set { weekEnd_Number = value; }
        }

        public SqlDateTime StartDate
        {
            get { return Utility.GetSqlCheckInTimeFromDate(Utility.GetDateTimeFromSqlDateTime(startDate)); }
            set { startDate = value; }
        }

        public SqlDateTime EndDate
        {
            get { return Utility.GetSqlCheckOutTimeFromDate(Utility.GetDateTimeFromSqlDateTime(endDate)); }
            set { endDate = value; }
        }

        public int NumberOfDays
        {
            get { return Utility.GetNumberOfDaysFromRange(Utility.GetDateTimeFromSqlDateTime(startDate),Utility.GetDateTimeFromSqlDateTime(endDate)); }
        }
    }
}
