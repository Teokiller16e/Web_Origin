using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Web_Origin.Models;

namespace Web_Origin
{
    public partial class Update_User : Form
    {
        public int extID { get; set; }
        public Services svr { get; set; }
        public Update_User()
        {
            InitializeComponent();
        }

        internal void LoadData (int idNumber)
        {
            extID = idNumber;
            User usr = new User();
            svr = new Services();
            usr = svr.GetUser(extID);

            onoma.Text = usr.Firstname;
            epwnymo.Text = usr.Lastname;
            username.Text = usr.Username;
            password.Text = usr.Password;
            if (usr.Administrator) { admin.Text = "ΝΑΙ"; }
            else { admin.Text = "ΟΧΙ"; }

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
                bool flag = svr.UpdateUser(extID, firstName, lastName, userName, pass, adminRights);

                if (flag)
                {
                    MessageBox.Show("Η ανανέωση του χρήστη ολοκληρώθηκε με επιτυχία !");
                    Users f1 = new Users();
                    this.Hide();
                    f1.Show();
                }
                else
                { MessageBox.Show("Υπήρξε κάποιο σφάλμα, προσπαθήστε ξανά."); }
            }
            else
            {
                MessageBox.Show("Τα κελιά (USERNAME & PASSWORD)\n είναι υποχρεωτικά για να ολοκληρωθεί η ΑΝΑΝΕΩΣΗ!");

            }


        }

        private void onoma_TextChanged(object sender, EventArgs e)
        {
           /* if (Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*if (Regex.Match(epwnymo.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                epwnymo.Text = string.Empty;
            }*/
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
