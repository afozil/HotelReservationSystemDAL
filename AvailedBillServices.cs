using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class AvailedBillServices : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_lastModifiedDate;
            private SqlInt32 _invoiceID, _lastModifiedUser, _availed_ID, _billsServices_ID, _checkIn_ID, _room_ID;
			private SqlMoney		_totalCost, _cost;
		#endregion


		public AvailedBillServices()
		{
			// Nothing for now.
		}


		public  bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AvailedBillServices_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@BillsServices_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _billsServices_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@CheckIn_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _checkIn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Room_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _room_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _invoiceID));
				cmdToExecute.Parameters.Add(new SqlParameter("@Cost", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _cost));
				cmdToExecute.Parameters.Add(new SqlParameter("@TotalCost", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _totalCost));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@Availed_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _availed_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_availed_ID = (SqlInt32)cmdToExecute.Parameters["@Availed_ID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AvailedBillServices_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AvailedBillServices::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public  bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AvailedBillServices_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Availed_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _availed_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@BillsServices_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _billsServices_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@CheckIn_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _checkIn_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _invoiceID));
				cmdToExecute.Parameters.Add(new SqlParameter("@Cost", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _cost));
				cmdToExecute.Parameters.Add(new SqlParameter("@TotalCost", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _totalCost));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AvailedBillServices_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AvailedBillServices::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public  bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AvailedBillServices_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Availed_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _availed_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AvailedBillServices_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AvailedBillServices::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public  DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AvailedBillServices_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AvailedBillServices");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Availed_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _availed_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AvailedBillServices_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_availed_ID = (Int32)toReturn.Rows[0]["Availed_ID"];
					_billsServices_ID = (Int32)toReturn.Rows[0]["BillsServices_ID"];
					_checkIn_ID = (Int32)toReturn.Rows[0]["CheckIn_ID"];
					_invoiceID = toReturn.Rows[0]["InvoiceID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["InvoiceID"];
					_cost = toReturn.Rows[0]["Cost"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Cost"];
					_totalCost = toReturn.Rows[0]["TotalCost"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["TotalCost"];
					_lastModifiedDate = toReturn.Rows[0]["LastModifiedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["LastModifiedDate"];
					_lastModifiedUser = toReturn.Rows[0]["LastModifiedUser"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["LastModifiedUser"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AvailedBillServices::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


        public DataTable SelectByCheckInID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_AvailedBillServices_ByCheckInID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("AvailedBillServices");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CheckIn_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _checkIn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_AvailedBillServices_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("AvailedBillServices::SelectOne::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }


		public  DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AvailedBillServices_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AvailedBillServices");
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
					throw new Exception("Stored Procedure 'pr_AvailedBillServices_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AvailedBillServices::SelectAll::Error occured.", ex);
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
		public SqlInt32 Availed_ID
		{
			get
			{
				return _availed_ID;
			}
			set
			{
				SqlInt32 availed_IDTmp = (SqlInt32)value;
				if(availed_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Availed_ID", "Availed_ID can't be NULL");
				}
				_availed_ID = value;
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
				
				_room_ID = value;
			}
		}
		public SqlInt32 BillsServices_ID
		{
			get
			{
				return _billsServices_ID;
			}
			set
			{
				SqlInt32 billsServices_IDTmp = (SqlInt32)value;
				if(billsServices_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("BillsServices_ID", "BillsServices_ID can't be NULL");
				}
				_billsServices_ID = value;
			}
		}


		public SqlInt32 CheckIn_ID
		{
			get
			{
				return _checkIn_ID;
			}
			set
			{
				SqlInt32 checkIn_IDTmp = (SqlInt32)value;
				if(checkIn_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CheckIn_ID", "CheckIn_ID can't be NULL");
				}
				_checkIn_ID = value;
			}
		}


		public SqlInt32 InvoiceID
		{
			get
			{
				return _invoiceID;
			}
			set
			{
				SqlInt32 invoiceIDTmp = (SqlInt32)value;
				if(invoiceIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("InvoiceID", "InvoiceID can't be NULL");
				}
				_invoiceID = value;
			}
		}


		public SqlMoney Cost
		{
			get
			{
				return _cost;
			}
			set
			{
				SqlMoney costTmp = (SqlMoney)value;
				if(costTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Cost", "Cost can't be NULL");
				}
				_cost = value;
			}
		}


		public SqlMoney TotalCost
		{
			get
			{
				return _totalCost;
			}
			set
			{
				SqlMoney totalCostTmp = (SqlMoney)value;
				if(totalCostTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TotalCost", "TotalCost can't be NULL");
				}
				_totalCost = value;
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
		#endregion
	}
}
