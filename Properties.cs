using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class Properties : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private Int32		_createdUser, _lastModifiedUser;
			private Decimal		_propertyID;
			private String		_description, _propertyName_EN, _propertyName_AR;
		#endregion


		public Properties()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_Properties_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyName_EN", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _propertyName_EN));
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyName_AR", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _propertyName_AR));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				//cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
			    cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyID", SqlDbType.Decimal, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _propertyID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_propertyID = (Decimal)cmdToExecute.Parameters["@PropertyID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Properties_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Properties::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_Properties_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _propertyID));
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyName_EN", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _propertyName_EN));
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyName_AR", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _propertyName_AR));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				//cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				//cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Properties_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Properties::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_Properties_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _propertyID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Properties_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Properties::Delete::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_Properties_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("Properties");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@PropertyID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _propertyID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Properties_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_propertyID = (Decimal)toReturn.Rows[0]["PropertyID"];
					_propertyName_EN = (string)toReturn.Rows[0]["PropertyName_EN"];
					_propertyName_AR = toReturn.Rows[0]["PropertyName_AR"] == System.DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["PropertyName_AR"];
					_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Description"];
					//_createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
					//_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
					//_lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
					//_lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Properties::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_Properties_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("Properties");
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
					throw new Exception("Stored Procedure 'pr_Properties_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Properties::SelectAll::Error occured.", ex);
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
		public Decimal PropertyID
		{
			get
			{
				return _propertyID;
			}
			set
			{
				Decimal propertyIDTmp = (Decimal)value;
                //if(propertyIDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("PropertyID", "PropertyID can't be NULL");
                //}
				_propertyID = value;
			}
		}


		public String PropertyName_EN
		{
			get
			{
				return _propertyName_EN;
			}
			set
			{
				String propertyName_ENTmp = (String)value;
                //if(propertyName_ENTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("PropertyName_EN", "PropertyName_EN can't be NULL");
                //}
				_propertyName_EN = value;
			}
		}


		public String PropertyName_AR
		{
			get
			{
				return _propertyName_AR;
			}
			set
			{
				String propertyName_ARTmp = (String)value;
                //if(propertyName_ARTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("PropertyName_AR", "PropertyName_AR can't be NULL");
                //}
				_propertyName_AR = value;
			}
		}


		public String Description
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


		public Int32 CreatedUser
		{
			get
			{
				return _createdUser;
			}
			set
			{
				Int32 createdUserTmp = (Int32)value;
                //if(createdUserTmp.IsNull)
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
				SqlDateTime createdDateTmp = (SqlDateTime)value;
                //if(createdDateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("CreatedDate", "CreatedDate can't be NULL");
                //}
				_createdDate = value;
			}
		}


		public Int32 LastModifiedUser
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
				SqlDateTime lastModifiedDateTmp = (SqlDateTime)value;
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
