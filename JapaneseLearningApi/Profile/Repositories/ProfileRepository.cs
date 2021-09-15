using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Profile.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Profile_Get = "p_Profile_Get";
        private static string p_Password_Set = "p_Password_Set";
        private static string p_AccentTheme_Get = "p_AccentTheme_Get";
        private static string p_AccentTheme_Set = "p_AccentTheme_Set";

        public ProfileRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ReturnStatus Login(GetLogin req)
        {
            var result = null as UserProfile;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Profile_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@Username", req.Username);
                cmd.Parameters.AddWithValue("@Password", req.Password);

                connection.Open();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                    cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }

        public ApiResponse<UserProfile> GetProfile()
        {
            var result = null as UserProfile;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Profile_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new UserProfile
                        {
                            UserId = dr["UserID"].ToSafeInt32(),
                            Username = dr["Username"].ToSafeString(),
                            FirstName = dr["FirstName"].ToSafeString(),
                            LastName = dr["LastName"].ToSafeString(),
                            UserTypeId = dr["UserTypeID"].ToSafeInt32(),
                            UserType = dr["UserType"].ToSafeString(),
                            DateJoined = dr["DateJoined"].ToSafeDateTime(),
                            Gender = dr["Gender"].ToSafeInt32(),
                            SessionId = dr["SessionID"].ToSafeString(),
                            ThemeId = dr["ThemeID"].ToSafeInt32(),
                            AccentId = dr["AccentID"].ToSafeInt32(),
                            ProfilePicture = dr["ProfilePicture"].ToSafeDateTime(),
                            BannerImage = dr["BannerImage"].ToSafeDateTime(),
                            Wallpaper = dr["Wallpaper"].ToSafeDateTime(),
                            HiraganaLevel = dr["HiraganaLevel"].ToSafeInt32(),
                            KatakanaLevel = dr["KatakanaLevel"].ToSafeInt32(),
                            KanjiLevel = dr["KanjiLevel"].ToSafeInt32(),
                            VocabLevel = dr["VocabLevel"].ToSafeInt32()
                        };
                    }
                }
                return new ApiResponse<UserProfile>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }
        
        public ReturnStatus ChangePassword(SetPassword req)
        {
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_Password_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CurrentPassword", req.CurrentPassword);
                cmd.Parameters.AddWithValue("@NewPassword", req.NewPassword);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
        
        public ApiResponse<AccentTheme> GetAccentTheme()
        {
            var result = null as AccentTheme;
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_AccentTheme_Get, connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                connection.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result = new AccentTheme
                        {
                            ThemeId = dr["ThemeID"].ToSafeInt32(),
                            AccentId = dr["AccentID"].ToSafeInt32(),
                        };
                    }
                }
                return new ApiResponse<AccentTheme>
                {
                    Content = result,
                    Status = new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(),
                            cmd.Parameters["@RetMsg"].Value.ToSafeString())
                };
            }
        }
        
        public ReturnStatus SetAccentTheme(SetAccentTheme req)
        {
            using (var connection = new SqlConnection(_connectionString.JapaneseLearning))
            {
                var cmd = new SqlCommand(p_AccentTheme_Set, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", _requestInfo.UserId);

                cmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ThemeID", req.ThemeId);
                cmd.Parameters.AddWithValue("@AccentID", req.AccentId);

                connection.Open();

                cmd.ExecuteNonQuery();

                return new ReturnStatus(cmd.Parameters["@RetVal"].Value.ToSafeInt32(), cmd.Parameters["@RetMsg"].Value.ToSafeString());
            }
        }
    }
}
