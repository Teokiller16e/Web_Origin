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
using System.Text.RegularExpressions;

namespace Web_Origin
{
    public partial class Search_Agios : Form
    {
        public int emptySpaceCounter = 0;
        public int emptySpaceCounter2 = 0;
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
        // Initialize variables 
            string name = onoma.Text;
            string property = idiotita.Text;

            Boolean photo=false;
            if (comboBox11.Text == "ΝΑΙ")
            { photo = true; }

            Boolean small =false;
            if (comboBox10.Text == "ΝΑΙ")
            { small = true; }

            Boolean big =false;
            if (comboBox9.Text == "ΝΑΙ")
            { big = true; }

            Boolean orthross =false;
            if (comboBox8.Text == "ΝΑΙ")
            { orthross = true; }


            Boolean election =false;
            if (comboBox7.Text == "ΝΑΙ")
            { election = true; }


            Boolean theia_leit =false;
            if (comboBox6.Text == "ΝΑΙ")
            { theia_leit = true; }


            string hymn = iera_paraklisi_ymnografos.Text;
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;

            Boolean decision =false;
            if (comboBox5.Text == "ΝΑΙ")
            { decision = true; }

            Boolean approvement =false;
            if (comboBox4.Text == "ΝΑΙ")
            { approvement = true; }


            Boolean img_eksw = false;
            if (comboBox3.Text == "ΝΑΙ")
            { img_eksw = true; }


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


            Boolean fyllada =false;
            if (comboBox1.Text == "ΝΑΙ")
            { fyllada = true; }
            

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

            string metathesi_eortis=MetathesiEortis.Text;
            


            var celebration_date = hmeromhnia_eortis.Text;
            if (celebration_date != "ΜΜ-ΗΗ" && celebration_date!="")
            {
                celebration_date = celebration_date + "-1970";
            }

            string synaksi = "";

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
                {
                    
                    connection.Open();


                    string query = "SELECT * FROM Church.dbo.Agioi";
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
                            string Metathesi_Eortis = dataReader["Metathesi_Eortis"].ToString();
                            var synakss = dataReader["Mnimi_anakomidi_synaksi"].ToString();


                            Agios saint = new Agios(id, onom, proper, foto, cel_date, mikros, megas, orthros, elect, theia_leitourg, ymnos, xairet, egkwmi, eulogitar, euxs, mousik,
                                apofas, approve,eiko_eks, titloss, publisher, publish_place, publish_date, disc, fyllad, posot, Metathesi_Eortis, synakss);

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
                        //Initialize counters
                            int out_if;
                            int in_if;

                            for (int i = 0; i < agioi.Count; i++) // 
                            {
                                out_if = 0;
                                in_if = 0;

                                if (name != "")
                                {
                                    out_if++;
                                    if (name == agioi[i].Onoma)
                                    {in_if++;}
                                }

                                if (property != "")
                                {
                                    out_if++;
                                    if (property == agioi[i].Idiotita)
                                    { in_if++; }

                                }


                                if (comboBox11.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (photo == agioi[i].Eikona)
                                    { in_if++; }

                                }

                                if (celebration_date !="" && celebration_date !="ΜΜ-ΗΗ")
                                {
                                    out_if++;
                                    DateTime cel_date = Convert.ToDateTime(celebration_date);
                                    if (cel_date == agioi[i].Date_Eortis)
                                    { in_if++; }

                                }

                                if (comboBox10.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (small == agioi[i].Mikros_esperinos)
                                    { in_if++; }

                                }

                                if (comboBox9.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (big == agioi[i].Megalos_esperinos)
                                    { in_if++; }

                                }

                                if (comboBox8.Text != "Επιλέξτε")
                                {

                                    out_if++;
                                    if (orthross == agioi[i].Orthros)
                                    { in_if++; }

                                }

                                if (comboBox7.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (election == agioi[i].Eklogi)
                                    { in_if++; }

                                }

                                if (comboBox6.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (theia_leit == agioi[i].Theia_leitourgeia)
                                    { in_if++; }

                                }

                                if (hymn != "")
                                {
                                    out_if++;
                                    if (hymn == agioi[i].Ymnografos)
                                    { in_if++; }

                                }

                                if (xairetism != "")
                                {
                                    out_if++;
                                    if (xairetism == agioi[i].Xairetismoi)
                                    { in_if++; }

                                }

                                if (egkom != "")
                                {
                                    out_if++;
                                    if (egkom == agioi[i].Egkomia)
                                    { in_if++; }

                                }

                                if (eulog != "")
                                {
                                    out_if++;
                                    if (eulog  == agioi[i].Eulogitaria)
                                    { in_if++; }

                                }

                                if (wishes != "")
                                {
                                    out_if++;
                                    if (wishes == agioi[i].Eyxes)
                                    { in_if++; }

                                }

                                if (music != "")
                                {
                                    out_if++;
                                    if (music == agioi[i].Mousiko_parartima)
                                    { in_if++; }

                                }

                                if (comboBox5.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (decision == agioi[i].Apofasi)
                                    { in_if++; }

                                }

                                if (comboBox4.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (approvement == agioi[i].Egkrisi)
                                    { in_if++; }

                                }

                                if (comboBox3.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (img_eksw == agioi[i].Eikona_ekswfyllou)
                                    { in_if++; }

                                }

                                if (title != "")
                                {
                                    out_if++;
                                    if (title == agioi[i].Plhrhs_titlos)
                                    { in_if++; }

                                }

                                if (publishe != "")
                                {
                                    out_if++;
                                    if (publishe == agioi[i].Ekdotis)
                                    { in_if++; }

                                }

                                if (hmeromhnia_ekdosis.Text != "")
                                {
                                    out_if++;
                                    if (pub_date == agioi[i].Date_ekdosis)
                                    { in_if++; }

                                }

                                if (pub_place != "")
                                {
                                    out_if++;
                                    if (pub_place == agioi[i].Topos_ekdosis)
                                    { in_if++; }

                                }

                                if (comboBox2.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (disk == agioi[i].CD)
                                    { in_if++; }

                                }

                                if (comboBox1.Text != "Επιλέξτε")
                                {
                                    out_if++;
                                    if (fyllada == agioi[i].Phototypia)
                                    { in_if++; }

                                }

                                if (posotita.Text != "")
                                {
                                    out_if++;
                                    if (quantity == agioi[i].Posotita)
                                    { in_if++; }

                                }

                                if (metathesi_eortis != "" && metathesi_eortis != "ΜΜ-ΗΗ")
                                {
                                    out_if++;
                                    if (metathesi_eortis == agioi[i].Metathesi_eortis)
                                    {in_if++;}
                                }

                                if (synaksi != "")
                                {
                                    out_if++;
                                    if (synaksi == agioi[i].Mnimi_anakomidi_synaksi)
                                    { in_if++; }

                                }

                                if (IDtextBox.Text != "")
                                {
                                    out_if++;
                                    if ( aukson_ar == agioi[i].ID)
                                    { in_if++; }

                                }
                            // leipei h metathesi eortis
                                if (out_if == in_if)
                                {
                                    returnedAgioi.Add(agioi[i]);
                                }
                            }

                            // Just testing for loop to print all the outcome names:
                            for (int i = 0; i < returnedAgioi.Count; i++)
                            { Console.WriteLine(returnedAgioi[i].Onoma); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Πρέπει να συμπληρώσετε Όνομα & Ιδιότητα & Ημερομηνία Εορτής υποχρεωτικά");
                    }


                SearchResult formPopup = new SearchResult();
                formPopup.Show(this);
            }

             




        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void posotita_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(posotita.Text, "[^0-9]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                posotita.Text = string.Empty;
            }
        }

