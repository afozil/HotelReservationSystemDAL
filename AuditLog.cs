using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class AuditLog : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_logDate;
			private SqlInt32		 _logID;
			private SqlString		_userID,_logStatus, _error, _logURL, _logAction;
		#endregion


		public AuditLog()
		{
			// Nothing for now.
		}
        public bool Log(string logURL,string action,string logStatus,string Error,string userid)
        {
            _userID = userid;
            _logURL = logURL;
            _logStatus = logStatus;
            _logAction = action;
            _error = Error;
            return  Insert();
        }

		public  bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AuditLog_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@LogDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _logDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar,128, ParameterDirection.Input, false, 128, 0, "", DataRowVersion.Proposed, _userID));
				cmdToExecute.Parameters.Add(new SqlParameter("@LogURL", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _logURL));
				cmdToExecute.Parameters.Add(new SqlParameter("@LogAction", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _logAction));
				cmdToExecute.Parameters.Add(new SqlParameter("@LogStatus", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _logStatus));
				cmdToExecute.Parameters.Add(new SqlParameter("@Error", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _error));
				cmdToExecute.Parameters.Add(new SqlParameter("@LogID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _logID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_logID = (SqlInt32)cmdToExecute.Parameters["@LogID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AuditLog_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AuditLog::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		public DataTable SelectOneWLogIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AuditLog_SelectOneWLogIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AuditLog");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@LogID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _logID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_AuditLog_SelectOneWLogIDLogic' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_logID = (SqlInt32)toReturn.Rows[0]["LogID"];
					_logDate = toReturn.Rows[0]["LogDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["LogDate"];
                    _userID = toReturn.Rows[0]["UserID"] == System.DBNull.Value ? SqlString.Null : (SqlString)toReturn.Rows[0]["UserID"];
					_logURL = toReturn.Rows[0]["LogURL"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["LogURL"];
					_logAction = toReturn.Rows[0]["LogAction"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["LogAction"];
					_logStatus = toReturn.Rows[0]["LogStatus"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["LogStatus"];
					_error = toReturn.Rows[0]["Error"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Error"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AuditLog::SelectOneWLogIDLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_AuditLog_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("AuditLog");
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
					throw new Exception("Stored Procedure 'pr_AuditLog_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AuditLog::SelectAll::Error occured.", ex);
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
		public SqlInt32 LogID
		{
			get
			{
				return _logID;
			}
			set
			{
				SqlInt32 logIDTmp = (SqlInt32)value;
				if(logIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LogID", "LogID can't be NULL");
				}
				_logID = value;
			}
		}


		public SqlDateTime LogDate
		{
			get
			{
				return _logDate;
			}
			set
			{
				_logDate = value;
			}
		}


        public SqlString UserID
		{
			get
			{
				return _userID;
			}
			set
			{
                SqlString userIDTmp = (SqlString)value;
				if(userIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("UserID", "UserID can't be NULL");
				}
				_userID = value;
			}
		}


		public SqlString LogURL
		{
			get
			{
				return _logURL;
			}
			set
			{
				SqlString logURLTmp = (SqlString)value;
				if(logURLTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LogURL", "LogURL can't be NULL");
				}
				_logURL = value;
			}
		}


		public SqlString LogAction
		{
			get
			{
				return _logAction;
			}
			set
			{
				SqlString logActionTmp = (SqlString)value;
				if(logActionTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LogAction", "LogAction can't be NULL");
				}
				_logAction = value;
			}
		}


		public SqlString LogStatus
		{
			get
			{
				return _logStatus;
			}
			set
			{
				SqlString logStatusTmp = (SqlString)value;
				if(logStatusTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LogStatus", "LogStatus can't be NULL");
				}
				_logStatus = value;
			}
		}


		public SqlString Error
		{
			get
			{
				return _error;
			}
			set
			{
				SqlString errorTmp = (SqlString)value;
				if(errorTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Error", "Error can't be NULL");
				}
				_error = value;
			}
		}
		#endregion
	}
}
