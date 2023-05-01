using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Waste3
{
    internal class Truck3DAO
    {

        string connectionString =

          " datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;";


        public List<Trucks3> getalltrucks2()
        {
            //start with empty list 
            List<Trucks3> returnThese = new List<Trucks3>();

            // connect to mysql server 

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();


            MySqlCommand command = new MySqlCommand("SELECT * FROM TRUCKS", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Trucks3 a = new Trucks3
                    {
                        ID = reader.GetInt32(0),
                        Foreman = reader.GetString(1),
                        TruckNumber = reader.GetInt32(2),
                       

                    };
                    returnThese.Add(a);

                }
            }

            connection.Close();


            return returnThese;
        }



    }
}
