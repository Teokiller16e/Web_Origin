using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Origin
{
    public partial class Insert_User : Form
    {
       
        public Insert_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users f1 = new Users();
            f1.Show(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Usemanagement mainMenu = new Usemanagement();
            mainMenu.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Usemanagement mainMenu = new Usemanagement();
            mainMenu.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            Users xristes = new Users();
            this.Hide();
            xristes.Show();
        }

        public void button3_Click_1(object sender, EventArgs e)
        {
            string firstName, lastName, userName, pass;
            bool adminRights = false;

            firstName = onoma.Text;
            lastName = epwnymo.Text;
            userName = username.Text;
            pass = password.Text;


            if (admin.Text == "ΝΑΙ")
            {
                adminRights = true;
            }


            if (userName != "" && pass != "")
            {
                Services svr = new Services();
                bool flag = svr.InsertUser(firstName, lastName, userName, pass, adminRights);
                if (flag)
                { 
                    MessageBox.Show("Η εισαγωγή του χρήστη ολοκληρώθηκε με επιτυχία !");
                    Insert_User f1 = new Insert_User();
                    this.Hide();
                    f1.Show();
                }
                else
                {MessageBox.Show("Υπήρξε κάποιο σφάλμα, προσπαθήστε ξανά."); }
            }
            else
            {
                MessageBox.Show("Τα κελιά (USERNAME & PASSWORD)\n είναι υποχρεωτικά για να ολοκληρωθεί η ΕΙΣΑΓΩΓΗ!");

            }


        }

    



   

        private void onoma_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(epwnymo.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                epwnymo.Text = string.Empty;
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
