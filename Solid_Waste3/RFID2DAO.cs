using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Waste3
{
    internal class RFID2DAO
    {
    //connection string to database 
        string connectionString =

           " datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;";


        public List<RFID2> getallrfid()
        {
            //start with empty list 
            List<RFID2> returnThese = new List<RFID2>();

            // connect to mysql server 

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM RFID", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    RFID2 a2 = new RFID2
                    {
                        ID = reader.GetInt32(0),
                        EPC = reader.GetString(1),
                        Date_ = reader.GetDateTime(2),

                    };
                    returnThese.Add(a2);

                }
            }

            connection.Close();


            return returnThese;
        }


    }
}
