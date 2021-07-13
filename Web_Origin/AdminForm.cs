using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Origin
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Usemanagement mainMenu = new Usemanagement();
            mainMenu.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert_Agios mainMenu = new Insert_Agios();
            mainMenu.Show();

        }

            private void button4_Click(object sender, EventArgs e)
        {
            Users xristes = new Users();
            xristes.Show();
            // Αυτό θα μας πηγαίνει στους Χρήστες καινούργια φόρμα popup
            //var Delete_Agios = new Delete_Agios();
            //Delete_Agios.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Agios form1 = new Search_Agios();
            form1.Show();
        }

     
    }
}
/*
  SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                //SqlCommand command = new SqlCommand("SELECT * FROM Ekklisia.dbo.Xristes", connection);
                //SqlCommand command = new SqlCommand("insert into User(Onoma,Idiotita,Eikona,Date_eortis,Mikros_esperinos,Megalos_esperinos,Orthros,Eklogi,Theia_leitourgeia,Ymnografos,Xairetismoi,Egkomia,Eulogitaria,Eyxes,Mousiko_parartima,Apofasi,Egkrisi,Eikona_ekswfyllou,Plhrhs_titlos,Ekdotis,Topos_ekdosis,Date_ekdosis,CD,Phototypia,Posotita,Mnimi_anakomidi_synaksi) values('" + fir + "','" + las + "','" + usr + "','" + pass + "','" + admin + "') ",connection);
                //int sql_query = command.ExecuteNonQuery();
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                List<Models.User> xristes = new List<Models.User>();
                // Insert when command returns not null
                if (!dataReader.Equals(null))
                {

                    // loop for retrieving all the possible users from the database
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var firstname = dataReader["Firstname"].ToString();
                        var lastname = dataReader["Lastname"].ToString();
                        var username = dataReader["Username"].ToString();
                        var password = dataReader["Password"].ToString();
                        var administrator = dataReader.GetBoolean(5);

                        Models.User user = new Models.User(id, firstname, lastname, username, password, administrator);

                        xristes.Add(user);
                    }


                }
            }
*/