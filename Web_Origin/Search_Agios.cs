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
    public partial class Search_Agios : Form
    {
        public Search_Agios()
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
            int empty_spaces = 0;

            string name = onoma.Text;
            string property = idiotita.Text;

            bool photo=false;
            if (comboBox11.Text == "ΝΑΙ")
            { photo = true; }
            else if (comboBox11.Text == "ΟΧΙ")
            { photo = false; }
            else { empty_spaces += 1; }


            var celebration_date = hmeromhnia_eortis.Text;
            //checked


            bool small=false;
            if (comboBox10.Text == "ΝΑΙ")
            { small = true; }
            else if (comboBox10.Text == "ΟΧΙ")
            { small = false; }
            else { empty_spaces += 1; }

            bool big=false;
            if (comboBox9.Text == "ΝΑΙ")
            { big = true; }
            else if (comboBox9.Text == "ΟΧΙ")
            { big = false; }
            else { empty_spaces += 1; }

            bool orthross=false;
            if (comboBox8.Text == "ΝΑΙ")
            { orthross = true; }
            else if (comboBox8.Text == "ΟΧΙ")
            { orthross = false; }
            else { empty_spaces += 1; }


            bool election=false;
            if (comboBox7.Text == "ΝΑΙ")
            { election = true; }
            else if (comboBox7.Text == "ΟΧΙ")
            { election = false; }
            else { empty_spaces += 1; }


            bool theia_leit=false;
            if (comboBox6.Text == "ΝΑΙ")
            { theia_leit = true; }
            else if (comboBox6.Text == "ΟΧΙ")
            { theia_leit = false; }
            else { empty_spaces += 1; }


            string hymn = iera_paraklisi_ymnografos.Text;
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;

            bool decision=false;
            if (comboBox5.Text == "ΝΑΙ")
            { decision = true; }
            else if (comboBox5.Text == "ΟΧΙ")
            { decision = false; }
            else { empty_spaces += 1; }

            bool approvement=false;
            if (comboBox4.Text == "ΝΑΙ")
            { approvement = true; }
            else if (comboBox4.Text == "ΟΧΙ")
            { approvement = false; }
            else { empty_spaces += 1; }


            bool img_eksw = false;
            if (comboBox3.Text == "ΝΑΙ")
            { img_eksw = true; }
            else if (comboBox3.Text == "ΟΧΙ")
            { img_eksw = false; }
            else { empty_spaces += 1; }


            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            int pub_date;

            if (hmeromhnia_ekdosis.Text == "")
            { pub_date = 0; }
            else
            { pub_date = Int32.Parse(hmeromhnia_ekdosis.Text); }

            string pub_place = topos_ekdosis.Text;

            bool disk=false;
            if (comboBox2.Text == "ΝΑΙ")
            { disk = true; }
            else if (comboBox2.Text == "ΟΧΙ")
            { disk = false; }
            else { empty_spaces += 1; }


            bool fyllada=false;
            if (comboBox1.Text == "ΝΑΙ")
            { fyllada = true; }
            else if (comboBox1.Text == "ΟΧΙ")
            { fyllada = false; }
            else { empty_spaces += 1; }


            int quantity;
            if (posotita.Text == "")
            { quantity = 0; }
            else
            { quantity = Int32.Parse(posotita.Text); }

            string synaksi = "";

            if (name != "" && property != "" && celebration_date != "" && hymn != "" && xairetism != "" && egkom != "" && eulog != ""
                && wishes != "" && music != "" && title != "" && publishe != "" && pub_date != 0 && quantity != 0 && empty_spaces==0)
            {

                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    //SqlCommand command = new SqlCommand("DELETE  FROM Ekklisia.dbo.Agioi WHERE ID= 12", connection);
                    //string query = "SELECT * FROM Ekklisia.dbo.Agioi WHERE Onoma='" + name+ "'"; 
                    string query = "SELECT * FROM Ekklisia.dbo.Agioi WHERE Onoma='" + name + "'AND Idiotita='" + property + "' AND Eikona='" + photo + "'AND Date_eortis='" + celebration_date + "' AND Mikros_esperinos='"
                        + small + "'AND Megalos_esperinos='" + big + "' AND Orthros='" + orthross + "'AND Eklogi='" + election + "' AND Theia_leitourgeia='" + theia_leit + "'AND Ymnografos='"
                        + hymn + "' AND Xairetismoi='" + xairetism + "'AND Egkomia='" + egkom + "' AND Eulogitaria='" + eulog + "'AND Eyxes='" + wishes + "' AND Mousiko_parartima='"
                        + music + "'AND Apofasi='" + decision + "' AND Egkrisi='" + approvement + "' AND Eikona_ekswfyllou='" + img_eksw + "'AND Plhrhs_titlos='" + title + "' AND Ekdotis='"
                        + publishe + "'AND Topos_ekdosis='" + pub_place + "' AND Date_ekdosis='" + pub_date + "'AND CD='" + disk + "' AND Phototypia='" + fyllada + "' AND Posotita='"
                        + quantity + "'AND Mnimi_anakomidi_synaksi='" + synaksi + "'";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dataReader;
                    dataReader = command.ExecuteReader();
                    List<Agios> agioi = new List<Agios>();

                    if (!dataReader.Equals(null))
                    {

                        // loop for retrieving all the possible users from the database:
                        while (dataReader.Read())
                        {
                            var id = dataReader.GetInt32(0);
                            string onom = dataReader["Onoma"].ToString();
                            string proper = dataReader["Idiotita"].ToString();
                            Boolean foto = dataReader.GetBoolean(3);
                            DateTime cel_date = dataReader.GetDateTime(4);
                            Boolean mikros = dataReader.GetBoolean(5);
                            Boolean megas = dataReader.GetBoolean(6);
                            Boolean orthros = dataReader.GetBoolean(7);
                            Boolean elect = dataReader.GetBoolean(8);
                            Boolean theia_leitourg = dataReader.GetBoolean(9); ;
                            string ymnos = dataReader["Ymnografos"].ToString();
                            string xairet = dataReader["Xairetismoi"].ToString();
                            string eulogitar = dataReader["Eulogitaria"].ToString();
                            string egkwmi = dataReader["Egkomia"].ToString();
                            string euxs = dataReader["Eyxes"].ToString();
                            string mousik = dataReader["Mousiko_parartima"].ToString();
                            Boolean apofas = dataReader.GetBoolean(16);
                            Boolean approve = dataReader.GetBoolean(17);
                            Boolean eiko_eks = dataReader.GetBoolean(18);
                            string titloss = dataReader["Plhrhs_titlos"].ToString();
                            string publisher = dataReader["Ekdotis"].ToString();
                            string publish_place = dataReader["Topos_ekdosis"].ToString();
                            int publish_date = dataReader.GetInt32(22);
                            Boolean disc = dataReader.GetBoolean(23);
                            string phototypia_fyllada = dataReader["Phototypia"].ToString();
                            Boolean fyllad;
                            if (phototypia_fyllada == "True") { fyllad = true; }
                            else { fyllad = false; }
                            int posot = dataReader.GetInt32(25);
                            var synakss = dataReader["Mnimi_anakomidi_synaksi"].ToString();


                            //Models.User user = new Models.User(id, firstname, lastname, username, password, administrator);
                            Agios saint = new Agios(id, onom, proper, foto, cel_date, mikros, megas, orthros, elect, theia_leitourg, ymnos, xairet, egkwmi, eulogitar, euxs, mousik, apofas, approve,
                                eiko_eks, titloss, publisher, publish_place, publish_date, disc, fyllad, posot, synakss);

                            agioi.Add(saint);
                        }
                        if (agioi.Count == 0)
                        {
                            MessageBox.Show("Δεν βρέθηκαν αποτελέμσατα που αντιστοιχούν στα στοιχεία.");
                        }
                        else { MessageBox.Show("Η αναζήτηση ολοκληρώθηκε με επιτυχία !!"); }
                    }
                    else
                    {
                        MessageBox.Show("Υπήρξε κάποιο σφάλμα, προσπαθήστε ξανά.");
                    }

                }

             

            }
            else
            {
                MessageBox.Show("Παρακαλώ, συμπληρώστε τα κενά κελιά !");
            }


        }
    }
}
