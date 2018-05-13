using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using HotelReservationSystemDAL.DAL;

namespace HotelReservationSystemDAL
{
	public class RoomType_Image : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_createdDate, _lastModifiedDate;
			private SqlInt32		_createdUser, _lastModifiedUser, _roomType_ID, _roomType_OnlineID, _image_ID, _image_size, _image_length, _image_height,_image_width,_thumbnail_height,_thumbnail_width;
			private SqlString		_imageName, _imageType, _imagePath, _thumbnailPath;
			private SqlBinary		_image, _thumbnail;



            
			
		#endregion


		public RoomType_Image()
		{
			// Nothing for now.
		}
		
        public RoomType_Image(SqlInt32 roomType_ID, SqlInt32 roomType_OnlineID, SqlInt32 createdUser, 
            SqlInt32 lastModifiedUser, SqlInt32 image_ID, SqlInt32 image_size, SqlInt32 image_height, SqlInt32 image_width,
            SqlInt32 thumbnail_height, SqlInt32 thumbnail_width,
            SqlInt32 image_length,
                        SqlString imageName, SqlString imageType, SqlString filePath, SqlString thumbnailPath,
                        SqlDateTime	createdDate, SqlDateTime lastModifiedDate,
						SqlBinary image, SqlBinary thumbnail
            )
        {
            _roomType_ID = roomType_ID;
            _roomType_OnlineID = roomType_OnlineID;
            _image_ID = image_ID;
			_image_size = image_size;
			_image_length = image_length;
			_imageName = imageName;
			_imageType = imageType;
			_imagePath = filePath;
            _thumbnailPath = thumbnailPath;
			_createdUser = createdUser;
            _lastModifiedUser = lastModifiedUser;
            _createdDate = createdDate;
            _lastModifiedDate = lastModifiedDate;
			_image = image;
            _image_height = image_height;
            _image_width = image_width;
            _thumbnail = thumbnail;
            _thumbnail_height = thumbnail_height;
            _thumbnail_width = thumbnail_width;
        }

		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_RoomType_Image_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_OnlineID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_OnlineID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_size));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageLength", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_length));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _imageName));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _imageType));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _imagePath));
                cmdToExecute.Parameters.Add(new SqlParameter("@ThumbnailPath", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _thumbnailPath));
                cmdToExecute.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _image));
                cmdToExecute.Parameters.Add(new SqlParameter("@Thumbnail", SqlDbType.VarBinary, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _thumbnail));
                cmdToExecute.Parameters.Add(new SqlParameter("@ThumbnailHeight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _thumbnail_height));
                cmdToExecute.Parameters.Add(new SqlParameter("@ThumbnailWidth", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _thumbnail_width));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageHeight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_height));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageWidth", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_width));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
				cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Image_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _image_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_image_ID = (SqlInt32)cmdToExecute.Parameters["@Image_ID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_RoomType_Image_Insert' reported the ErrorCode: " + _errorCode);
                    return false;
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_Image::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_Image_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_OnlineID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_OnlineID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_size));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageLength", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_length));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _imageName));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _imageType));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _imagePath));
                cmdToExecute.Parameters.Add(new SqlParameter("@ThumbnailPath", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _thumbnailPath));
                cmdToExecute.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _image));
                cmdToExecute.Parameters.Add(new SqlParameter("@Thumbnail", SqlDbType.VarBinary, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _thumbnail));
                cmdToExecute.Parameters.Add(new SqlParameter("@ThumbnailHeight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _thumbnail_height));
                cmdToExecute.Parameters.Add(new SqlParameter("@ThumbnailWidth", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _thumbnail_width));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageHeight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_height));
                cmdToExecute.Parameters.Add(new SqlParameter("@ImageWidth", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_width));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedUser", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _lastModifiedUser));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lastModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Image_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _image_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomType_Image_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_Image::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_Image_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Image_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					//throw new Exception("Stored Procedure 'pr_RoomType_Image_Delete' reported the ErrorCode: " + _errorCode);
                    return false;
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_Image::Delete::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_Image_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RoomType_OnlineDetails");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@Image_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _image_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomType_Image_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_image_ID = (Int32)toReturn.Rows[0]["RoomType_ImageID"];
					_roomType_ID = (Int32)toReturn.Rows[0]["RoomType_ID"];
                    _roomType_OnlineID = (Int32)toReturn.Rows[0]["RoomType_Online_ID"];
                    _imageName = toReturn.Rows[0]["RoomType_ImageName"].ToString();
                    //_image_size = (SqlInt32)toReturn.Rows[0]["Image_Size"];
                    _imageType = toReturn.Rows[0]["Image_ContentType"].ToString();
                    _image_height = (Int32)toReturn.Rows[0]["Image_Height"];
                    _image_width = (Int32)toReturn.Rows[0]["Image_Width"];
                    _thumbnail_height = (Int32)toReturn.Rows[0]["Thumbnail_Height"];
                    _thumbnail_width = (Int32)toReturn.Rows[0]["Thumbnail_Width"];
                    _imagePath = toReturn.Rows[0]["RoomType_ImagePath"].ToString();
                    _thumbnailPath = toReturn.Rows[0]["RoomType_ThumbnailPath"].ToString();
					_createdUser = (Int32)toReturn.Rows[0]["CreatedUser"];
                    _createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
                    _lastModifiedUser = (Int32)toReturn.Rows[0]["LastModifiedUser"];
                    _lastModifiedDate = (DateTime)toReturn.Rows[0]["LastModifiedDate"];
					_image = (byte[])toReturn.Rows[0]["RoomType_Image"];
					_thumbnail = (byte[])toReturn.Rows[0]["RoomType_Thumbnail"];
                }
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_Image::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_RoomType_Image_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RoomType_Images");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RoomType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _roomType_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_RoomType_Image_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RoomType_Image::SelectAll::Error occured.", ex);
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
		
			
			
		public SqlInt32 Image_ID
		{
			get
			{
				return _image_ID;
			}
			set
			{
				Int32 _image_IDTmp = (Int32)value;
				_image_ID = value;
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
				Int32 roomType_IDTmp = (Int32)value;
				_roomType_ID = value;
			}
		}
        public SqlInt32 RoomType_OnlineID
        {
            get
            {
                return _roomType_OnlineID;
            }
            set
            {
                Int32 roomType_OnlineIDTmp = (Int32)value;
                _roomType_OnlineID = value;
            }
        }


        public SqlInt32 ImageSize
		{
			get
			{
				return _image_size;
			}
			set
			{
				Int32 _image_sizeTmp = (Int32)value;
				_image_size = value;
			}
		}
		public SqlInt32 ImageLength
		{
			get
			{
				return _image_length;
			}
			set
			{
				Int32 _image_lengthTmp = (Int32)value;
				_image_length = value;
			}
		}
		public SqlString ImageName
		{
			get
			{
				return _imageName;
			}
			set
			{
				String _imageNameTmp = (String)value;
				_imageName = value;
			}
		}
		public SqlString ImageType
		{
			get
			{
				return _imageType;
			}
			set
			{
				String _imageTypeTmp = (String)value;
				_imageType = value;
			}
		}		
		public SqlString ImagePath
		{
			get
			{
				return _imagePath;
			}
			set
			{
				String _imagePathTmp = (String)value;
				_imagePath = value;
			}
		}
        public SqlString ThumbnailPath
        {
            get
            {
                return _thumbnailPath;
            }
            set
            {
                String _thumbnailPathTmp = (String)value;
                _thumbnailPath = value;
            }
        }
        public SqlInt32 ImageHeight
        {
            get
            {
                return _image_height;
            }
            set
            {
                Int32 _image_heightTmp = (Int32)value;
                _image_height = value;
            }
        }
        public SqlInt32 ImageWidth
        {
            get
            {
                return _image_width;
            }
            set
            {
                Int32 _image_widthTmp = (Int32)value;
                _image_width = value;
            }
        }
        public SqlInt32 ThumbnailHeight
        {
            get
            {
                return _thumbnail_height;
            }
            set
            {
                Int32 _thumb_heightTmp = (Int32)value;
                _thumbnail_height = value;
            }
        }
        public SqlInt32 ThumbnailWidth
        {
            get
            {
                return _thumbnail_width;
            }
            set
            {
                Int32 _thumbnail_widthTmp = (Int32)value;
                _thumbnail_width = value;
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
				Int32 createdUserTmp = (Int32)value;
                //if (createdUserTmp.IsNull)
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
				DateTime createdDateTmp = (DateTime)value;
                //if(createdDateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("CreatedDate", "CreatedDate can't be NULL");
                //}
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
				DateTime lastModifiedDateTmp = (DateTime)value;
				_lastModifiedDate = value;
			}
		}
		
		public SqlBinary Image
		{
			get
			{
				return _image;
			}
			set
			{
				byte[] _imageTmp = (byte[])value;
				_image = value;
			}
		}
		public SqlBinary Thumbnail
		{
			get
			{
				return _thumbnail;
			}
			set
			{
				byte[] _thumbnailTmp = (byte[])value;
				_thumbnail = value;
			}
		}		

		#endregion


        public static List<RoomType_Image> GetRoomTypeImages()
        {
            DataAccess dal = DataAccessHelper.GetDataAccess();
            List<RoomType_Image> roomType_images = dal.GetRoomTypeImages();
            return roomType_images;
        }
	}


   
}
