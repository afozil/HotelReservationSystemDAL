using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using HotelReservationSystemDAL.DAL;

namespace HotelReservationSystemDAL
{
	public class RoomTypes : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private SqlInt32		_createdUser, _lastModifiedUser, _roomType_ID;
			private SqlString		_description, _roomType_EN, _roomType_AR;
            private SqlBoolean      _isOnline;
		#endregion


		public RoomTypes()
		{
			// Nothing for now.
		}
        public RoomTypes(SqlInt32 roomType_ID, SqlInt32 createdUser, SqlInt32 lastModifiedUser, 
                        SqlString description, SqlString roomType_EN, SqlString roomType_AR,
                        SqlDateTime	createdDate, SqlDateTime lastModifiedDate, SqlBoolean isOnline
            )
        {
            _roomType_ID = roomType_ID;
            _createdUser = createdUser;
            _lastModifiedUser = lastModifiedUser;
            _description = description;
            _roomType_EN = roomType_EN;
            _roomType_AR = roomType_AR;
            _createdDate = createdDate;
            _lastModifiedDate = lastModifiedDate;
            _isOnline = isOnline;
        }

		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomTypes_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_EN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _roomType_EN));
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_AR", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _roomType_AR));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsOnline", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _isOnline));
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_roomType_ID = (SqlInt32)cmdToExecute.Parameters["@RoomType_ID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_RoomTypes_Insert' reported the ErrorCode: " + _errorCode);
                    return false;
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomTypes::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomTypes_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_EN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _roomType_EN));
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_AR", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _roomType_AR));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				//cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				//cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsOnline", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _isOnline));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomTypes_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomTypes::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomTypes_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_RoomTypes_Delete' reported the ErrorCode: " + _errorCode);
                    return false;
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomTypes::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomTypes_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RoomTypes");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomTypes_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_roomType_ID = (Int32)toReturn.Rows[0]["RoomType_ID"];
					_roomType_EN = (string)toReturn.Rows[0]["RoomType_EN"];
					_roomType_AR = toReturn.Rows[0]["RoomType_AR"] == System.DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["RoomType_AR"];
					_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Description"];
					_createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
                    //_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
                    //_lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
                    //_lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
                    _isOnline = (Boolean)toReturn.Rows[0]["IsOnline"];
                }
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomTypes::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}




		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomTypes_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RoomTypes");
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

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomTypes_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomTypes::SelectAll::Error occured.", ex);
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
		public SqlInt32 RoomType_ID
		{
			get
			{
				return _roomType_ID;
			}
			set
			{
				Int32 roomType_IDTmp = (Int32)value;
                //if(roomType_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("RoomType_ID", "RoomType_ID can't be NULL");
                //}
				_roomType_ID = value;
			}
		}


		public SqlString RoomType_EN
		{
			get
			{
				return _roomType_EN;
			}
			set
			{
				String roomType_ENTmp = (String)value;
                //if(roomType_ENTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("RoomType_EN", "RoomType_EN can't be NULL");
                //}
				_roomType_EN = value;
			}
		}


		public SqlString RoomType_AR
		{
			get
			{
				return _roomType_AR;
			}
			set
			{
				String roomType_ARTmp = (String)value;
                //if(roomType_ARTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("RoomType_AR", "RoomType_AR can't be NULL");
                //}
				_roomType_AR = value;
			}
		}


		public SqlString Description
		{
			get
			{
				return _description;
			}
			set
			{
				String descriptionTmp = (String)value;
                //if(descriptionTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                //}
				_description = value;
			}
		}


		public SqlInt32 CreatedUser
		{
			get
			{
				return _createdUser;
			}
			set
			{
				Int32 createdUserTmp = (Int32)value;
                //if (createdUserTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("CreatedUser", "CreatedUser can't be NULL");
                //}
				_createdUser = value;
			}
		}


        public SqlDateTime CreatedDate
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


		public SqlInt32 LastModifiedUser
		{
			get
			{
				return _lastModifiedUser;
			}
			set
			{
				Int32 lastModifiedUserTmp = (Int32)value;
                //if(lastModifiedUserTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("LastModifiedUser", "LastModifiedUser can't be NULL");
                //}
				_lastModifiedUser = value;
			}
		}


		public SqlDateTime LastModifiedDate
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

        public SqlBoolean IsOnline
        {
            get
            {
                return _isOnline;
            }
            set
            {
                Boolean isOnline = (Boolean)value;
                _isOnline = value;
            }
        }
		#endregion


        public static List<RoomTypes> GetRoomTypes()
        {
            DataAccess dal = DataAccessHelper.GetDataAccess();
            List<RoomTypes> roomTypes = dal.GetRoomTypes();
            return roomTypes;
        }
	}


   
}
