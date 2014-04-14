using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt.Model.DAL
{
    public class TitelFormatDAL
    {
        #region Connection
        private static string _connectionString;

        static TitelFormatDAL()
        {
            //Denna kod hämtar ut anslutningssträngen från web.config
            _connectionString = WebConfigurationManager.ConnectionStrings["IndividuelltArbeteConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        #endregion

        #region Get format by id
        public List<TitelFormat> GetTitelFormatByTitelId(int titelID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("app Schema.usp_GetTitelFormatByID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TitelID", titelID);

                    List<TitelFormat> formats = new List<TitelFormat>(10);

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var formatIndex = reader.GetOrdinal("FormatID");
                        var titelformatIndex = reader.GetOrdinal("TitelFormatID");

                        while (reader.Read())
                        {
                            formats.Add(new TitelFormat
                            {
                                FormatID = reader.GetInt32(formatIndex),
                                TitelFormatID = reader.GetInt32(titelformatIndex)
                            });

                        }

                    }
                    formats.TrimExcess();
                    return formats;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i data access layer.");
                }
            }

        }
        #endregion

        #region Insert
        public void InsertTitelformat(Title titel, int i)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app Schema.usp_AddTitelFormat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@TitelID", SqlDbType.Int).Value = titel.TitelID;
                    cmd.Parameters.Add("@FormatID", SqlDbType.Int).Value = i;

                    cmd.Parameters.Add("@TitelFormatID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        #endregion

        #region Update


        public void UpdateTitelformat(Title titel, int i)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app Schema.usp_upFormat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TitelID", titel.TitelID);
                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.

                    //cmd.Parameters.Add("@TitelID", SqlDbType.Int).Value = movie.TitelID;
                    cmd.Parameters.Add("@FormatID", SqlDbType.Int).Value = i;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public IEnumerable<Formats> GetTitelFormatIDByTitleID(int titleId)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var titelList = new List<Formats>(100);
                    var cmd = new SqlCommand("app Schema.usp_GetFormatByID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("TitleID", titleId);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {


                        var formatIndex = reader.GetOrdinal("FormatID");


                        while (reader.Read())
                        {
                            titelList.Add(new Formats
                            {
                                FormatID = reader.GetInt32(formatIndex),
                            });


                        }
                    }
                    titelList.TrimExcess();

                    return titelList;
                }


                catch
                {
                    throw new ApplicationException();
                }

            }
        }

        public void DeleteFormat(int titleID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app Schema.usp_delTitelFormat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Value = titleID;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        #endregion

 
    }
}