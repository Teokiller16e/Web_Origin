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
using Web_Origin.Models;

namespace Web_Origin
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            List<User> users = returnUsers();
            listView1.Items.Clear();

            foreach (var usr in users)
            {
                var row = new string[] { (usr.ID).ToString(), usr.Firstname, usr.Lastname, usr.Username, usr.Password, (usr.Administrator).ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = usr;
                listView1.Items.Add(lvi);
            }

        }

        private List<User> returnUsers()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Xristes", connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                List<User> xristes = new List<User>();


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

                        User user = new User(id, firstname, lastname, username, password, administrator);

                        xristes.Add(user);
                    }
                }
                return xristes;
            }
            else { return null; }
        }
    }
}
