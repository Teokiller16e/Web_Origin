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
    public partial class Update_Agios : Form
    {
        public Update_Agios()
        {
            InitializeComponent();
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
            int empty_space = 0; 
            string name = onoma.Text;
            string property = idiotita.Text;


            bool photo=false;
            if (comboBox10.Text == "ΝΑΙ")
            { photo = true; }
            else if (comboBox10.Text=="ΟΧΙ"){ photo = false; }
            else { empty_space +=1; }


            var celebration_date = hmeromhnia_eortis.Text;
            //checked
            bool small=false;
            if (comboBox9.Text == "ΝΑΙ")
            { small = true; }
            else if (comboBox9.Text == "ΟΧΙ") { small = false; }
            else { empty_space += 1; }

            bool big=false;
            if (comboBox8.Text == "ΝΑΙ")
            { big = true; }
            else if (comboBox8.Text == "ΟΧΙ") { big = false; }
            else { empty_space += 1; }

            bool orthross=false;
            if (comboBox7.Text == "ΝΑΙ")
            { orthross = true; }
            else if (comboBox7.Text == "ΟΧΙ") { orthross = false; }
            else { empty_space += 1; }

            bool election=false;
            if (comboBox6.Text == "ΝΑΙ")
            { election = true; }
            else if (comboBox6.Text == "ΟΧΙ") { election = false; }
            else { empty_space += 1; }


            bool theia_leit=false;
            if (comboBox5.Text == "ΝΑΙ")
            { theia_leit = true; }
            else if (comboBox5.Text == "ΟΧΙ") { theia_leit = false; }
            else { empty_space += 1; }


            string hymn = iera_paraklisi_ymnografos.Text;
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;

            bool decision=false;
            if (comboBox4.Text == "ΝΑΙ")
            { decision = true; }
            else if (comboBox4.Text == "ΟΧΙ") { decision = false; }
            else { empty_space += 1; }


            bool approvement=false;
            if (comboBox3.Text == "ΝΑΙ")
            { approvement = true; }
            else if (comboBox3.Text == "ΟΧΙ") { approvement = false; }
            else { empty_space += 1; }


            bool img_eksw = false;
            if (comboBox1.Text == "ΝΑΙ")
            { img_eksw = true; }
            else if (comboBox1.Text == "ΟΧΙ") { img_eksw = false; }
            else { empty_space += 1; }


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
            else if (comboBox11.Text == "ΟΧΙ") { disk = false; }
            else { empty_space += 1; }


            bool fyllada=false;
            if (comboBox12.Text == "ΝΑΙ")
            { fyllada = true; }
            else if (comboBox12.Text == "ΟΧΙ") { fyllada = false; }
            else { empty_space += 1; }


            int quantity;
            if (posotita.Text == "")
            { quantity = 0; }
            else
            { quantity = Int32.Parse(posotita.Text); }

            string synaksi = "";


            //

            if (name != "" && property != "" && celebration_date != "" && hymn != "" && xairetism != "" && egkom != "" && eulog != ""
                && wishes != "" && music != "" && title != "" && publishe != "" && pub_date != 0 && quantity != 0 && empty_space==0)
            {

                //Here the insert has to check to the database
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");
                connection.Open();

                //Insert query
                SqlCommand cmd = new SqlCommand("insert into Agioi(Onoma,Idiotita,Eikona,Date_eortis,Mikros_esperinos,Megalos_esperinos,Orthros," +
                    "Eklogi,Theia_leitourgeia,Ymnografos,Xairetismoi,Egkomia,Eulogitaria,Eyxes,Mousiko_parartima,Apofasi,Egkrisi,Eikona_ekswfyllou," +
                    "Plhrhs_titlos,Ekdotis,Topos_ekdosis,Date_ekdosis,CD,Phototypia,Posotita,Mnimi_anakomidi_synaksi)" +
                    "values ('" + name + "','" + property + "','" + photo + "','" + celebration_date + "','" + small + "','" + big + "','" +
                    orthross + "','" + election + "','" + theia_leit + "','" + hymn + "','" + xairetism + "','" + egkom + "','" + eulog +
                    "','" + wishes + "','" + music + "','" + decision + "','" + approvement + "','" + img_eksw + "','" + title +
                    "','" + publishe + "','" + pub_place + "','" + pub_date + "','" + disk + "','" + fyllada + "','" +
                    quantity + "','" + synaksi + "')", connection);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
