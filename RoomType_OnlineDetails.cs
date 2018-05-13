using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using HotelReservationSystemDAL.DAL;

namespace HotelReservationSystemDAL
{
	public class RoomType_OnlineDetails : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private SqlInt32		_createdUser, _lastModifiedUser, _roomType_ID, _roomType_Online_ID, _num_rooms, _num_adults, _num_kids,
                _number_Of_LivingRooms, _number_Of_Kitchen, _number_Of_BedRooms, _number_Of_Bathroom;
			private SqlString		_description ;
            
			
		#endregion


		public RoomType_OnlineDetails()
		{
			// Nothing for now.
		}
		
        public RoomType_OnlineDetails(SqlInt32 roomType_ID, SqlInt32 createdUser, SqlInt32 lastModifiedUser, 
            SqlInt32 roomType_Online_ID, SqlInt32 num_Rooms, SqlInt32 num_adults, SqlInt32 num_kids,
            SqlInt32 number_Of_LivingRooms, SqlInt32 number_Of_Kitchen, SqlInt32 number_Of_BedRooms, SqlInt32 number_Of_Bathroom,
                        SqlString description, 
                        SqlDateTime	createdDate, SqlDateTime lastModifiedDate
            )
        {
            _roomType_ID = roomType_ID;
			_roomType_Online_ID = roomType_Online_ID;
			_num_rooms = num_Rooms;
			_num_adults = num_adults;
			_num_kids = num_kids;
            _description = description;
            _number_Of_LivingRooms = number_Of_LivingRooms;
            _number_Of_Kitchen = number_Of_Kitchen;
            _number_Of_BedRooms = number_Of_BedRooms;
            _number_Of_Bathroom = number_Of_Bathroom;
            _createdUser = createdUser;
            _lastModifiedUser = lastModifiedUser;
            _createdDate = createdDate;
            _lastModifiedDate = lastModifiedDate;
        }

		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomType_OnlineDetails_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                int contentLen = _description.ToString().Length;

                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.Text, contentLen, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
                /*
				cmdToExecute.Parameters.Add(new SqlParameter("@Num_Rooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _num_rooms));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@Num_Adults", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _num_adults));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@Num_Kids", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _num_kids));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_LivinRooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_LivingRooms));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_Kitchens", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_Kitchen));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_BedRooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_BedRooms));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_BathRooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_Bathroom));
                */
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_Online_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _roomType_Online_ID));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_roomType_Online_ID = (SqlInt32)cmdToExecute.Parameters["@RoomType_Online_ID"].Value;
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
				throw new Exception("RoomType_OnlineDetails::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_OnlineDetails_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                int contentLen = _description.ToString().Length;
                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.Text, contentLen, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
                /*
				cmdToExecute.Parameters.Add(new SqlParameter("@Num_Rooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _num_rooms));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@Num_Adults", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _num_adults));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@Num_Kids", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _num_kids));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_LivinRooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_LivingRooms));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_Kitchens", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_Kitchen));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_BedRooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_BedRooms));

                cmdToExecute.Parameters.Add(new SqlParameter("@Num_BathRooms", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _number_Of_Bathroom));
                */
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_Online_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_Online_ID));
				
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomTypes_OnlineDetails_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_OnlineDetails::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_OnlineDetails_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_Online_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_RoomType_OnlineDetails_Delete' reported the ErrorCode: " + _errorCode);
                    return false;
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_OnlineDetails::Delete::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_OnlineDetails_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RoomType_OnlineDetails");
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
					throw new Exception("Stored Procedure 'pr_RoomType_OnlineDetails_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_roomType_Online_ID = (Int32)toReturn.Rows[0]["RoomType_Online_ID"];
					_roomType_ID = (Int32)toReturn.Rows[0]["RoomType_ID"];
					_description = toReturn.Rows[0]["RoomType_OnlineDetails"] == System.DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["RoomType_OnlineDetails"];
					//_createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
                    //_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
                    //_lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
                    //_lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
                    /*_num_rooms = (Int32)toReturn.Rows[0]["Number_Of_Rooms"];
					_num_adults = (Int32)toReturn.Rows[0]["Number_Of_Adults"];
					_num_kids = (Int32)toReturn.Rows[0]["Number_Of_Children"];
                    _number_Of_Bathroom = (Int32)toReturn.Rows[0]["Number_Of_Bathrooms"]; 
                    _number_Of_BedRooms = (Int32)toReturn.Rows[0]["Number_Of_BedRooms"];
                    _number_Of_Kitchen = (Int32)toReturn.Rows[0]["Number_Of_Kitchen"];
                    _number_Of_LivingRooms = (Int32)toReturn.Rows[0]["Number_Of_LivingRooms"];*/
                }
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_OnlineDetails::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_OnlineDetails_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RoomType_OnlineDetails");
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
					throw new Exception("Stored Procedure 'pr_RoomType_OnlineDetails_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_OnlineDetails::SelectAll::Error occured.", ex);
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
		public SqlInt32 RoomType_Online_ID
		{
			get
			{
				return _roomType_Online_ID;
			}
			set
			{
				Int32 roomType_Online_IDTmp = (Int32)value;
                //if(roomType_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("RoomType_ID", "RoomType_ID can't be NULL");
                //}
				_roomType_Online_ID = value;
			}
		}
		
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


		public SqlInt32 Number_of_Adults
		{
			get
			{
				return _num_adults;
			}
			set
			{
				Int32 _num_adultsTmp = (Int32)value;
				_num_adults = value;
			}
		}

        public SqlInt32 Number_of_Children
        {
            get
            {
                return _num_kids;
            }
            set
            {
                Int32 _num_kidsTmp = (Int32)value;
                _num_kids = value;
            }
        }


        public SqlInt32 Number_of_Rooms
		{
			get
			{
				return _num_rooms;
			}
			set
			{
				Int32 _num_roomsTmp = (Int32)value;
                //if(roomType_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("RoomType_ID", "RoomType_ID can't be NULL");
                //}
				_num_rooms = value;
			}
		}

        public SqlInt32 Number_of_BedRooms
        {
            get
            {
                return _number_Of_BedRooms ;
            }
            set
            {
                Int32 _number_Of_BedRoomsTmp = (Int32)value;
                _number_Of_BedRooms = value;
            }
        }

        public SqlInt32 Number_of_BathRooms
        {
            get
            {
                return _number_Of_Bathroom;
            }
            set
            {
                Int32 _number_Of_BathroomTmp = (Int32)value;
                _number_Of_Bathroom = value;
            }
        }

        public SqlInt32 Number_of_LivingRooms
        {
            get
            {
                return _number_Of_LivingRooms;
            }
            set
            {
                Int32 _number_Of_LivingRoomsTmp = (Int32)value;
                _number_Of_LivingRooms = value;
            }
        }

        public SqlInt32 Number_of_Kitchens
        {
            get
            {
                return _number_Of_Kitchen;
            }
            set
            {
                Int32 _number_Of_KitchenTmp = (Int32)value;
                _number_Of_Kitchen = value;
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

		#endregion


        public static List<RoomType_OnlineDetails> GetRoomTypesOnlineDetails()
        {
            DataAccess dal = DataAccessHelper.GetDataAccess();
            List<RoomType_OnlineDetails> roomType_OnlineDetails = dal.GetRoomTypesOnlineDetails();
            return roomType_OnlineDetails;
        }
	}


   
}
