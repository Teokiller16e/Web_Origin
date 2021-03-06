using System;
using System.Collections.Generic;
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

        public void button3_Click(object sender, EventArgs e)
        {

            // result:
            List<Agios> returnedAgioi = new List<Agios>();

            // Initialize variables 
            string name = onoma.Text;
            string property = idiotita.Text;

            string photo = comboBox11.Text;
            string small = comboBox10.Text;
            string big = comboBox9.Text;
            string orthross = comboBox8.Text;
            string election = comboBox7.Text;
            string theia_leit = comboBox6.Text;

            string hymn = Ymnografoi.Text;
            string xairetism = xairetismoi_ymn_box.Text;
            string egkom = egkomia_ymn.Text;
            string eulog = eulogitaria_ymn.Text;
            string wishes = euxes_ymn_comboBox.Text;
            string music = mousiko_parartima_ymnografos.Text;

            string decision = comboBox5.Text;
            string approvement = comboBox4.Text;
            string img_eksw = comboBox3.Text;
            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            string pub_date = hmeromhnia_ekdosis.Text;
            string pub_place = topos_ekdosis.Text;

            string disk = comboBox2.Text;
            string fyllada = comboBox1.Text;

            int aukson_ar;
            int quantity;
            string metathesi_eortis = MetathesiEortis.Text;
            var celebration_date = hmeromhnia_eortis.Text;
            string synaksi = mnANSYcomboBox.Text;
            int out_if;
            int in_if;

            //New added combobox and labels:
            string liti = litiComboBox.Text;
            string typikon = typikonAkolouthiasComboBox.Text;
            string megalynaria = megalynariaComboBox.Text;
            string synaksarion = synaksarionYmnografos.Text;
            string symplirwsin = symplirwsiAkolouthiasComboBox.Text;
            string ekdotikiParagwgi = ekdotikiParagwgiTextBox.Text;

            // Drop down menu choices & editing :
            if (mnANSYcomboBox.Text == "-")
            {
                synaksi = "";
            }
            if (comboBox11.Text == "-")
            { photo = ""; }
            if (comboBox10.Text == "-")
            { small = ""; }
            if (comboBox9.Text == "-")
            { big = ""; }
            if (comboBox8.Text == "-")
            { orthross = ""; }
            if (comboBox7.Text == "-")
            { election = ""; }
            if (comboBox6.Text == "-")
            { theia_leit = ""; }

            if (hymn == "-")
            { hymn = ""; }
            if (xairetism == "-") 
            { xairetism = ""; }
            if (egkom == "-")
            { egkom = ""; }
            if (eulog == "-")
            { eulog = ""; }
            if (wishes == "-")
            { wishes = ""; }

            if (comboBox5.Text == "-")
            { decision = ""; }
            if (comboBox4.Text == "-")
            { approvement = ""; }
            if (comboBox3.Text == "-")
            { img_eksw = ""; }

            if (comboBox2.Text == "-")
            { disk = ""; }
            if (comboBox1.Text == "-")
            { fyllada = ""; }
            if (IDtextBox.Text == "")
            { aukson_ar = 0; }
            else
            { aukson_ar = Int32.Parse(IDtextBox.Text); }

            if (posotita.Text == "")
            { quantity = 0; }
            else
            { quantity = Int32.Parse(posotita.Text); }

            if (metathesi_eortis == "ΗΗ-ΜΜ" || metathesi_eortis == "")
            {
                metathesi_eortis = "";
            }

            if (celebration_date == "ΗΗ-ΜΜ" || celebration_date=="")
            {
                celebration_date = "";
            }

            if (liti == "-")
            { liti = ""; }
            if (typikon == "-")
            { typikon = ""; }
            if (megalynaria == "-")
            { megalynaria = ""; }
            if (synaksarion == "-")
            { synaksarion = ""; }
            if (symplirwsin == "-")
            { symplirwsin = ""; }
            if (ekdotikiParagwgi == "-")
            { ekdotikiParagwgi = ""; }

            Services svr = new Services();
            List<Agios> agioi = new List<Agios>();
            agioi = svr.getSaints();

                       
                        if (agioi.Count == 0)
                        {
                            MessageBox.Show("Δεν βρέθηκαν αποτελέμσατα που αντιστοιχούν στα στοιχεία.");
                        }
                        else 
                        {
                            for (int i = 0; i < agioi.Count; i++) 
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

                                if (photo != "")
                                {
                                    out_if++;
                                    if (photo == agioi[i].Eikona)
                                    { in_if++; }

                                }

                                if (celebration_date !="") 
                                {
                                    out_if++;
                                    if (celebration_date == agioi[i].Date_Eortis)
                                    { in_if++; }

                                }

                                if (small != "")
                                {
                                    out_if++;
                                    if (small == agioi[i].Mikros_esperinos)
                                    { in_if++; }

                                }

                                if (big != "")
                                {
                                    out_if++;
                                    if (big == agioi[i].Megalos_esperinos)
                                    { in_if++; }
                                }

                                if (orthross != "")
                                {
                                    out_if++;
                                    if (orthross == agioi[i].Orthros)
                                    { in_if++; }
                                }

                                if (election != "")
                                {
                                    out_if++;
                                    if (election == agioi[i].Eklogi)
                                    { in_if++; }
                                }

                                if (theia_leit != "")
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

                                if (decision != "")
                                {
                                    out_if++;
                                    if (decision == agioi[i].Apofasi)
                                    { in_if++; }

                                }

                                if (approvement != "")
                                {
                                    out_if++;
                                    if (approvement == agioi[i].Egkrisi)
                                    { in_if++; }

                                }

                                if (img_eksw != "")
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

                                if (disk != "")
                                {
                                    out_if++;
                                    if (disk == agioi[i].CD)
                                    { in_if++; }

                                }

                                if (fyllada != "")
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

                                if (metathesi_eortis != "")
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

                                if (liti != "")
                                {
                                    out_if++;
                                    if (liti == agioi[i].Liti)
                                    { in_if++; }

                                }

                                if (typikon != "")
                                {
                                    out_if++;
                                    if (typikon == agioi[i].Typikon_akolouthias)
                                    { in_if++; }

                                }

                                if (megalynaria != "")
                                {
                                    out_if++;
                                    if (megalynaria == agioi[i].Megalynaria_ymnografos)
                                    { in_if++; }

                                }

                                if (synaksarion != "")
                                {
                                    out_if++;
                                    if (synaksarion == agioi[i].Synaksarion_ymnografos)
                                    { in_if++; }

                                }


                                if (symplirwsin != "")
                                {
                                    out_if++;
                                    if (symplirwsin == agioi[i].Symplirwsh_akolouthias_ymnografos)
                                    { in_if++; }

                                }

                                if (ekdotikiParagwgi != "")
                                {
                                    out_if++;
                                    if (ekdotikiParagwgi == agioi[i].Ekdotiki_paragwgh)
                                    { in_if++; }

                                }


                                if (IDtextBox.Text != "")
                                {
                                    out_if++;
                                    if ( aukson_ar == agioi[i].ID)
                                    { in_if++; }
                                }

                                if (out_if == in_if && out_if!=0)
                                {
                                    returnedAgioi.Add(agioi[i]);
                                }
                            }
                         
                        }
                    
                   
            //}
            SearchResult formPopup = new SearchResult();
            formPopup.Agioi_Load(returnedAgioi);
            formPopup.Show(this);
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
            /*if(Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)    
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
            }*/
        }

        private void hmeromhnia_ekdosis_TextChanged(object sender, EventArgs e)
        {
            /*if ((Regex.Match(hmeromhnia_ekdosis.Text, "[^0-9-πμχ. ]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                hmeromhnia_ekdosis.Text = string.Empty;
            }*/
        }

        private void idiotita_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
           /* if (Regex.Match(idiotita.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                idiotita.Text = string.Empty;
            }*/
        }

  


        private void mousiko_parartima_ymnografos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
           /* if (Regex.Match(mousiko_parartima_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο  δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                mousiko_parartima_ymnografos.Text = string.Empty;
            }*/
        }

        private void plhrhs_titlos_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            /*if (Regex.Match(plhrhs_titlos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                plhrhs_titlos.Text = string.Empty;
            }*/
        }

        private void ekdotis_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
           /* if (Regex.Match(ekdotis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                ekdotis.Text = string.Empty;
            }*/
        }

        private void topos_ekdosis_TextChanged(object sender, EventArgs e)
        {
            //Allows only greek letters
            /*if (Regex.Match(topos_ekdosis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                topos_ekdosis.Text = string.Empty;
            }*/
        }

        private void MetathesiEortis_Enter(object sender, EventArgs e)
        {
          
        }

        private void MetathesiEortis_Leave(object sender, EventArgs e)
        {
         
        }

        private void hmeromhnia_eortis_TextChanged(object sender, EventArgs e)
        {
            if (emptySpaceCounter <= 0)
            {
                hmeromhnia_eortis.Text = "";
                emptySpaceCounter++;
            }
            if ((Regex.Match(hmeromhnia_eortis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ0-9-.]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία και ελληνικούς χαρακτήρες");
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

            if ((Regex.Match(MetathesiEortis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ0-9-.]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία και ελληνικούς χαρακτήρες");
                MetathesiEortis.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Usemanagement.Administrator == 1)
            {
                AdminForm ad = new AdminForm();
                this.Hide();
                ad.Show();
            }
            else 
            {
                SimpleUserForm smpUsr = new SimpleUserForm();
                this.Hide();
                smpUsr.Show();
            }
        }
    }
}
