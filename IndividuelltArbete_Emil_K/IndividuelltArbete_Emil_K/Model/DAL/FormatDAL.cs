using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IndividuelltArbete_Emil_K.Model.DAL
{
    public class FormatDAL
    {
          #region Fält

        /// <summary>
        /// Sträng med information som används för att ansluta till "SQL Server"-databasen.
        /// (Ett statiskt fält tillhör klassen och delas av alla instanser  av klassen).
        /// </summary>
        private static string _connectionString;

        #endregion

        #region Kontruktorer

        /// <summary>
        /// Initierar statiskt data. (Konstruktorn anropas automatiskt innan första instansen skapas
        /// eller innan någon statisk medlem används.)
        /// </summary>
        static FormatDAL()
        {
            // Hämtar anslutningssträngen från web.config.
            _connectionString = WebConfigurationManager.ConnectionStrings["IndividuelltArbeteConnectionString"].ConnectionString;
        }

        #endregion

        #region Privata hjälpmetoder

        /// <summary>
        /// Skapar och initierar ett nytt asnlutningsobjekt.
        /// </summary>
        /// <returns>Referens till ett nytt SqlConnection-objekt</returns>
        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region CRUD-metoder

        /// <summary>
        /// Hämtar alla Format i databasen.
        /// </summary>
        /// <returns>Samling med referenser till Format-objekt.</returns>
        public static IEnumerable<Format> GetFormats()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Format-objekt.
                    var format = new List<Format>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspGetCustomers", conn);
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
                        var formatIDIndex = reader.GetOrdinal("FormatID");
                        var formatIndex = reader.GetOrdinal("Format");
                        

                        // Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler 
                        // poster returnerar Read false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
                            format.Add(new Format
                            {
                                FormatID = reader.GetInt32(formatIDIndex),
                                Format = reader.GetString(formatIndex)
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet, d.v.s. avallokerar minne
                    // som inte används.
                    format.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser med Customer-objekt.
                    return format;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting format from the database.");
                }
            }
        }

        /// <summary>
        /// Hämtar ett formats uppgifter.
        /// </summary>
        /// <param name="formatid">Ett formats nummer.</param>
        /// <returns>Ett Format-objekt med uppgifter.</returns>
        public static Format GetFormatById(int formatID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app.uspGetCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det MINDRE effektiva 
                    // sätttet att göra det på - enkelt, men ASP.NET behöver "jobba" rätt mycket.
                    cmd.Parameters.AddWithValue("@FormatID", formatID);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en SELECT-sats som kan returner en post varför
                    // ett SqlDataReader-objekt måste ta hand om posten. Metoden ExecuteReader skapar ett
                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
                        // Read false.
                        if (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har. Genom att använda 
                            // GetOrdinal behöver du inte känna till i vilken ordning de olika 
                            // kolumnerna kommer, bara vad de heter.
                            int formatIDIndex = reader.GetOrdinal("FormatID");
                            int formatIndex = reader.GetOrdinal("Format");
                            
                            // Returnerar referensen till de skapade Format-objektet.
                            return new Format
                            {
                                FormatID = reader.GetInt32(formatIDIndex),
                                Format = reader.GetString(formatIndex)
                            };
                        }
                    }

                    // Istället för att returnera null kan du välja att kasta ett undatag om du 
                    // inte får "träff" på ett format.
                    return null;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Skapar en ny post i tabellen Format.
        /// </summary>
        /// <param name="format">Format uppgifter som ska läggas till.</param>
        public static void InsertFormat(Format format)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app.uspInsertCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@Format", SqlDbType.VarChar, 20).Value = format.Format;
                   

                    // Den här parametern är lite speciell. Den skickar inte något data till den lagrade proceduren,
                    // utan hämtar data från den. (Fungerar ungerfär som ref- och out-prameterar i C#.) Värdet 
                    // parametern kommer att ha EFTER att den lagrade proceduren exekverats är primärnycklens värde
                    // den nya posten blivit tilldelad av databasen.
                    cmd.Parameters.Add("@FormatID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Format-objektet värdet.
                    format.FormatID = (int)cmd.Parameters["@FormatID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar en kunds kunduppgifter i tabellen Format.
        /// </summary>
        /// <param name="format">Format uppgifter som ska uppdateras.</param>
        public static void UpdateFormat(Format format)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspUpdateCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@FormatID", SqlDbType.Int, 4).Value = format.FormatID;
                    cmd.Parameters.Add("@Format", SqlDbType.VarChar, 20).Value = format.Format;
                    

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en UPDATE-sats och returnerar inga poster varför metoden 
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

        /// <summary>
        /// Tar bort en formats uppgifter.
        
        public static void DeleteFormats(int formatID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspDeleteCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@FormatID", SqlDbType.Int, 4).Value = formatID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en DELETE-sats och returnerar inga poster varför metoden 
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
    }
}