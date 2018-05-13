using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class Amenities : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private SqlInt32		_createdUser, _lastModifiedUser, _amenitiesID, _quantity;
			private SqlMoney		_price;
			private SqlString		_description, _amenitiesName;
		#endregion


		public Amenities()
		{
			// Nothing for now.
		}


        public override  bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_Amenities_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@AmenitiesName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _amenitiesName));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _quantity));
				cmdToExecute.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _price));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				//cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				//cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@AmenitiesID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _amenitiesID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorDesc", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _errorDesc));
                
				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_amenitiesID = (SqlInt32)cmdToExecute.Parameters["@AmenitiesID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                _errorDesc = (SqlString)cmdToExecute.Parameters["@ErrorDesc"].Value;
				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Amenities_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Amenities::Insert::Error occured.", ex);
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
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Amenities_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@AmenitiesID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _amenitiesID));
                cmdToExecute.Parameters.Add(new SqlParameter("@AmenitiesName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _amenitiesName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
                //cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
              
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
              //  cmdToExecute.Parameters.Add(new SqlParameter("@ErrorDesc", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _errorDesc));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
              //  _amenitiesID = (SqlInt32)cmdToExecute.Parameters["@AmenitiesID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
              //  _errorDesc = (SqlString)cmdToExecute.Parameters["@ErrorDesc"].Value;
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                  //  throw new Exception("Stored Procedure 'pr_Amenities_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
               // throw new Exception("Amenities::Insert::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
            return true;
        }

        public override bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Amenities_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iAmenitiesID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _amenitiesID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'pr_Amenities_Delete' reported the ErrorCode: " + _errorCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Amenities::Delete::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }


        public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_Amenities_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("Amenities");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@AmenitiesID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _amenitiesID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_Amenities_SelectOneWAmenitiesIDLogic' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_amenitiesID = (Int32)toReturn.Rows[0]["AmenitiesID"];
					_amenitiesName = toReturn.Rows[0]["AmenitiesName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["AmenitiesName"];
					_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Description"];
					_quantity = toReturn.Rows[0]["Quantity"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Quantity"];
					_price = toReturn.Rows[0]["Price"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Price"];
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
				throw new Exception("Amenities::SelectOneWAmenitiesIDLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_Amenities_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("Amenities");
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
					throw new Exception("Stored Procedure 'pr_Amenities_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Amenities::SelectAll::Error occured.", ex);
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
		public SqlInt32 AmenitiesID
		{
			get
			{
				return _amenitiesID;
			}
			set
			{
				SqlInt32 amenitiesIDTmp = (SqlInt32)value;
				if(amenitiesIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AmenitiesID", "AmenitiesID can't be NULL");
				}
				_amenitiesID = value;
			}
		}


		public SqlString AmenitiesName
		{
			get
			{
				return _amenitiesName;
			}
			set
			{
				SqlString amenitiesNameTmp = (SqlString)value;
				if(amenitiesNameTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AmenitiesName", "AmenitiesName can't be NULL");
				}
				_amenitiesName = value;
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
				SqlString descriptionTmp = (SqlString)value;
				if(descriptionTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
				}
				_description = value;
			}
		}


		public SqlInt32 Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				SqlInt32 quantityTmp = (SqlInt32)value;
				if(quantityTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Quantity", "Quantity can't be NULL");
				}
				_quantity = value;
			}
		}


		public SqlMoney Price
		{
			get
			{
				return _price;
			}
			set
			{
				SqlMoney priceTmp = (SqlMoney)value;
				if(priceTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Price", "Price can't be NULL");
				}
				_price = value;
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
