using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Waste3
{
    internal class GPS2DAO
    {
        // connection string to database 
        string connectionString =" datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;" 
       
            //intializes to create list of values 
            
            public List<GPS2> getallgps()
        {
            //Start with empty list 
            List<GPS2> returnThese = new List<GPS2>();
        
            // Connect to mysql server 

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            
            // Selects all values from GPS table in database
            MySqlCommand command = new MySqlCommand("SELECT * FROM GPS", connection);
            
            // Reads values from the GPS table in database 
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    GPS2 a1 = new GPS2
                    {
                        ID = reader.GetInt32(0),
                        Coordinates = reader.GetString(1),
                        Date_ = reader.GetDateTime(2),

                    };
                    returnThese.Add(a1);

                }
            }

            connection.Close();


            return returnThese;
        }
    }
}

