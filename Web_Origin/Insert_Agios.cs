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
    public partial class Insert_Agios : Form
    {
        public Insert_Agios()
        {
            InitializeComponent();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Receive form inputs and set to variables
            string  name = onoma.Text;
            string  property = idiotita.Text;
            bool photo = false;// eikones.Text;
            var celebration_date = hmeromhnia_eortis.Text; // only var
            bool small = false;// mikros_esperinos.Text;
            bool big = false;// megas_esperinos.Text;
            bool orthross = false; //orthros.Text;
            bool election = false;// eklogi.Text;
            bool theia_leit = false;// theia_leitourgeia.Text;
            string hymn = iera_paraklisi_ymnografos.Text;
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;
            bool decision = false; // apofaseis_apokatataksews.Text;
            bool approvement = false;// egkrisi.Text;
            bool img_eksw = false; // photo_ekswfyllou.Text;
            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            int pub_date = 22;// hmeromhnia_ekdosis.Text;
            string pub_place = topos_ekdosis.Text;
            bool disk = false; // digital_diskos.Text;
            string fyllada = fyllada_fwtotypia.Text;
            int quantity = 22;// posotita.Text;
            string synaksi = "";

            if (name != "" || property != "" || photo.Equals(true) || celebration_date != "" || small.Equals(true) || big.Equals(true) 
                || orthross.Equals(true) || election.Equals(true) || theia_leit.Equals(true) || hymn != "" || xairetism != "" || egkom != "" 
                || eulog != "" || wishes != "" || music != "" || decision.Equals(true) || approvement.Equals(true) || img_eksw.Equals(true) 
                || title != "" || publishe != "" || pub_date != 22 || pub_place.Equals(true) || disk.Equals(true) || fyllada != "" 
                || quantity != 22 || synaksi != "")
            {

                //Here the insert has to check to the database
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");
                connection.Open();

                //Insert query
                SqlCommand cmd = new SqlCommand("insert into Agioi(Onoma,Idiotita,Eikona,Date_eortis,Mikros_esperinos,Megalos_esperinos,Orthros,Eklogi,Theia_leitourgeia,Ymnografos,Xairetismoi,Egkomia,Eulogitaria,Eyxes,Mousiko_parartima,Apofasi,Egkrisi,Eikona_ekswfyllou,Plhrhs_titlos,Ekdotis,Topos_ekdosis,Date_ekdosis,CD,Phototypia,Posotita,Mnimi_anakomidi_synaksi)" +
                    "values ('" + name + "','" + property + "','" + photo + "','" + celebration_date + "','" + small + "','" + big + "','" + orthross + "','" + election + "','" + theia_leit + "','" + hymn + "','" + xairetism + "','" + egkom + "','" + eulog + "','" + wishes + "','" + music + "','" + decision + "','" + approvement + "','" + img_eksw + "','" + title + "','" + publishe + "','" + pub_place + "','" + pub_date + "','" + disk + "','" + fyllada + "','" + quantity + "','" + synaksi + "')", connection);

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
                MessageBox.Show("Παρακαλώ, συμπληρώστε τα κενά κελιά !");
            }
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
