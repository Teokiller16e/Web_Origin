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

            Boolean photo=false;
            if (comboBox11.Text == "ΝΑΙ")
            { photo = true; }
            else if (comboBox11.Text == "ΟΧΙ")
            { photo = false; }
            else { empty_spaces += 1; }

            var celebration_date = hmeromhnia_eortis.Text;

            Boolean small =false;
            if (comboBox10.Text == "ΝΑΙ")
            { small = true; }
            else if (comboBox10.Text == "ΟΧΙ")
            { small = false; }
            else { empty_spaces += 1; }

            Boolean big =false;
            if (comboBox9.Text == "ΝΑΙ")
            { big = true; }
            else if (comboBox9.Text == "ΟΧΙ")
            { big = false; }
            else { empty_spaces += 1; }

            Boolean orthross =false;
            if (comboBox8.Text == "ΝΑΙ")
            { orthross = true; }
            else if (comboBox8.Text == "ΟΧΙ")
            { orthross = false; }
            else { empty_spaces += 1; }


            Boolean election =false;
            if (comboBox7.Text == "ΝΑΙ")
            { election = true; }
            else if (comboBox7.Text == "ΟΧΙ")
            { election = false; }
            else { empty_spaces += 1; }


            Boolean theia_leit =false;
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

            Boolean decision =false;
            if (comboBox5.Text == "ΝΑΙ")
            { decision = true; }
            else if (comboBox5.Text == "ΟΧΙ")
            { decision = false; }
            else { empty_spaces += 1; }

            Boolean approvement =false;
            if (comboBox4.Text == "ΝΑΙ")
            { approvement = true; }
            else if (comboBox4.Text == "ΟΧΙ")
            { approvement = false; }
            else { empty_spaces += 1; }


            Boolean img_eksw = false;
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

            Boolean disk =false;
            if (comboBox2.Text == "ΝΑΙ")
            { disk = true; }
            else if (comboBox2.Text == "ΟΧΙ")
            { disk = false; }
            else { empty_spaces += 1; }


            Boolean fyllada =false;
            if (comboBox1.Text == "ΝΑΙ")
            { fyllada = true; }
            else if (comboBox1.Text == "ΟΧΙ")
            { fyllada = false; }
            else { empty_spaces += 1; }

            int aukson_ar;
            if (IDtextBox.Text == "")
            { aukson_ar = 0; }
            else
            { aukson_ar = Int32.Parse(IDtextBox.Text); }

            int quantity;
            if (posotita.Text == "")
            { quantity = 0; }
            else
            { quantity = Int32.Parse(posotita.Text); }

            string synaksi = "";

                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    
                    connection.Open();


                    string query = "SELECT * FROM Ekklisia.dbo.Agioi";
                    //string query = "SELECT * FROM Ekklisia.dbo.Agioi WHERE Onoma='" + name + "'AND Idiotita='" + property + "' AND Eikona='" + photo + "'AND Date_eortis='" + celebration_date + "' AND Mikros_esperinos='"
                     //   + small + "'AND Megalos_esperinos='" + big + "' AND Orthros='" + orthross + "'AND Eklogi='" + election + "' AND Theia_leitourgeia='" + theia_leit + "'AND Ymnografos='"
                     //   + hymn + "' AND Xairetismoi='" + xairetism + "'AND Egkomia='" + egkom + "' AND Eulogitaria='" + eulog + "'AND Eyxes='" + wishes + "' AND Mousiko_parartima='"
                     //   + music + "'AND Apofasi='" + decision + "' AND Egkrisi='" + approvement + "' AND Eikona_ekswfyllou='" + img_eksw + "'AND Plhrhs_titlos='" + title + "' AND Ekdotis='"
                     //   + publishe + "'AND Topos_ekdosis='" + pub_place + "' AND Date_ekdosis='" + pub_date + "'AND CD='" + disk + "' AND Phototypia='" + fyllada + "' AND Posotita='"
                     //   + quantity + "'AND Mnimi_anakomidi_synaksi='" + synaksi + "'";

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
                        else 
                        {
                            MessageBox.Show("Η αναζήτηση ολοκληρώθηκε με επιτυχία !!");
                            List<Agios> returnedAgioi = new List<Agios>();
                            bool flagAccepted;

                            for (int i = 0; i < agioi.Count; i++) // 
                            {
                                flagAccepted = false;

                                if (name != "")
                                {
                                    if (name == agioi[i].Onoma)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (property != "")
                                {
                                    if (property == agioi[i].Idiotita)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }


                                if (comboBox11.Text != "Επιλέξτε")
                                {
                                    if (photo == agioi[i].Eikona)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (hmeromhnia_eortis.Text !="")
                                {
                                    DateTime cel_date = Convert.ToDateTime(celebration_date);
                                    if (cel_date == agioi[i].Date_Eortis)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox10.Text != "Επιλέξτε")
                                {
                                    if (small == agioi[i].Mikros_esperinos)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox9.Text != "Επιλέξτε")
                                {
                                    if (big == agioi[i].Megalos_esperinos)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox8.Text != "Επιλέξτε")
                                {
                                    if (orthross == agioi[i].Orthros)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox7.Text != "Επιλέξτε")
                                {
                                    if (election == agioi[i].Eklogi)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox6.Text != "Επιλέξτε")
                                {
                                    if (theia_leit == agioi[i].Theia_leitourgeia)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (hymn != "")
                                {
                                    if (hymn == agioi[i].Ymnografos)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (xairetism != "")
                                {
                                    if (xairetism == agioi[i].Xairetismoi)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (egkom != "")
                                {
                                    if (egkom == agioi[i].Egkomia)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (eulog != "")
                                {
                                    if (eulog  == agioi[i].Eulogitaria)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (wishes != "")
                                {
                                    if (wishes == agioi[i].Eyxes)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (music != "")
                                {
                                    if (music == agioi[i].Mousiko_parartima)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox5.Text != "Επιλέξτε")
                                {
                                    if (decision == agioi[i].Apofasi)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox4.Text != "Επιλέξτε")
                                {
                                    if (approvement == agioi[i].Egkrisi)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox3.Text != "Επιλέξτε")
                                {
                                    if (img_eksw == agioi[i].Eikona_ekswfyllou)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (title != "")
                                {
                                    if (title == agioi[i].Plhrhs_titlos)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (publishe != "")
                                {
                                    if (publishe == agioi[i].Ekdotis)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (hmeromhnia_ekdosis.Text != "")
                                {
                                    if (pub_date == agioi[i].Date_ekdosis)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (pub_place != "")
                                {
                                    if (pub_place == agioi[i].Topos_ekdosis)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox2.Text != "Επιλέξτε")
                                {
                                    if (disk == agioi[i].CD)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (comboBox1.Text != "Επιλέξτε")
                                {
                                    if (fyllada == agioi[i].Phototypia)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (posotita.Text != "")
                                {
                                    if (quantity == agioi[i].Posotita)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (synaksi != "")
                                {
                                    if (synaksi == agioi[i].Mnimi_anakomidi_synaksi)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }

                                if (IDtextBox.Text != "")
                                {
                                    if ( aukson_ar == agioi[i].ID)
                                    {
                                        flagAccepted = true;
                                    }
                                    else
                                    {
                                        flagAccepted = false;
                                    }
                                }
                                 // leipei h metathesi eortis
                                if (flagAccepted == true)
                                {
                                    returnedAgioi.Add(agioi[i]);
                                }
                            }
                            for (int i = 0; i < returnedAgioi.Count; i++)
                            { Console.WriteLine("Onoma {returnedAgioi[i].Onoma}"); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Πρέπει να συμπληρώσετε Όνομα & Ιδιότητα & Ημερομηνία Εορτής υποχρεωτικά");
                    }

                }

             




        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
