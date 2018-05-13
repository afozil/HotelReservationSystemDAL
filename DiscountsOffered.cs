///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'DiscountsOffered'
// Generated by LLBLGen v1.21.2003.712 Final on: Saturday, June 6, 2015, 10:39:48 AM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'DiscountsOffered'.
	/// </summary>
	public class DiscountsOffered : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private SqlInt32		_createdUser, _room_ID, _discount_ID, _lastModifiedUser, _rate_ID, _supervisor_ID, _employee_ID, _roomType_ID, _rateType_ID;
			private SqlMoney		_allowed_Discount;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public DiscountsOffered()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>Employee_ID</LI>
		///		 <LI>Supervisor_ID. May be SqlInt32.Null</LI>
		///		 <LI>Rate_ID. May be SqlInt32.Null</LI>
		///		 <LI>RateType_ID. May be SqlInt32.Null</LI>
		///		 <LI>RoomType_ID. May be SqlInt32.Null</LI>
		///		 <LI>Room_ID. May be SqlInt32.Null</LI>
		///		 <LI>Allowed_Discount</LI>
		///		 <LI>CreatedUser</LI>
		///		 <LI>LastModifiedUser</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>LastModifiedDate</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>Discount_ID</LI>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DiscountsOffered_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iEmployee_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _employee_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iSupervisor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _supervisor_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRate_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _rate_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRateType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _rateType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRoom_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _room_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@curAllowed_Discount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _allowed_Discount));
				cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@iLastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@daLastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _discount_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_discount_ID = (Int32)cmdToExecute.Parameters["@iDiscount_ID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DiscountsOffered_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DiscountsOffered::Insert::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>Discount_ID</LI>
		///		 <LI>Employee_ID</LI>
		///		 <LI>Supervisor_ID. May be SqlInt32.Null</LI>
		///		 <LI>Rate_ID. May be SqlInt32.Null</LI>
		///		 <LI>RateType_ID. May be SqlInt32.Null</LI>
		///		 <LI>RoomType_ID. May be SqlInt32.Null</LI>
		///		 <LI>Room_ID. May be SqlInt32.Null</LI>
		///		 <LI>Allowed_Discount</LI>
		///		 <LI>CreatedUser</LI>
		///		 <LI>LastModifiedUser</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>LastModifiedDate</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DiscountsOffered_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discount_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iEmployee_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _employee_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iSupervisor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _supervisor_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRate_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _rate_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRateType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _rateType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRoom_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _room_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@curAllowed_Discount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _allowed_Discount));
				cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@iLastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@daLastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DiscountsOffered_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DiscountsOffered::Update::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>Discount_ID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DiscountsOffered_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discount_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DiscountsOffered_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DiscountsOffered::Delete::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>Discount_ID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>Discount_ID</LI>
		///		 <LI>Employee_ID</LI>
		///		 <LI>Supervisor_ID</LI>
		///		 <LI>Rate_ID</LI>
		///		 <LI>RateType_ID</LI>
		///		 <LI>RoomType_ID</LI>
		///		 <LI>Room_ID</LI>
		///		 <LI>Allowed_Discount</LI>
		///		 <LI>CreatedUser</LI>
		///		 <LI>LastModifiedUser</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>LastModifiedDate</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DiscountsOffered_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("DiscountsOffered");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discount_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DiscountsOffered_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_discount_ID = (Int32)toReturn.Rows[0]["Discount_ID"];
					_employee_ID = (Int32)toReturn.Rows[0]["Employee_ID"];
					_supervisor_ID = toReturn.Rows[0]["Supervisor_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Supervisor_ID"];
					_rate_ID = toReturn.Rows[0]["Rate_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Rate_ID"];
					_rateType_ID = toReturn.Rows[0]["RateType_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["RateType_ID"];
					_roomType_ID = toReturn.Rows[0]["RoomType_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["RoomType_ID"];
					_room_ID = toReturn.Rows[0]["Room_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Room_ID"];
					_allowed_Discount = (Decimal)toReturn.Rows[0]["Allowed_Discount"];
					_createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
					_lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
					_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
					_lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DiscountsOffered::SelectOne::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


		/// <summary>
		/// Purpose: SelectAll method. This method will Select all rows from the table.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_EmployeeDiscounts_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("DiscountsOffered");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DiscountsOffered_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DiscountsOffered::SelectAll::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


		#region Class Property Declarations
		public SqlInt32 Discount_ID
		{
			get
			{
				return _discount_ID;
			}
			set
			{
				SqlInt32 discount_IDTmp = (SqlInt32)value;
				if(discount_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Discount_ID", "Discount_ID can't be NULL");
				}
				_discount_ID = value;
			}
		}


		public SqlInt32 Employee_ID
		{
			get
			{
				return _employee_ID;
			}
			set
			{
				SqlInt32 employee_IDTmp = (SqlInt32)value;
				if(employee_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Employee_ID", "Employee_ID can't be NULL");
				}
				_employee_ID = value;
			}
		}


		public SqlInt32 Supervisor_ID
		{
			get
			{
				return _supervisor_ID;
			}
			set
			{
				SqlInt32 supervisor_IDTmp = (SqlInt32)value;
				if(supervisor_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Supervisor_ID", "Supervisor_ID can't be NULL");
				}
				_supervisor_ID = value;
			}
		}


		public SqlInt32 Rate_ID
		{
			get
			{
				return _rate_ID;
			}
			set
			{
				SqlInt32 rate_IDTmp = (SqlInt32)value;
				if(rate_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Rate_ID", "Rate_ID can't be NULL");
				}
				_rate_ID = value;
			}
		}


		public SqlInt32 RateType_ID
		{
			get
			{
				return _rateType_ID;
			}
			set
			{
				SqlInt32 rateType_IDTmp = (SqlInt32)value;
				if(rateType_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("RateType_ID", "RateType_ID can't be NULL");
				}
				_rateType_ID = value;
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
				SqlInt32 roomType_IDTmp = (SqlInt32)value;
				if(roomType_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("RoomType_ID", "RoomType_ID can't be NULL");
				}
				_roomType_ID = value;
			}
		}


		public SqlInt32 Room_ID
		{
			get
			{
				return _room_ID;
			}
			set
			{
				SqlInt32 room_IDTmp = (SqlInt32)value;
				if(room_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Room_ID", "Room_ID can't be NULL");
				}
				_room_ID = value;
			}
		}


		public SqlMoney Allowed_Discount
		{
			get
			{
				return _allowed_Discount;
			}
			set
			{
				SqlMoney allowed_DiscountTmp = (SqlMoney)value;
				if(allowed_DiscountTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Allowed_Discount", "Allowed_Discount can't be NULL");
				}
				_allowed_Discount = value;
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
				SqlInt32 createdUserTmp = (SqlInt32)value;
				if(createdUserTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CreatedUser", "CreatedUser can't be NULL");
				}
				_createdUser = value;
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
				SqlInt32 lastModifiedUserTmp = (SqlInt32)value;
				if(lastModifiedUserTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LastModifiedUser", "LastModifiedUser can't be NULL");
				}
				_lastModifiedUser = value;
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
				SqlDateTime createdDateTmp = (SqlDateTime)value;
				if(createdDateTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CreatedDate", "CreatedDate can't be NULL");
				}
				_createdDate = value;
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
				SqlDateTime lastModifiedDateTmp = (SqlDateTime)value;
				if(lastModifiedDateTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LastModifiedDate", "LastModifiedDate can't be NULL");
				}
				_lastModifiedDate = value;
			}
		}
		#endregion
	}
}
