using System;
using System.Drawing;
using System.Windows.Forms;
namespace Web_Origin
{
    public partial class Usemanagement : Form
    {
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
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Hide();
                welcomeForm wForm = new welcomeForm();
                wForm.Show();
            }
            else
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
    }
}
