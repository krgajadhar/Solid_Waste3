using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Solid_Waste3
{
    public partial class Form1 : Form
    {

        BindingSource truck3BindingSource = new BindingSource();
        BindingSource rfid2BindingSource = new BindingSource();
        BindingSource gps2BindingSource = new BindingSource();
        BindingSource images2BindingSource = new BindingSource();
        BindingSource showBindingSource = new BindingSource();

        MySqlConnection connection = new MySqlConnection("datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;");

        MySqlCommand command;

        MySqlDataReader reader;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Truck3DAO truck3DAO = new Truck3DAO();

            //Connect the list to the grid view control
            truck3BindingSource.DataSource = truck3DAO.getalltrucks2();

            dataGridView1.DataSource = truck3BindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RFID2DAO rFID2DAO = new RFID2DAO();

            //Connect the list to the grid view control
            rfid2BindingSource.DataSource = rFID2DAO.getallrfid();

            dataGridView1.DataSource = rfid2BindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GPS2DAO gPS2DAO = new GPS2DAO();

            //Connect the list to the grid view control
            gps2BindingSource.DataSource = gPS2DAO.getallgps();

            dataGridView1.DataSource = gps2BindingSource;



        }


        private void button6_Click(object sender, EventArgs e)
        {


            MySqlConnection connection = new MySqlConnection("datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;");
            MySqlCommand command = new MySqlCommand("SELECT Photo_Data FROM Images ORDER BY Date_  DESC LIMIT 3", connection);


            connection.Open();

            List<Image> images = new List<Image>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    byte[] imageData = (byte[])reader["Photo_Data"];


                    MemoryStream ms = new MemoryStream(imageData);
                    Image image = Image.FromStream(ms);

                    images.Add(image);
                }
            }

            if (images.Count > 0)
            {
                // display the images in picture boxes
                pictureBox1.Image = images[0];
                pictureBox3.Image = images[1];
                pictureBox4.Image = images[2];

            }


            //dataGridView1.DataSource = showBindingSource;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;


            MySqlConnection connection = new MySqlConnection("datasource=172.20.10.7; port=3306; username=jevin; password=password; database=GarbageDB;");

            connection.Open();



            string query = "SELECT ID, Foreman, TruckNumber FROM TRUCKS WHERE ID LIKE '%" + searchTerm + "%' " +
                  "UNION " +
                  "SELECT ID, EPC, Date_ FROM RFID WHERE ID  LIKE '%" + searchTerm + "%' " +
                  "UNION " +
                  "SELECT ID, Coordinates, Date_ FROM GPS WHERE ID LIKE '%" + searchTerm + "%';";


            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

            // create a DataTable object to hold the results
            DataTable dataTable = new DataTable();

            // fill the DataTable object with the results from the query
            adapter.Fill(dataTable);

            // bind the DataTable object to the DataGridView control
            dataGridView1.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


