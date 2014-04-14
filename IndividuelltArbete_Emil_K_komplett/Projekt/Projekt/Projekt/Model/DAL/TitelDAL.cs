using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt.Model.DAL
{
    public class TitelDAL
    {
        #region Connection
        private static string _connectionString;

        static TitelDAL()
        {
            //Denna kod hämtar ut anslutningssträngen från web.config
            _connectionString = WebConfigurationManager.ConnectionStrings["IndividuelltArbeteConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        #endregion


        #region Get all titels
        public static IEnumerable<Title> GetTitels()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Titel-objekt.
                    var titels = new List<Title>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app Schema.usp_GetAllTitels", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en SELECT-sats som kan returnera flera poster varför
                    // ett SqlDataReader-objekt måste ta hand om alla poster. Metoden ExecuteReader skapar ett
                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har. Det är mycket effektivare att göra detta
                        // en gång för alla innan while-loopen. Genom att använda GetOrdinal behöver du inte känna till
                        // i vilken ordning de olika kolumnerna kommer, bara vad de heter.
                        var titelIDIndex = reader.GetOrdinal("TitelID");
                        var tekniskInfoIDIndex = reader.GetOrdinal("TekniskInfo");
                        var beskrivningIndex = reader.GetOrdinal("Beskrivning");
                        var titelIndex = reader.GetOrdinal("Titel");
                        var produktionsarIndex = reader.GetOrdinal("Produktionsår");
                        var produktionsbolagIndex = reader.GetOrdinal("Produktionsbolag");
                        var genreIndex = reader.GetOrdinal("Genre");

                        // Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler 
                        // poster returnerar Read false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
                            titels.Add(new Title
                            {
                                TitelID = reader.GetInt32(titelIDIndex),
                                TekniskInfo = reader.GetString(tekniskInfoIDIndex),
                                Beskrivning = reader.GetString(beskrivningIndex),
                                Titel = reader.GetString(titelIndex),
                                Produktionsar = reader.GetInt16(produktionsarIndex),
                                Produktionsbolag = reader.GetString(produktionsbolagIndex),
                                Genre = reader.GetString(genreIndex)
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet, d.v.s. avallokerar minne
                    // som inte används.
                    titels.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser till Titel-objekt.
                    return titels;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting titels from the database.");
                }
            }
        }
        #endregion


        #region Get a titel by id
        public Title GetTitelById(int titelID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("app Schema.usp_GetTitelByID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TitelID", titelID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var titelIndex = reader.GetOrdinal("Titel");
                            var TekniskInfoIndex = reader.GetOrdinal("TekniskInfo");
                            var produktionsarIndex = reader.GetOrdinal("Produktionsår");
                            var ProduktionsbolagIndex = reader.GetOrdinal("Produktionsbolag");
                            var beskrivningIndex = reader.GetOrdinal("Beskrivning");
                            var GenreIndex = reader.GetOrdinal("Genre");

                            return new Title
                            {
                                Titel = reader.GetString(titelIndex),
                                TekniskInfo = reader.GetString(TekniskInfoIndex),
                                Produktionsar = reader.GetInt16(produktionsarIndex),
                                Produktionsbolag = reader.GetString(ProduktionsbolagIndex),
                                Beskrivning = reader.GetString(beskrivningIndex),
                                Genre = reader.GetString(GenreIndex)


                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i data access layer.");
                }
            }

        }
        #endregion

        #region Insert a titel
        public void InsertTitel(Title titel)
        {

            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app Schema.usp_AddTitel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    //cmd.Parameters.Add("@TitelID", SqlDbType.Int).Value = movie.TitelID;
                    cmd.Parameters.Add("@Titel", SqlDbType.VarChar, 50).Value = titel.Titel;
                    cmd.Parameters.Add("@TekniskInfo", SqlDbType.VarChar, 1000).Value = titel.TekniskInfo;
                    cmd.Parameters.Add("@Produktionsar", SqlDbType.Int).Value = titel.Produktionsar;
                    cmd.Parameters.Add("@Produktionsbolag", SqlDbType.VarChar, 40).Value = titel.Produktionsbolag;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 1000).Value = titel.Beskrivning;
                    cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 20).Value = titel.Genre;



                    // Den här parametern är lite speciell. Den skickar inte något data till den lagrade proceduren,
                    // utan hämtar data från den. (Fungerar ungerfär som ref- och out-prameterar i C#.) Värdet 
                    // parametern kommer att ha EFTER att den lagrade proceduren exekverats är primärnycklens värde
                    // den nya posten blivit tilldelad av databasen.
                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    titel.TitelID = (int)cmd.Parameters["@TitelID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        #endregion

        #region Update a titel
        public void UpdateTitel(Title titel)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app Schema.usp_upTitel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Titel", SqlDbType.VarChar, 50).Value = titel.Titel;
                    cmd.Parameters.Add("@TekniskInfo", SqlDbType.VarChar, 1000).Value = titel.TekniskInfo;
                    cmd.Parameters.Add("@Produktionsar", SqlDbType.Int).Value = titel.Produktionsar;
                    cmd.Parameters.Add("@Produktionsbolag", SqlDbType.VarChar, 40).Value = titel.Produktionsbolag;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 1000).Value = titel.Beskrivning;
                    cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 20).Value = titel.Genre;

                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Value = titel.TitelID;

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

        #region Delete a titel
        public void DeleteTitel(int titelID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app Schema.usp_delTitel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Value = titelID;

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