using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class AspNetUsers : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		_phoneNumberConfirmed, _twoFactorEnabled, _emailConfirmed, _lockoutEnabled;
			private SqlDateTime		_lockoutEndDateUtc;
			private SqlInt32		_accessFailedCount;
			private SqlString		_userName, _email, _id, _passwordHash, _phoneNumber, _securityStamp;
		#endregion


		public AspNetUsers()
		{
			// Nothing for now.
		}


		public  bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _id));
				cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 256, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _email));
				cmdToExecute.Parameters.Add(new SqlParameter("@EmailConfirmed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _emailConfirmed));
				cmdToExecute.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _passwordHash));
				cmdToExecute.Parameters.Add(new SqlParameter("@SecurityStamp", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _securityStamp));
				cmdToExecute.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _phoneNumber));
				cmdToExecute.Parameters.Add(new SqlParameter("@PhoneNumberConfirmed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _phoneNumberConfirmed));
				cmdToExecute.Parameters.Add(new SqlParameter("@TwoFactorEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _twoFactorEnabled));
				cmdToExecute.Parameters.Add(new SqlParameter("@LockoutEndDateUtc", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lockoutEndDateUtc));
				cmdToExecute.Parameters.Add(new SqlParameter("@LockoutEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lockoutEnabled));
				cmdToExecute.Parameters.Add(new SqlParameter("@AccessFailedCount", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _accessFailedCount));
				cmdToExecute.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 256, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _userName));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (Int32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AspNetUsers_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AspNetUsers::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _id));
				cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 256, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _email));
				cmdToExecute.Parameters.Add(new SqlParameter("@EmailConfirmed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _emailConfirmed));
				cmdToExecute.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _passwordHash));
				cmdToExecute.Parameters.Add(new SqlParameter("@SecurityStamp", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _securityStamp));
				cmdToExecute.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _phoneNumber));
				cmdToExecute.Parameters.Add(new SqlParameter("@PhoneNumberConfirmed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _phoneNumberConfirmed));
				cmdToExecute.Parameters.Add(new SqlParameter("@TwoFactorEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _twoFactorEnabled));
				cmdToExecute.Parameters.Add(new SqlParameter("@LockoutEndDateUtc", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lockoutEndDateUtc));
				cmdToExecute.Parameters.Add(new SqlParameter("@LockoutEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lockoutEnabled));
				cmdToExecute.Parameters.Add(new SqlParameter("@AccessFailedCount", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _accessFailedCount));
				cmdToExecute.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 256, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _userName));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (Int32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AspNetUsers_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AspNetUsers::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _id));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (Int32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AspNetUsers_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AspNetUsers::Delete::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AspNetUsers");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _id));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AspNetUsers_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_id = (string)toReturn.Rows[0]["Id"];
					_email = toReturn.Rows[0]["Email"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Email"];
					_emailConfirmed = (bool)toReturn.Rows[0]["EmailConfirmed"];
					_passwordHash = toReturn.Rows[0]["PasswordHash"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PasswordHash"];
					_securityStamp = toReturn.Rows[0]["SecurityStamp"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["SecurityStamp"];
					_phoneNumber = toReturn.Rows[0]["PhoneNumber"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PhoneNumber"];
					_phoneNumberConfirmed = (bool)toReturn.Rows[0]["PhoneNumberConfirmed"];
					_twoFactorEnabled = (bool)toReturn.Rows[0]["TwoFactorEnabled"];
					_lockoutEndDateUtc = toReturn.Rows[0]["LockoutEndDateUtc"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["LockoutEndDateUtc"];
					_lockoutEnabled = (bool)toReturn.Rows[0]["LockoutEnabled"];
					_accessFailedCount = (Int32)toReturn.Rows[0]["AccessFailedCount"];
					_userName = (string)toReturn.Rows[0]["UserName"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AspNetUsers::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


		public  DataTable SelectOneByUserName()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_SelectOneByUserName]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AspNetUsers");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 256, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _userName));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AspNetUsers_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_id = (string)toReturn.Rows[0]["Id"];
					_email = toReturn.Rows[0]["Email"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Email"];
					_emailConfirmed = (bool)toReturn.Rows[0]["EmailConfirmed"];
					_passwordHash = toReturn.Rows[0]["PasswordHash"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PasswordHash"];
					_securityStamp = toReturn.Rows[0]["SecurityStamp"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["SecurityStamp"];
					_phoneNumber = toReturn.Rows[0]["PhoneNumber"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PhoneNumber"];
					_phoneNumberConfirmed = (bool)toReturn.Rows[0]["PhoneNumberConfirmed"];
					_twoFactorEnabled = (bool)toReturn.Rows[0]["TwoFactorEnabled"];
					_lockoutEndDateUtc = toReturn.Rows[0]["LockoutEndDateUtc"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["LockoutEndDateUtc"];
					_lockoutEnabled = (bool)toReturn.Rows[0]["LockoutEnabled"];
					_accessFailedCount = (Int32)toReturn.Rows[0]["AccessFailedCount"];
					_userName = (string)toReturn.Rows[0]["UserName"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AspNetUsers::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AspNetUsers");
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
					throw new Exception("Stored Procedure 'pr_AspNetUsers_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AspNetUsers::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


        public DataTable SelectRolesByUserID(string _userID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[getAspNetUserRolesBYUserID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Users");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@UserID", SqlDbType.VarChar, 128, ParameterDirection.Input, false, 128, 0, "", DataRowVersion.Proposed, _userID));
                //  cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                /*
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Users_SelectAll' reported the ErrorCode: " + _errorCode);
                }
                */
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Users::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public bool UpdateLockOut(string userName, string lockout)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_AspNetUsers_UpdateLockOut]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 256, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, userName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Lockout", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bool.Parse(lockout)));


                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("AspNetUsers::Update LockOut::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
        }





		#region Class Property Declarations
		public SqlString Id
		{
			get
			{
				return _id;
			}
			set
			{
				SqlString idTmp = (SqlString)value;
				if(idTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
				}
				_id = value;
			}
		}


		public SqlString Email
		{
			get
			{
				return _email;
			}
			set
			{
				SqlString emailTmp = (SqlString)value;
				if(emailTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Email", "Email can't be NULL");
				}
				_email = value;
			}
		}


		public SqlBoolean EmailConfirmed
		{
			get
			{
				return _emailConfirmed;
			}
			set
			{
				SqlBoolean emailConfirmedTmp = (SqlBoolean)value;
				if(emailConfirmedTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("EmailConfirmed", "EmailConfirmed can't be NULL");
				}
				_emailConfirmed = value;
			}
		}


		public SqlString PasswordHash
		{
			get
			{
				return _passwordHash;
			}
			set
			{
				SqlString passwordHashTmp = (SqlString)value;
				if(passwordHashTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PasswordHash", "PasswordHash can't be NULL");
				}
				_passwordHash = value;
			}
		}


		public SqlString SecurityStamp
		{
			get
			{
				return _securityStamp;
			}
			set
			{
				SqlString securityStampTmp = (SqlString)value;
				if(securityStampTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SecurityStamp", "SecurityStamp can't be NULL");
				}
				_securityStamp = value;
			}
		}


		public SqlString PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
			set
			{
				SqlString phoneNumberTmp = (SqlString)value;
				if(phoneNumberTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PhoneNumber", "PhoneNumber can't be NULL");
				}
				_phoneNumber = value;
			}
		}


		public SqlBoolean PhoneNumberConfirmed
		{
			get
			{
				return _phoneNumberConfirmed;
			}
			set
			{
				SqlBoolean phoneNumberConfirmedTmp = (SqlBoolean)value;
				if(phoneNumberConfirmedTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PhoneNumberConfirmed", "PhoneNumberConfirmed can't be NULL");
				}
				_phoneNumberConfirmed = value;
			}
		}


		public SqlBoolean TwoFactorEnabled
		{
			get
			{
				return _twoFactorEnabled;
			}
			set
			{
				SqlBoolean twoFactorEnabledTmp = (SqlBoolean)value;
				if(twoFactorEnabledTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TwoFactorEnabled", "TwoFactorEnabled can't be NULL");
				}
				_twoFactorEnabled = value;
			}
		}


		public SqlDateTime LockoutEndDateUtc
		{
			get
			{
				return _lockoutEndDateUtc;
			}
			set
			{
				SqlDateTime lockoutEndDateUtcTmp = (SqlDateTime)value;
				if(lockoutEndDateUtcTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LockoutEndDateUtc", "LockoutEndDateUtc can't be NULL");
				}
				_lockoutEndDateUtc = value;
			}
		}


		public SqlBoolean LockoutEnabled
		{
			get
			{
				return _lockoutEnabled;
			}
			set
			{
				SqlBoolean lockoutEnabledTmp = (SqlBoolean)value;
				if(lockoutEnabledTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LockoutEnabled", "LockoutEnabled can't be NULL");
				}
				_lockoutEnabled = value;
			}
		}


		public SqlInt32 AccessFailedCount
		{
			get
			{
				return _accessFailedCount;
			}
			set
			{
				SqlInt32 accessFailedCountTmp = (SqlInt32)value;
				if(accessFailedCountTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AccessFailedCount", "AccessFailedCount can't be NULL");
				}
				_accessFailedCount = value;
			}
		}


		public SqlString UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				SqlString userNameTmp = (SqlString)value;
				if(userNameTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("UserName", "UserName can't be NULL");
				}
				_userName = value;
			}
		}
		#endregion
	}
}

