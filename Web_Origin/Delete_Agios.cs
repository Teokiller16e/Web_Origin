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
    public partial class Delete_Agios : Form
    {
        public Delete_Agios()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Usemanagement.Administrator.Equals(1))
            {
                this.Hide();
                AdminForm f1 = new AdminForm();
                f1.Show();
            }
            else if (Usemanagement.Administrator.Equals(2))
            {
                this.Hide();
                SimpleUserForm f1 = new SimpleUserForm();
                f1.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var test =id.Text;
            string name = onoma.Text;
            string property = idiotita.Text;
            var celebration_date = hmeromhnia_eortis.Text; 

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                //SqlCommand command = new SqlCommand("DELETE  FROM Ekklisia.dbo.Agioi WHERE ID= 12", connection);
                string query = "Delete FROM Ekklisia.dbo.Agioi where ID= '" + test + "' AND Onoma='" + name + "'AND Idiotita='" + name + "' AND Date_eortis='" + celebration_date +"'"; 
                SqlCommand command = new SqlCommand(query, connection);
                //SqlCommand command = new SqlCommand("insert into User(Firstname,Lastname,Username,Password,Administrator) values('" + fir + "','" + las + "','" + usr + "','" + pass + "','" + admin + "') ",connection);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                if (dataReader.Equals(null))
                {
                    MessageBox.Show("Agios deleted");
                }
                else
                {
                    MessageBox.Show("Agios not deleted");
                }

            }

        }

    }
}
