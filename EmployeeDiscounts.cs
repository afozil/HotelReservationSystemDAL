using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class EmployeeDiscounts : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private SqlInt32		_createdUser, _discountID, _lastModifiedUser, _employeeID, _discountStatus, _unitOfDiscount;
			private SqlMoney		_discount;
		#endregion


		public EmployeeDiscounts()
		{
			// Nothing for now.
		}


		public  bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_EmployeeDiscounts_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _employeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _discount));
				cmdToExecute.Parameters.Add(new SqlParameter("@DiscountStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discountStatus));
				cmdToExecute.Parameters.Add(new SqlParameter("@UnitOfDiscount", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _unitOfDiscount));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@DiscountID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _discountID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorDesc", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorDesc));
				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
                _discountID = (SqlInt32)cmdToExecute.Parameters["@DiscountID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                _errorDesc = cmdToExecute.Parameters["@ErrorDesc"].Value.ToString();

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_EmployeeDiscounts_Insert' reported the ErrorCode: " + _errorCode);
				}

				//return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				//throw new Exception("EmployeeDiscounts::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
            return true;
		}

        public bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_EmployeeDiscounts_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DiscountID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discountID));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _employeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@DiscountStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discountStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@UnitOfDiscount", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _unitOfDiscount));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
               
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorDesc", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorDesc));
                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
               // _discountID = (SqlInt32)cmdToExecute.Parameters["@DiscountID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                _errorDesc = cmdToExecute.Parameters["@ErrorDesc"].Value.ToString();

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'pr_EmployeeDiscounts_Insert' reported the ErrorCode: " + _errorCode);
                }

                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("EmployeeDiscounts::Insert::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
            return true;
        }
        

        public DataTable SelectOneByEmployeeID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_EmployeeDiscounts_SelectOneByEmployeeID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("EmployeeDiscounts");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _employeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_EmployeeDiscounts_SelectOneByEmployeeID' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _discountID = (Int32)toReturn.Rows[0]["DiscountID"];
                    _employeeID = toReturn.Rows[0]["EmployeeID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["EmployeeID"];
                    _discount = toReturn.Rows[0]["Discount"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Discount"];
                    _discountStatus = toReturn.Rows[0]["DiscountStatus"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["DiscountStatus"];
                    _unitOfDiscount = toReturn.Rows[0]["UnitOfDiscount"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["UnitOfDiscount"];
                    _createdUser = toReturn.Rows[0]["CreatedUser"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["CreatedUser"];
                    _createdDate = toReturn.Rows[0]["CreatedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["CreatedDate"];
                    _lastModifiedUser = toReturn.Rows[0]["LastModifiedUser"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["LastModifiedUser"];
                    _lastModifiedDate = toReturn.Rows[0]["LastModifiedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["LastModifiedDate"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("EmployeeDiscounts::SelectOneByEmployeeID::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }


		public DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_EmployeeDiscounts_SelectOneWDiscountIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("EmployeeDiscounts");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@DiscountID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discountID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_EmployeeDiscounts_SelectOneWDiscountIDLogic' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_discountID = (Int32)toReturn.Rows[0]["DiscountID"];
					_employeeID = toReturn.Rows[0]["EmployeeID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["EmployeeID"];
					_discount = toReturn.Rows[0]["Discount"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Discount"];
					_discountStatus = toReturn.Rows[0]["DiscountStatus"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["DiscountStatus"];
					_unitOfDiscount = toReturn.Rows[0]["UnitOfDiscount"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["UnitOfDiscount"];
					_createdUser = toReturn.Rows[0]["CreatedUser"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["CreatedUser"];
					_createdDate = toReturn.Rows[0]["CreatedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["CreatedDate"];
					_lastModifiedUser = toReturn.Rows[0]["LastModifiedUser"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["LastModifiedUser"];
					_lastModifiedDate = toReturn.Rows[0]["LastModifiedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["LastModifiedDate"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("EmployeeDiscounts::SelectOneWDiscountIDLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_EmployeeDiscounts_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("EmployeeDiscounts");
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
					throw new Exception("Stored Procedure 'pr_EmployeeDiscounts_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("EmployeeDiscounts::SelectAll::Error occured.", ex);
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
		public SqlInt32 DiscountID
		{
			get
			{
				return _discountID;
			}
			set
			{
				SqlInt32 discountIDTmp = (SqlInt32)value;
				if(discountIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DiscountID", "DiscountID can't be NULL");
				}
				_discountID = value;
			}
		}


		public SqlInt32 EmployeeID
		{
			get
			{
				return _employeeID;
			}
			set
			{
				SqlInt32 employeeIDTmp = (SqlInt32)value;
				if(employeeIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("EmployeeID", "EmployeeID can't be NULL");
				}
				_employeeID = value;
			}
		}


		public SqlMoney Discount
		{
			get
			{
				return _discount;
			}
			set
			{
				SqlMoney discountTmp = (SqlMoney)value;
				if(discountTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Discount", "Discount can't be NULL");
				}
				_discount = value;
			}
		}


		public SqlInt32 DiscountStatus
		{
			get
			{
				return _discountStatus;
			}
			set
			{
				SqlInt32 discountStatusTmp = (SqlInt32)value;
				if(discountStatusTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DiscountStatus", "DiscountStatus can't be NULL");
				}
				_discountStatus = value;
			}
		}


		public SqlInt32 UnitOfDiscount
		{
			get
			{
				return _unitOfDiscount;
			}
			set
			{
				SqlInt32 unitOfDiscountTmp = (SqlInt32)value;
				if(unitOfDiscountTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("UnitOfDiscount", "UnitOfDiscount can't be NULL");
				}
				_unitOfDiscount = value;
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


		public SqlDateTime CreatedDate
		{
			get
			{
				return _createdDate;
			}
			set
			{
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
				SqlInt32 lastModifiedUserTmp = (SqlInt32)value;
				if(lastModifiedUserTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LastModifiedUser", "LastModifiedUser can't be NULL");
				}
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