        private void onoma_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if(Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)    
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
            }
        }

        private void hmeromhnia_ekdosis_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(hmeromhnia_ekdosis.Text, "[^0-9]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                hmeromhnia_ekdosis.Text = string.Empty;
            }
        }

        private void idiotita_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(idiotita.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                idiotita.Text = string.Empty;
            }
        }

        private void mnhmh_anakomidi_sinaxi_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(mnhmh_anakomidi_sinaxi.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                mnhmh_anakomidi_sinaxi.Text = string.Empty;
            }
        }

        private void iera_paraklisi_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(iera_paraklisi_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                iera_paraklisi_ymnografos.Text = string.Empty;
            }
        }

        private void xairetismoi_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(xairetismoi_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                xairetismoi_ymnografos.Text = string.Empty;
            }
        }

        private void egkwmia_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(egkwmia_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                egkwmia_ymnografos.Text = string.Empty;
            }
        }

        private void eulogitiria_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(eulogitiria_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                eulogitiria_ymnografos.Text = string.Empty;
            }
        }

        private void eyxes_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(eyxes_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                eyxes_ymnografos.Text = string.Empty;
            }
        }

        private void mousiko_parartima_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(mousiko_parartima_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο  δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                mousiko_parartima_ymnografos.Text = string.Empty;
            }
        }

        private void plhrhs_titlos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(plhrhs_titlos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                plhrhs_titlos.Text = string.Empty;
            }
        }

        private void ekdotis_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(ekdotis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                ekdotis.Text = string.Empty;
            }
        }

        private void topos_ekdosis_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            if (Regex.Match(topos_ekdosis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                topos_ekdosis.Text = string.Empty;
            }
        }

        private void MetathesiEortis_Enter(object sender, EventArgs e)
        {
            /*
            if (MetathesiEortis.Text == "MM-HH") {
                MetathesiEortis.Text = "";
                MetathesiEortis.ForeColor = Color.LightGray;
            }
            */
        }

        private void MetathesiEortis_Leave(object sender, EventArgs e)
        {
            /*
            if (MetathesiEortis.Text==""){
                MetathesiEortis.Text = "MM-HH";
                MetathesiEortis.ForeColor = Color.DimGray;
            }
            */
        }

        private void hmeromhnia_eortis_TextChanged(object sender, EventArgs e)
        {
            if(emptySpaceCounter<=0)
            {
                hmeromhnia_eortis.Text = "";
                emptySpaceCounter++;
            }
            if ((Regex.Match(hmeromhnia_eortis.Text, "[^0-9-]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                hmeromhnia_eortis.Text = string.Empty;
            }
        }

        private void MetathesiEortis_TextChanged(object sender, EventArgs e)
        {
            if (emptySpaceCounter2 <= 0) 
            {
                MetathesiEortis.Text = "";
                emptySpaceCounter2++;
            }

            if ((Regex.Match(MetathesiEortis.Text, "[^0-9-]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                MetathesiEortis.Text = string.Empty;
            }
        }
    }
}
