using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using Web_Origin.Models;

namespace Web_Origin
{
    public partial class Usemanagement : Form
    {
        public bool found;
        public static int Administrator;
        public static int userID;
        public Usemanagement()
        {
            InitializeComponent();
            ControlExtension.Draggable(this, true);

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

                Services svr = new Services();
                List<User> xristes = new List<User>();
                xristes = svr.getUsers();

                // Decide requirements for each windows form
                for (int i = 0; i < xristes.Count; i++)
                {
                    if (textBox1.Text == xristes[i].Username && textBox2.Text == xristes[i].Password && xristes[i].Administrator.Equals(true))
                    {
                        userID = xristes[i].ID;
                        this.Hide();
                        AdminForm wForm = new AdminForm();
                        wForm.Show();
                        found = true;
                        Administrator = 1;
                    }
                    else if (textBox1.Text == xristes[i].Username && textBox2.Text == xristes[i].Password && xristes[i].Administrator.Equals(false))
                    {
                    // Μόνο σε περίπτωση user αλλάζουμε το static UserId για να τον βρούμε μετά 
                        userID = xristes[i].ID;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this, true);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}


