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

        private void SaintsLoad(object sender, EventArgs e)
        {
            Services test = new Services();
            NumOfAgioi.Text = ((test.getSaints()).Count).ToString();
            NumOfUsers.Text = ((test.getUsers()).Count).ToString();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            Άγιοι agioiPopUp = new Άγιοι();
            agioiPopUp.Show(this);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
