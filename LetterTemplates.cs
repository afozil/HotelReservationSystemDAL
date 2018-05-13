using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
	public class LetterTemplates : DBInteractionBase
	{
		#region Class Member Declarations
			private DateTime		_createdDate, _lastModifiedDate;
			private Int32		_lastModifiedUser, _createdUser, _letterTemplate_ID;
			private String		_description, _letterTemplateName_AR;
			private SqlBinary		_letterTemplate;
			private String		_letterTemplateName_EN;
		#endregion


		public LetterTemplates()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_LetterTemplates_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplateName_EN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _letterTemplateName_EN));
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplateName_AR", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _letterTemplateName_AR));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplate", SqlDbType.VarBinary, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _letterTemplate));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplate_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _letterTemplate_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_letterTemplate_ID = (Int32)cmdToExecute.Parameters["@LetterTemplate_ID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_LetterTemplates_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("LetterTemplates::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_LetterTemplates_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplate_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _letterTemplate_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplateName_EN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _letterTemplateName_EN));
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplateName_AR", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _letterTemplateName_AR));
				cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplate", SqlDbType.VarBinary, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _letterTemplate));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
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
					throw new Exception("Stored Procedure 'pr_LetterTemplates_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("LetterTemplates::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_LetterTemplates_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplate_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _letterTemplate_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_LetterTemplates_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("LetterTemplates::Delete::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_LetterTemplates_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("LetterTemplates");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@LetterTemplate_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _letterTemplate_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_LetterTemplates_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_letterTemplate_ID = (Int32)toReturn.Rows[0]["LetterTemplate_ID"];
					_letterTemplateName_EN = (string)toReturn.Rows[0]["LetterTemplateName_EN"];
					_letterTemplateName_AR = toReturn.Rows[0]["LetterTemplateName_AR"] == System.DBNull.Value ? string.Empty : (string)toReturn.Rows[0]["LetterTemplateName_AR"];
					_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? string.Empty : (string)toReturn.Rows[0]["Description"];
					_letterTemplate = toReturn.Rows[0]["LetterTemplate"] == System.DBNull.Value ? SqlBinary.Null : (byte[])toReturn.Rows[0]["LetterTemplate"];
					_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
					_createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
					_lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
					_lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("LetterTemplates::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_LetterTemplates_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("LetterTemplates");
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
					throw new Exception("Stored Procedure 'pr_LetterTemplates_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("LetterTemplates::SelectAll::Error occured.", ex);
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
		public Int32 LetterTemplate_ID
		{
			get
			{
				return _letterTemplate_ID;
			}
			set
			{
				Int32 letterTemplate_IDTmp = (Int32)value;
                //if(letterTemplate_IDTmp)
                //{
                //    throw new ArgumentOutOfRangeException("LetterTemplate_ID", "LetterTemplate_ID can't be NULL");
                //}
				_letterTemplate_ID = value;
			}
		}


		public String LetterTemplateName_EN
		{
			get
			{
				return _letterTemplateName_EN;
			}
			set
			{
				String letterTemplateName_ENTmp = (String)value;
                //if(letterTemplateName_ENTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("LetterTemplateName_EN", "LetterTemplateName_EN can't be NULL");
                //}
				_letterTemplateName_EN = value;
			}
		}


		public String LetterTemplateName_AR
		{
			get
			{
				return _letterTemplateName_AR;
			}
			set
			{
				String letterTemplateName_ARTmp = (String)value;
                //if(letterTemplateName_ARTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("LetterTemplateName_AR", "LetterTemplateName_AR can't be NULL");
                //}
				_letterTemplateName_AR = value;
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


		public SqlBinary LetterTemplate
		{
			get
			{
				return _letterTemplate;
			}
			set
			{
				SqlBinary letterTemplateTmp = (SqlBinary)value;
                //if(letterTemplateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("LetterTemplate", "LetterTemplate can't be NULL");
                //}
				_letterTemplate = value;
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
		#endregion
	}
}
