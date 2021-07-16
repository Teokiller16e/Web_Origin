using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Web_Origin.Models;

namespace Web_Origin
{
    public partial class Users : Form
    {
        public int selectedIdNumber { get; set; }
        public Services svr { get; set; }
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            svr = new Services();
            List<User> users = svr.getUsers();
            listView1.Items.Clear();

            foreach (var usr in users)
            {
                var row = new string[] { (usr.ID).ToString(), usr.Firstname, usr.Lastname, usr.Username, usr.Password, (usr.Administrator).ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = usr;
                listView1.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insert_User ins_usr = new Insert_User();
            this.Hide();
            ins_usr.Show();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
             selectedIdNumber = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedIdNumber != 0)
            {
                if(svr.DeleteUser(selectedIdNumber)==true)
                {
                    MessageBox.Show("Η διαγραφή χρήστη ολοκληρώθηκε με επιτυχία");
                    Users f1 = new Users();
                    this.Hide();
                    f1.Show();
                }
                else { MessageBox.Show("Υπήρξε σφάλμα, παρακαλούμε προσπαθήστε ξανά"); }
            }
            else
            {
                 MessageBox.Show("Δεν έχετε επιλέξει κανέναν από τους παραπάνω χρήστες.");
            }
        }
    }
}
