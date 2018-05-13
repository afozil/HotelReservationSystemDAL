using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;

namespace HotelReservationSystemDAL
{
    public class Utility
    {
        public static List<WeekEnd> GetWeekEnds(DateTime startDate, DateTime endDate) 
        {
            if (endDate < startDate)
                throw new Exception("EndDate is before StartDate");

            List<WeekEnd> weekends = new List<WeekEnd>();
            TimeSpan diff = endDate - startDate;
            int days = diff.Days;
            int counter = 1;
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                DateTime weekendStart = new DateTime();
                DateTime weekendEnd = new DateTime();
                if (testDate.DayOfWeek.Equals(DayOfWeek.Thursday))
                {
                    weekendStart = testDate;
                    weekendEnd = testDate.AddDays(2);
                    if (weekendEnd.DayOfWeek.Equals(DayOfWeek.Saturday))
                    {
                        WeekEnd weekEnd = new WeekEnd(counter, weekendStart, weekendEnd);
                        weekends.Add(weekEnd);
                        counter++;
                    }
                }
            }
            return weekends;
        }

        public static DateTime GetCheckInTimeFromDate(DateTime checkInDate)
        {
            DateTime retDate = new DateTime(checkInDate.Year, checkInDate.Month, checkInDate.Day, CHECK_IN.HOURS, CHECK_IN.MINUTES, CHECK_IN.SECONDS);
            return retDate;
        }
        public static SqlDateTime GetSqlCheckInTimeFromDate(DateTime checkInDate)
        {
            SqlDateTime retDate = GetSqlDateTimeFromDateTime(GetCheckInTimeFromDate(checkInDate));
            return retDate;
        }

        public static DateTime GetCheckOutTimeFromDate(DateTime checkOuDate)
        {
            DateTime retDate = new DateTime(checkOuDate.Year, checkOuDate.Month, checkOuDate.Day, CHECK_OUT.HOURS, CHECK_OUT.MINUTES, CHECK_OUT.SECONDS);
            return retDate;
        }
        
        public static SqlDateTime GetSqlCheckOutTimeFromDate(DateTime checkOuDate)
        {
            SqlDateTime retDate = GetSqlDateTimeFromDateTime(GetCheckOutTimeFromDate(checkOuDate));
            return retDate;
        }


        public static int GetNumberOfDaysFromRange(DateTime fromDate, DateTime toDate)
        {
            if (toDate < fromDate) throw new Exception("To Date is less than From Date");

            int ret = 0;
            DateTime checkInTime = GetCheckInTimeFromDate(fromDate);
            DateTime checkOutTime = GetCheckOutTimeFromDate(toDate);
            TimeSpan diffrence = checkOutTime.Subtract(checkInTime);
            ret = (diffrence.Hours > 0) ? ret = diffrence.Days + 1 : ret = diffrence.Days;
            return ret;
        }

        public static DateTime GetDateTimeFromSqlDateTime(SqlDateTime sqlDate)
        {
            DateTime dDate = sqlDate.Value;
            return dDate;
        }
        public static SqlDateTime GetSqlDateTimeFromDateTime(DateTime dDate)
        {
            SqlDateTime sqlDate = new SqlDateTime(dDate.Year, dDate.Month, dDate.Day, dDate.Hour, dDate.Minute, dDate.Second);
            return sqlDate;
        }

        public static SqlInt32 GetUserIdFromUserName(string userName)
        {
            SqlInt32 ret = 0;
            Employees emp = new Employees();
            emp.UserName = userName;
            if (emp.SelectOneByUserName())
                ret = emp.Employee_ID;

            return ret;
        }

        public static Int32 GetIntUserIdFromUserName(string userName)
        {
            Int32 ret = 0;
            Employees emp = new Employees();
            emp.UserName = userName;
            if (emp.SelectOneByUserName())
                ret = Convert.ToInt32(emp.Employee_ID);

            return ret;
        }

        public static bool IsValidCivilId(string civilId)
        {
            if (string.IsNullOrEmpty(civilId))
                return false;

            if (civilId.Length != 12)
                return false;

            decimal civilIdDecimal;

            if (!decimal.TryParse(civilId, out civilIdDecimal))
                return false;

            int calculation;

            int monthPart = int.Parse(civilId.Substring(3, 2));
            int dayPart = int.Parse(civilId.Substring(3, 2));


            if ((monthPart > 12 || monthPart < 1) || (dayPart > 31 || dayPart < 1))
            {
                return false;
            }

            calculation = 2 * int.Parse(civilId.Substring(0, 1)) + 1 * int.Parse(civilId.Substring(1, 1)) + 6 * int.Parse(civilId.Substring(2, 1)) + 3 * int.Parse(civilId.Substring(3, 1)) + 7 * int.Parse(civilId.Substring(4, 1)) + 9 * int.Parse(civilId.Substring(5, 1)) + 10 * int.Parse(civilId.Substring(6, 1)) + 5 * int.Parse(civilId.Substring(7, 1)) + 8 * int.Parse(civilId.Substring(8, 1)) + 4 * int.Parse(civilId.Substring(9, 1)) + 2 * int.Parse(civilId.Substring(10, 1));

            calculation = calculation % 11;

            calculation = 11 - calculation;

            if (calculation != int.Parse(civilId.Substring(11, 1)))
                return false;
            else
                return true;
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}
