using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace HotelReservationSystemDAL
{
    public class Ferry : DBInteractionBase
    {

        #region Class Member Declarations
        private SqlDateTime _createdDate, _lastModifiedDate;
        private SqlInt32 _createdUser, _lastModifiedUser, _ferryID, _numAdults, _numKids;
        private SqlMoney _cost_for_kids, _cost_for_adults, _total_cost_for_kids, _total_cost_for_adults, _total_cost;
        private SqlString _ferryName_en, _ferryName_ar;
        #endregion



        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Ferry_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@FerryName_EN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _ferryName_en));
                cmdToExecute.Parameters.Add(new SqlParameter("@FerryName_AR", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _ferryName_ar));
                cmdToExecute.Parameters.Add(new SqlParameter("@Cost_For_Adults", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _cost_for_adults));
                cmdToExecute.Parameters.Add(new SqlParameter("@Cost_For_Kids", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _cost_for_kids));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ferry_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _ferryID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorDesc", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _errorDesc));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _ferryID = (SqlInt32)cmdToExecute.Parameters["@Ferry_ID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                _errorDesc = (SqlString)cmdToExecute.Parameters["@ErrorDesc"].Value;
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Ferry_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Ferry::Insert::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[pr_Ferry_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@FerryName_EN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _ferryName_en));
                cmdToExecute.Parameters.Add(new SqlParameter("@FerryName_AR", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _ferryName_ar));
                cmdToExecute.Parameters.Add(new SqlParameter("@Cost_For_Adults", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _cost_for_adults));
                cmdToExecute.Parameters.Add(new SqlParameter("@Cost_For_Kids", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _cost_for_kids));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ferry_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ferryID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorDesc", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _errorDesc));
               
                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                _errorDesc = (SqlString)cmdToExecute.Parameters["@ErrorDesc"].Value;
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                     throw new Exception("Stored Procedure 'pr_Ferry_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("Ferry::Update::Error occured.", ex);
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
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Ferry_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Ferry_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ferryID));
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
                    throw new Exception("Stored Procedure 'pr_Ferry_Delete' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Ferry::Delete::Error occured.", ex);
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
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Ferry_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Ferry");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Ferry_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ferryID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'pr_Amenities_SelectOneWAmenitiesIDLogic' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _ferryID = (Int32)toReturn.Rows[0]["Ferry_ID"];
                    _ferryName_en = toReturn.Rows[0]["FerryName_EN"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["FerryName_EN"];
                    _ferryName_ar = toReturn.Rows[0]["FerryName_AR"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["FerryName_AR"];
                    _cost_for_kids = toReturn.Rows[0]["Cost_For_Kids"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Cost_For_Kids"];
                    _cost_for_adults = toReturn.Rows[0]["Cost_For_Adults"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Cost_For_Adults"];
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
                throw new Exception("Ferry::SelectOneFerryIDLogic::Error occured.", ex);
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
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_Ferry_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Ferry");
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

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_Ferry_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Ferry::SelectAll::Error occured.", ex);
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
        public SqlInt32 Ferry_ID
        {
            get
            {
                return _ferryID;
            }
            set
            {
                SqlInt32 ferryIDTmp = (SqlInt32)value;
                if (ferryIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Ferry_ID", "Ferry_ID can't be NULL");
                }
                _ferryID = value;
            }
        }


        public SqlString FerryName_EN
        {
            get
            {
                return _ferryName_en;
            }
            set
            {
                SqlString _ferryName_enTmp = (SqlString)value;
                if (_ferryName_enTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("FerryName_EN", "FerryName_EN can't be NULL");
                }
                _ferryName_en = value;
            }
        }


        public SqlString FerryName_AR
        {
            get
            {
                return _ferryName_ar;
            }
            set
            {
                SqlString _ferryName_arTmp = (SqlString)value;
                if (_ferryName_arTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("FerryName_AR", "FerryName_AR can't be NULL");
                }
                _ferryName_ar = value;
            }
        }


        public SqlMoney Cost_For_Adults
        {
            get
            {
                return _cost_for_adults;
            }
            set
            {
                SqlMoney _cost_for_adultsTmp = (SqlMoney)value;
                if (_cost_for_adultsTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Cost_For_Adults", "Cost_For_Adults can't be NULL");
                }
                _cost_for_adults = value;
            }
        }


        public SqlMoney Cost_For_Kids
        {
            get
            {
                return _cost_for_kids;
            }
            set
            {
                SqlMoney _cost_for_kidsTmp = (SqlMoney)value;
                if (_cost_for_kidsTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Cost_For_Kids", "Cost_For_Kids can't be NULL");
                }
                _cost_for_kids = value;
            }
        }


        public SqlMoney Total_Cost_For_Adults
        {
            get
            {
                _total_cost_for_adults = (_cost_for_adults * _numAdults);
                return _total_cost_for_adults ;
            }
            //set
            //{
            //    SqlMoney _total_cost_for_adultsTmp = (SqlMoney)value;
            //    if (_total_cost_for_adultsTmp.IsNull)
            //    {
            //        throw new ArgumentOutOfRangeException("Total_Cost_For_Adults", "Total_Cost_For_Adults can't be NULL");
            //    }
            //    _total_cost_for_adults = value;
            //}
        }

        public SqlMoney Total_Cost_For_Kids
        {
            get
            {
                _total_cost_for_kids = (_cost_for_kids * _numKids);
                return _total_cost_for_kids;
            }
            //set
            //{
            //    SqlMoney _total_cost_for_kidsTmp = (SqlMoney)value;
            //    if (_total_cost_for_kidsTmp.IsNull)
            //    {
            //        throw new ArgumentOutOfRangeException("Total_Cost_For_Kids", "Total_Cost_For_Kids can't be NULL");
            //    }
            //    _total_cost_for_kids = value;
            //}
        }

        public SqlMoney Total_Cost
        {
            get
            {
                _total_cost = (_total_cost_for_kids + _total_cost_for_adults);
                return _total_cost;
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
                if (createdUserTmp.IsNull)
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
                if (lastModifiedUserTmp.IsNull)
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
                if (lastModifiedDateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("LastModifiedDate", "LastModifiedDate can't be NULL");
                }
                _lastModifiedDate = value;
            }
        }


        public SqlInt32 NumberOfAdults
        {
            get
            {
                return _numAdults;
            }
            set
            {
                _numAdults = value;
            }
        }

        public SqlInt32 NumberOfKids
        {
            get
            {
                return _numKids;
            }
            set
            {
                _numKids = value;
            }
        }
        #endregion
    }
}
