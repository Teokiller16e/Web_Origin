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
    public partial class Update_Agios : Form
    {
        public int extID { get; set; }
        public Services svr { get; set; }
        public Update_Agios()
        {
            InitializeComponent();
        }

        internal void LoadData(int idNumber)
        {
            extID = idNumber;
            Agios saint = new Agios();
            svr = new Services();
            saint = svr.GetSaint(extID);

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Usemanagement.Administrator.Equals(1))
            {
                this.Hide();
                AdminForm f1 = new AdminForm();
                f1.Show();
            }
            else if (Usemanagement.Administrator.Equals(2))
            {
                this.Hide();
                SimpleUserForm f1 = new SimpleUserForm();
                f1.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Receive form inputs and set to variables
            string name = onoma.Text;
            string property = idiotita.Text;

            bool photo=false;
            if (comboBox10.Text == "ΝΑΙ")
            { photo = true; }

            var celebration_date = hmeromhnia_eortis.Text + "-1970";
            //checked
            bool small =false;
            if (comboBox9.Text == "ΝΑΙ")
            { small = true; }
            

            bool big=false;
            if (comboBox8.Text == "ΝΑΙ")
            { big = true; }
           
            bool orthross=false;
            if (comboBox7.Text == "ΝΑΙ")
            { orthross = true; }
           
            bool election=false;
            if (comboBox6.Text == "ΝΑΙ")
            { election = true; }

            bool theia_leit=false;
            if (comboBox5.Text == "ΝΑΙ")
            { theia_leit = true; }

            string hymn = iera_paraklisi_ymnografos.Text;
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;

            bool decision=false;
            if (comboBox4.Text == "ΝΑΙ")
            { decision = true; }

            bool approvement=false;
            if (comboBox3.Text == "ΝΑΙ")
            { approvement = true; }

            bool img_eksw = false;
            if (comboBox1.Text == "ΝΑΙ")
            { img_eksw = true; }

            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            int pub_date;

            if (hmeromhnia_ekdosis.Text == "")
            { pub_date = 0; }
            else
            { pub_date = Int32.Parse(hmeromhnia_ekdosis.Text); }

            string pub_place = topos_ekdosis.Text;

            bool disk=false;
            if (comboBox11.Text == "ΝΑΙ")
            { disk = true; }

            bool fyllada=false;
            if (comboBox12.Text == "ΝΑΙ")
            { fyllada = true; }

            int quantity;
            if (posotita.Text == "")
            { quantity = 0; }
            else
            { quantity = Int32.Parse(posotita.Text); }

            string synaksi = "";

            string metathesi_eortis = MetathesiEortis.Text;
            //

            if (name != "" && property != "" && celebration_date != "" )
            {

                // Previous sqlconnection :
                //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");
                 SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
                connection.Open();
                //Insert query
                SqlCommand cmd = new SqlCommand("insert into Agioi(Onoma,Idiotita,Eikona,Date_eortis,Mikros_esperinos,Megalos_esperinos,Orthros,Eklogi,Theia_leitourgeia," +
                    "Ymnografos,Xairetismoi,Egkomia,Eulogitaria,Eyxes,Mousiko_parartima,Apofasi,Egkrisi,Eikona_ekswfyllou,Plhrhs_titlos,Ekdotis,Topos_ekdosis,Date_ekdosis,CD,Phototypia," +
                    "Posotita,Metathesi_Eortis,Mnimi_anakomidi_synaksi)" +
                    "values ('" + name + "','" + property + "','" + photo + "','" + celebration_date + "','" + small + "','" + big + "','" + orthross + "','" + election + "','"
                    + theia_leit + "','" + hymn + "','" + xairetism + "','" + egkom + "','" + eulog + "','" + wishes + "','" + music + "','" + decision + "','" + approvement + "','"
                    + img_eksw + "','" + title + "','" + publishe + "','" + pub_place + "','" + pub_date + "','" + disk + "','" + fyllada + "','" + quantity + "','" +
                    metathesi_eortis + "','" + synaksi + "')", connection);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (!dataReader.Equals(null))
                {
                    MessageBox.Show("Ο Άγιος καταχωρήθηκε στην βάση.");
                    this.Hide();
                    Insert_Agios f1 = new Insert_Agios();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Υπήρξε κάποιο σφάλμα, προσπαθήστε ξανά.");
                }
            }
            else
            {
                MessageBox.Show("Τα κελιά (Όνομα,Ιδιότητε και Ημερομηνία Εορτής είναι υποχρεωτικά !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }
    }
}
