using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trin6
{
    internal class DBClient
    {
        public void Start()
        {
            // DB Forbindelse til HotelDB Databasen.
            string connectionString = "Server=DESKTOP-O538DNS;Database=HotelDB;Integrated Security=True;\r\n";

            // Opretter en ny SQL Connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Åbner forbindelsen
                connection.Open();

                // SQL Command som henter alle hotellerne (trin 6,1)
                string selectQuery = "SELECT * FROM DEMOHOTEL";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    // Bruger SqlDataReader til at hente hotellerne
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Læser data fra reader
                        while (reader.Read())
                        {
                            // Eksempel: Læs hotel ID og navn
                            int hotelId = reader.GetInt32(0); 
                            string hotelName = reader.GetString(1); 
                            
                            // Printer det ud til konsollen
                            Console.WriteLine($"Hotel ID: {hotelId}, Hotel Navn: {hotelName}");
                        }
                    }
                }

                // Hent specifikt hotel (trin 6,2)
                int specificHotelNo = 8;
                string selectSpecificQuery = $"SELECT * FROM DEMOHOTEL WHERE Hotel_No = {specificHotelNo}";

                // Opretter en SQL ommand object for at hente det specifike hotel
                using (SqlCommand commandSpecific = new SqlCommand(selectSpecificQuery, connection))
                {
                    using (SqlDataReader readerSpecific = commandSpecific.ExecuteReader())
                    {

                        while (readerSpecific.Read())
                        {
                            int hotelIdSpecific = readerSpecific.GetInt32(0);
                            string hotelNavnSpecific = readerSpecific.GetString(1);


                            // Printer det "specielle" hotel ud til konsollen
                            Console.WriteLine($"HotelID: {hotelIdSpecific}, Hotel Navn: {hotelNavnSpecific}");
                        }
                    }
                }

                // CRUD metoden.
                //Indsæt et hotel (trin 6,3)
                string insertQuery = "INSERT INTO DEMOHOTEL (Hotel_No, Name, Address) VALUES (9, 'GulRose', 'HC Andersens Vej 34, København')";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                }

                //Slet et hotel (trin 6.4)

                string deleteQuery = "DELETE FROM DEMOHOTEL WHERE Hotel_No = 10";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                }

                //Opdater et hotel (trin 6.5) 

                string updateQuery = "UPDATE DEMOHOTEL SET Name = 'AkaiHotel' WHERE Hotel_No = 4";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
