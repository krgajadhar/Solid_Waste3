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
        string connectionString =

            " datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;";


        public List<GPS2> getallgps()
        {
            //start with empty list 
            List<GPS2> returnThese = new List<GPS2>();
        
            // connect to mysql server 

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM GPS", connection);

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

