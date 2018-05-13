using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace HotelReservationSystemDAL
{
    public class KNET_Payments : DBInteractionBase
    {
        private SqlInt32 _paymentStatus, _payment_ID, _reservation_ID, _guest_ID;
        private String _remarks, _knet_Payment_ID, _auth, _ref, _result, _transVal, _track_ID, _paymentStatusEn;
        private SqlMoney _paymentAmount;
        private SqlDateTime _createdDate;

        public SqlInt32 Payment_ID
        {
            get
            {
                return _payment_ID;
            }
            set
            {
                SqlInt32 payment_IDTmp = (SqlInt32)value;
                if (payment_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Payment_ID", "Payment_ID can't be NULL");
                }
                _payment_ID = value;
            }
        }
        public SqlInt32 Reservation_ID
        {
            get
            {
                return _reservation_ID;
            }
            set
            {
                SqlInt32 reservation_IDTmp = (SqlInt32)value;
                if (reservation_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Reservation_ID", "Reservation_ID can't be NULL");
                }
                _reservation_ID = value;
            }
        }
        public SqlInt32 Guest_ID
        {
            get
            {
                return _guest_ID;
            }
            set
            {
                SqlInt32 guest_IDTmp = (SqlInt32)value;
                if (guest_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Guest_ID", "Guest_ID can't be NULL");
                }
                _guest_ID = value;
            }
        }
        public String Track_ID
        {
            get
            {
                return _track_ID;
            }
            set
            {
                
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Track_ID", "Track_ID can't be NULL");
                }
                _track_ID = value;
            }
        }
        public String TransVal
        {
            get
            {
                return _transVal;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("TransVal", "TransVal can't be NULL");
                }
                _transVal = value;
            }
        }
        public String KNET_Payment_ID
        {
            get
            {
                return _knet_Payment_ID;
            }
            set
            {
                String knet_Payment_IDTmp = (String)value;
                if (knet_Payment_IDTmp == String.Empty)
                {
                    throw new ArgumentOutOfRangeException("KNET_Payment_ID", "KNET_Payment_ID can't be NULL");
                }
                _knet_Payment_ID = value;
            }
        }
        public SqlInt32 PaymentSatus
        {
            get
            {
                return _paymentStatus;
            }
            set
            {
                SqlInt32 paymentStatusTmp = (SqlInt32)value;
                if (paymentStatusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PaymentSatus", "PaymentSatus can't be NULL");
                }
                _paymentStatus = value;
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
                if (createdDateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("CreatedDate", "CreatedDate can't be NULL");
                }
                _createdDate = value;
            }
        }
        public SqlMoney PaymentAmount
        {
            get
            {
                return _paymentAmount;
            }
            set
            {
                SqlMoney paymentAmountTmp = (SqlMoney)value;
                if (paymentAmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PaymentAmount", "PaymentAmount can't be NULL");
                }
                _paymentAmount = value;
            }
        }
        public String Remarks
        {
            get
            {
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }
        public String Ref
        {
            get
            {
                return _ref;
            }
            set
            {
                _ref = value;
            }
        }
        public String Auth
        {
            get
            {
                return _auth;
            }
            set
            {
                _auth = value;
            }
        }
        public String Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }
        public String PaymentStatus_EN
        {
            get
            {
                return _paymentStatusEn;
            }
            set
            {
                _paymentStatusEn = value;
            }
        }

        public KNET_Payments()
        {
            // Nothing for now.
        }
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_KNET_Payments_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iReservation_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _reservation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPayment_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _payment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iKNET_Payment_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _knet_Payment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@daCreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTransVal", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _transVal));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPaymentStatus", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _paymentStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@iGuest_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _guest_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTrack_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _track_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@curPaymentAmount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _paymentAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRemarks", SqlDbType.NVarChar, 75, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _remarks));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                    throw new Exception("Stored Procedure 'pr_KNET_Payments_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("KNET_Payments_Insert::Insert::Error occured.", ex);
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
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_KNET_Payments_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iReservation_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _reservation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPayment_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _payment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iKNET_Payment_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _knet_Payment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPaymentStatus", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _paymentStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRemarks", SqlDbType.NVarChar, 75, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _remarks));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTransVal", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _transVal));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTrack_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _track_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAuthorise", SqlDbType.VarChar, 6, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _auth));
                cmdToExecute.Parameters.Add(new SqlParameter("@sResult", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _result));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRef", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _ref));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                    throw new Exception("Stored Procedure 'pr_KNET_Payments_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("KNET_Payments_Update::Update::Error occured.", ex);
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
        public override bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_KNET_Payments_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iKNET_Payment_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _knet_Payment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                    throw new Exception("Stored Procedure 'pr_KNET_Payments_Delete' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("KNET_Payments_Delete::Delete::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[pr_KNET_Payments_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("KNET_Reservation_Payments");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iKNET_Payment_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _knet_Payment_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_KNET_Payments_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _payment_ID = (Int32)toReturn.Rows[0]["Payment_ID"];
                    _reservation_ID = (Int32)toReturn.Rows[0]["Reservation_ID"];
                    _knet_Payment_ID = toReturn.Rows[0]["KNET_Payment_ID"].ToString();
                    _createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
                    _transVal = toReturn.Rows[0]["TransVal"].ToString();
                    _paymentStatus = (Int32)toReturn.Rows[0]["PaymentStatus"] ;
                    _guest_ID = (Int32)toReturn.Rows[0]["Guest_ID"];
                    _track_ID = toReturn.Rows[0]["Track_ID"].ToString();
                    _paymentAmount = (Decimal)toReturn.Rows[0]["PaymentAmount"];
                    _auth= toReturn.Rows[0]["Authorise"].ToString();
                    _result = toReturn.Rows[0]["Result"].ToString();
                    _ref = toReturn.Rows[0]["Ref"].ToString();
                    _remarks = toReturn.Rows[0]["Remarks"].ToString();
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("KNET_Payments_SelectOne::SelectOne::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_KNET_Payments_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("KNET_Reservation_Payments");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_KNET_Payments_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("KNET_Payments_SelectAll::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable SelectByReservation()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_KNET_Payments_SelectByReservation]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("KNET_Reservation_Payments");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iReservation_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _reservation_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'pr_KNET_Payments_SelectByReservation' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _payment_ID = (Int32)toReturn.Rows[0]["Payment_ID"];
                    _reservation_ID = (Int32)toReturn.Rows[0]["Reservation_ID"];
                    _knet_Payment_ID = toReturn.Rows[0]["KNET_Payment_ID"].ToString();
                    _createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
                    _transVal = toReturn.Rows[0]["TransVal"].ToString();
                    _paymentStatus = (Int32)toReturn.Rows[0]["PaymentStatus"];
                    _guest_ID = (Int32)toReturn.Rows[0]["Guest_ID"];
                    _track_ID = toReturn.Rows[0]["Track_ID"].ToString();
                    _paymentAmount = (Decimal)toReturn.Rows[0]["PaymentAmount"];
                    _auth = toReturn.Rows[0]["Authorise"].ToString();
                    _result = toReturn.Rows[0]["Result"].ToString();
                    _ref = toReturn.Rows[0]["Ref"].ToString();
                    _remarks = toReturn.Rows[0]["Remarks"].ToString();
                    _paymentStatusEn = toReturn.Rows[0]["PaymentStatus_EN"].ToString();
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_KNET_Payments_SelectByReservation::SelectOne::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }




    }
}
