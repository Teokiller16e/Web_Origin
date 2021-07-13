using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Web_Origin
{
    public partial class Usemanagement : Form
    {
        public bool found;
        public static int Administrator;
        public Usemanagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");        
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");


            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                // SqlCommand command = new SqlCommand("SELECT * FROM Ekklisia.dbo.Xristes",connection);
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Xristes", connection);
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

                // Decide requirements for each windows form
                for (int i = 0; i < xristes.Count; i++)
                {
                    if (textBox1.Text == xristes[i].Username && textBox2.Text == xristes[i].Password && xristes[i].Administrator.Equals(true))
                    {
                        this.Hide();
                        AdminForm wForm = new AdminForm();
                        wForm.Show();
                        found = true;
                        Administrator = 1;
                    }
                    else if (textBox1.Text == xristes[i].Username && textBox2.Text == xristes[i].Password && xristes[i].Administrator.Equals(false))
                    {
                        this.Hide();
                        SimpleUserForm wForm = new SimpleUserForm();
                        wForm.Show();
                        found = true;
                        Administrator = 2;
                    }
                   
                    
                }

                if(found.Equals(false))
                { 
                    errorMessageFunction();
                }
            }
           
            
        }

        // Pop up error message
        private void errorMessageFunction()
        {
            // Get reference to the dialog type.
            var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
            var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

            // Create dialog instance.
            var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

            // Populate relevant properties on the dialog instance.
            dialog.Text = "Λάθος Στοιχεία Λογαριασμού";
            dialogType.GetProperty("Details").SetValue(dialog, "Παρουσιάστηκε σφάλμα στην εισαγωγή των στοιχείων σας", null);
            dialogType.GetProperty("Message").SetValue(dialog, "Λάθος στοιχεία, παρακαλούμε προσπαθήστε ξανά", null);

            // Display dialog.
            var result = dialog.ShowDialog();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


