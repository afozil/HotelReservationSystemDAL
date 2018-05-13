using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
  public  class CheckIn_CheckOut_Time: DBInteractionBase
    {
        #region Class Member Declarations
        private DateTime _createdDate, _lastModifiedDate;
        private int _createdUser, _checkOut_CheckIn_ID, _lastModifiedUser;
        private TimeSpan _checkIn_Time, _checkOut_Time;
        private bool _isActive;

      
        #endregion

        public CheckIn_CheckOut_Time()
		{
			// Nothing for now.
		}


        public bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_CheckIn_CheckOut_Time_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckIn_Time", SqlDbType.Time, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _checkIn_Time));
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckOut_Time", SqlDbType.Time, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _checkOut_Time));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _isActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _checkOut_CheckIn_ID = (Int32)cmdToExecute.Parameters["@CheckOut_CheckIn_ID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Rooms_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Rooms::Insert::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
        }



        public bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_CheckIn_CheckOut_Time_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckOut_CheckIn_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _checkOut_CheckIn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckIn_Time", SqlDbType.Time, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _checkIn_Time));
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckOut_Time", SqlDbType.Time, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _checkOut_Time));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _isActive));
               
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Rooms_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Rooms::Update::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
        }

        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_CheckIn_CheckOut_Time_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckOut_CheckIn_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _checkOut_CheckIn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Rooms_Delete' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Rooms::Delete::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
        }


        public DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_CheckIn_CheckOut_Time_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Rooms");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckOut_CheckIn_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _checkOut_CheckIn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Rooms_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _checkOut_CheckIn_ID = (Int32)toReturn.Rows[0]["CheckOut_CheckIn_ID"];
                    _checkIn_Time = (TimeSpan)toReturn.Rows[0]["CheckIn_Time"];
                    _checkOut_Time = (TimeSpan)toReturn.Rows[0]["CheckOut_Time"];
                   
                    _isActive = (bool)toReturn.Rows[0]["IsActive"];
                   
                  //  _createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
                    //_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
                   // _lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
                   // _lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Rooms::SelectOne::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }


        public DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_CheckIn_CheckOut_Time_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Rooms");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Rooms_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Rooms::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }













        #region Class Property Declarations
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public int CheckOut_CheckIn_ID
        {
            get
            {
                return _checkOut_CheckIn_ID;
            }
            set
            {
                int checkOut_CheckIn_IDTmp = (int)value;
                //if(room_IDTmp.)
                //{
                //    throw new ArgumentOutOfRangeException("Room_ID", "Room_ID can't be NULL");
                //}
                _checkOut_CheckIn_ID = value;
            }
        }


        public TimeSpan CheckIn_Time
        {
            get
            {
                return _checkIn_Time;
            }
            set
            {
              
                _checkIn_Time = value;
            }
        }


        public TimeSpan CheckOut_Time
        {
            get
            {
                return _checkOut_Time;
            }
            set
            {
                
                _checkOut_Time = value;
            }
        }


    
        public int CreatedUser
        {
            get
            {
                return _createdUser;
            }
            set
            {
                int createdUserTmp = (int)value;
                //if(createdUserTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("CreatedUser", "CreatedUser can't be NULL");
                ////}
                _createdUser = value;
            }
        }


        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                DateTime createdDateTmp = (DateTime)value;
                //if(createdDateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("CreatedDate", "CreatedDate can't be NULL");
                //}
                _createdDate = value;
            }
        }


        public int LastModifiedUser
        {
            get
            {
                return _lastModifiedUser;
            }
            set
            {
                int lastModifiedUserTmp = (int)value;
                //if(lastModifiedUserTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("LastModifiedUser", "LastModifiedUser can't be NULL");
                //}
                _lastModifiedUser = value;
            }
        }


        public DateTime LastModifiedDate
        {
            get
            {
                return _lastModifiedDate;
            }
            set
            {
                DateTime lastModifiedDateTmp = (DateTime)value;
                //if(lastModifiedDateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("LastModifiedDate", "LastModifiedDate can't be NULL");
                //}
                _lastModifiedDate = value;
            }
        }
        #endregion


    }

}
