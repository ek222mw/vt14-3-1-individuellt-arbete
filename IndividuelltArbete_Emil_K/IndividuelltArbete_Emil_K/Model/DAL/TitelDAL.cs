using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IndividuelltArbete_Emil_K.Model.DAL
{
    public class TitelDAL
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
        static TitelDAL()
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
        /// Hämtar alla kunder i databasen.
        /// </summary>
        /// <returns>Samling med referenser till Customer-objekt.</returns>
        public static IEnumerable<Titel> GetTitels()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Customer-objekt.
                    var titels = new List<Titel>(100);

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
                        var titelIDIndex = reader.GetOrdinal("TitelID");
                        var tekniskInfoIDIndex = reader.GetOrdinal("TekniskInfoID");
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
                            titels.Add(new Titel
                            {
                                TitelID = reader.GetInt32(titelIDIndex),
                                TekniskInfoID = reader.GetInt32(tekniskInfoIDIndex),
                                Beskrivning = reader.GetString(beskrivningIndex),
                                Titel = reader.GetString(titelIndex),
                                Produktionsar = reader.GetDateTime(produktionsarIndex),
                                Produktionsbolag = reader.GetString(produktionsbolagIndex),
                                Genre = reader.GetString(genreIndex)
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet, d.v.s. avallokerar minne
                    // som inte används.
                    titels.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser med Customer-objekt.
                    return titels;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting titels from the database.");
                }
            }
        }

        /// <summary>
        /// Hämtar en kunds kunduppgifter.
        /// </summary>
        /// <param name="customerId">En kunds kundnummer.</param>
        /// <returns>Ett Customer-objekt med en kunds kunduppgifter.</returns>
        public static Titel GetTitelsById(int titelID)
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
                    cmd.Parameters.AddWithValue("@TitelID", titelID);

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
                            int titelIDIndex = reader.GetOrdinal("TitelID");
                            int tekniskInfoIndex = reader.GetOrdinal("TekniskInfoID");
                            int beskrivningIndex = reader.GetOrdinal("Beskrivning");
                            int titelIndex = reader.GetOrdinal("Titel");
                            int produktionsarIndex = reader.GetOrdinal("Produktionsår");
                            int produktionsbolagIndex = reader.GetOrdinal("Produktionsbolag");
                            int GenreIndex = reader.GetOrdinal("Genre");


                            // Returnerar referensen till de skapade Contact-objektet.
                            return new Titel
                            {
                                TitelID = reader.GetInt32(titelIDIndex),
                                TekniskInfoID = reader.GetInt32(tekniskInfoIndex),
                                Beskrivning = reader.GetString(beskrivningIndex),
                                Titel = reader.GetString(titelIndex),
                                Produktionsar = reader.GetDateTime(produktionsarIndex),
                                Produktionsbolag = reader.GetString(produktionsarIndex),
                                Genre = reader.GetString(GenreIndex)

                            };
                        }
                    }

                    // Istället för att returnera null kan du välja att kasta ett undatag om du 
                    // inte får "träff" på en titel. I denna applikation väljer jag att *inte* betrakta 
                    // det som ett fel i detta lager om det inte går att hitta en titel. Vad du väljer 
                    // är en smaksak...
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
        /// Skapar en ny post i tabellen Customer.
        /// </summary>
        /// <param name="customer">Kunduppgifter som ska läggas till.</param>
        public static void InsertTitel(Titel titel)
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
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 1000).Value = titel.Beskrivning;
                    cmd.Parameters.Add("@Titel", SqlDbType.VarChar, 50).Value = titel.Titel;
                    cmd.Parameters.Add("@Produktionsår", SqlDbType.DateTime, 10).Value = titel.Produktionsar;
                    cmd.Parameters.Add("@Produktionsbolag", SqlDbType.VarChar, 40).Value = titel.Produktionsbolag;
                    cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 20).Value = titel.Genre;

                    // Den här parametern är lite speciell. Den skickar inte något data till den lagrade proceduren,
                    // utan hämtar data från den. (Fungerar ungerfär som ref- och out-prameterar i C#.) Värdet 
                    // parametern kommer att ha EFTER att den lagrade proceduren exekverats är primärnycklens värde
                    // den nya posten blivit tilldelad av databasen.
                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@TekniskInfoID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    titel.TitelID = (int)cmd.Parameters["@TitelID"].Value;
                    titel.TekniskInfoID = (int)cmd.Parameters["@TekniskInfoID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar en kunds kunduppgifter i tabellen Customer.
        /// </summary>
        /// <param name="customer">Kunduppgifter som ska uppdateras.</param>
        public static void UpdateTitel(Titel titel)
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
                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Value = titel.TitelID;
                    cmd.Parameters.Add("@TekniskInfoID", SqlDbType.Int, 4).Value = titel.TekniskInfoID;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 1000).Value = titel.Beskrivning;
                    cmd.Parameters.Add("@Titel", SqlDbType.VarChar, 50).Value = titel.TitelID;
                    cmd.Parameters.Add("@Produktionsår", SqlDbType.DateTime, 10).Value = titel.Produktionsar;
                    cmd.Parameters.Add("@Produktionsbolag", SqlDbType.VarChar, 40).Value = titel.Produktionsbolag;
                    cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 20).Value = titel.Genre;

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
        /// Tar bort en kunds kunduppgifter.
        /// </summary>
        /// <param name="customerId">Kunds kundnummer.</param>
        public static void DeleteTitel(int titelID)
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
                    cmd.Parameters.Add("@TitelID", SqlDbType.Int, 4).Value = titelID;

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