using System;
using System.Windows.Forms;

namespace Web_Origin
{
    public partial class SimpleUserForm : Form
    {
        public static string UserLoggedName {get;set;}
        public SimpleUserForm()
        {
            InitializeComponent();
        }

        private void SaintsLoad(object sender, EventArgs e)
        {
            Services test = new Services();
            NumOfAgioi.Text = (test.getSaints().Count).ToString();
            nameOfUser.Text = (test.GetUser(Usemanagement.userID)).Firstname;
            UserLoggedName = nameOfUser.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Usemanagement mainMenu = new Usemanagement();
            mainMenu.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Insert_Agios form1 = new Insert_Agios();
            form1.Show();
        }



        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Agios form1 = new Search_Agios();
            form1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Saints agioiPopUp = new Saints();
            agioiPopUp.Show(this);
        }

        private void NumOfAgioi_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
