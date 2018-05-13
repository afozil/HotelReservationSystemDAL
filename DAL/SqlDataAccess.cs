using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Specialized;


namespace HotelReservationSystemDAL.DAL
{
    public class SqlDataAccess : DataAccess
    {
        private delegate void TGenerateListFromReader<T>(SqlDataReader returnData, ref List<T> tempList);


        /*****************************  SQL HELPER METHODS *****************************/
        private void AddParamToSQLCmd(SqlCommand sqlCmd,
                                      string paramId,
                                      SqlDbType sqlType,
                                      int paramSize,
                                      ParameterDirection paramDirection,
                                      object paramvalue)
        {

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = paramId;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = paramDirection;

            if (paramSize > 0)
                newSqlParam.Size = paramSize;

            if (paramvalue != null)
                newSqlParam.Value = paramvalue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        private void ExecuteScalarCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                sqlCmd.ExecuteScalar();
            }
        }
        private void SetCommandType(SqlCommand sqlCmd, CommandType cmdType, string cmdText)
        {
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandText = cmdText;
        }
        private void TExecuteReaderCmd<T>(SqlCommand sqlCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sqlCmd.Connection = cn;

                cn.Open();

                gcfr(sqlCmd.ExecuteReader(), ref List);
            }
        }

        /*****************************  SQL HELPER METHODS END *****************************/

        /***  Room Types ***/
        private string GET_ALL_ROOM_TYPES = "dbo.[pr_RoomTypes_SelectAll]";
        //private string SP_TIMEENTRY_GETUSERREPORTBYCATEGORY = "aspnet_starterkits_GetTimeEntryUserReportByCategoryId";
        
        public override List<RoomTypes> GetRoomTypes()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.StoredProcedure, GET_ALL_ROOM_TYPES);
            List<RoomTypes> roomTypes = new List<RoomTypes>();
            TExecuteReaderCmd<RoomTypes>(sqlCmd, TGenerateRoomTypesFromReader<RoomTypes>, ref roomTypes);
            return roomTypes;
        }
        public override List<RoomType_Image> GetRoomTypeImages()
        {
            List<RoomType_Image> rmType_Images = new List<RoomType_Image>();
            return rmType_Images;
        }
        public override List<RoomType_OnlineDetails> GetRoomTypesOnlineDetails()
        {
            List<RoomType_OnlineDetails> rmType_Onln_Dtls = new List<RoomType_OnlineDetails>();
            return rmType_Onln_Dtls;
        }



        private void TGenerateRoomTypesFromReader<T>(SqlDataReader returnData, ref List<RoomTypes> roomTypes)
        {
            RoomTypes roomType = new RoomTypes();
            while (returnData.Read())
            {
                roomType.RoomType_ID= returnData["RoomType_ID"] != DBNull.Value ? SqlInt32.Parse(returnData["roomType_ID"].ToString()) : 0;
                roomType.CreatedUser = returnData["CreatedUser"] != DBNull.Value ? SqlInt32.Parse(returnData["CreatedUser"].ToString()) :0;
                roomType.LastModifiedUser = returnData["LastModifiedUser"] != DBNull.Value ? SqlInt32.Parse(returnData["LastModifiedUser"].ToString()) : 0;
                roomType.Description = returnData["Description"] != DBNull.Value ? returnData["Description"].ToString() : string.Empty;
                roomType.CreatedDate = returnData["CreatedDate"] != DBNull.Value ? SqlDateTime.Parse(returnData["CreatedDate"].ToString()) : DateTime.Today;
                roomType.LastModifiedDate = returnData["LastModifiedDate"] != DBNull.Value ? SqlDateTime.Parse(returnData["LastModifiedDate"].ToString()) : DateTime.Today;
                roomTypes.Add(roomType);
            }
        }
    }
}
