using System;
using System.Collections.Generic;
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
            Services svr = new Services();
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

    }
}
