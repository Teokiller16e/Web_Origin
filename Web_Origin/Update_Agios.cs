using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            //Load previous data :
            onoma.Text = saint.Onoma;
            idiotita.Text = saint.Idiotita;
            comboBox10.Text = saint.Eikona;
            hmeromhnia_eortis.Text = saint.Date_Eortis;


            comboBox9.Text = saint.Mikros_esperinos;
            comboBox8.Text = saint.Megalos_esperinos;
            comboBox7.Text = saint.Orthros;
            comboBox6.Text = saint.Eklogi;
            comboBox5.Text = saint.Theia_leitourgeia;

            Ymnografoi.Text = saint.Ymnografos;
            xairetismoi_ymn_box.Text = saint.Xairetismoi;
            egkomia_ymn.Text = saint.Egkomia;
            eulogitaria_ymn.Text = saint.Eulogitaria;
            euxes_ymn_comboBox.Text = saint.Eyxes;
            mousiko_parartima_ymnografos.Text = saint.Mousiko_parartima;


            comboBox4.Text = saint.Apofasi;
            comboBox3.Text = saint.Egkrisi;
            comboBox1.Text = saint.Eikona_ekswfyllou;


            plhrhs_titlos.Text = saint.Plhrhs_titlos;
            ekdotis.Text = saint.Ekdotis;
            hmeromhnia_ekdosis.Text = saint.Date_ekdosis;
            topos_ekdosis.Text = saint.Topos_ekdosis;


            comboBox11.Text = saint.CD;
            comboBox12.Text = saint.Phototypia;


            posotita.Text = (saint.Posotita).ToString();
            mnANSYcomboBox.Text = saint.Mnimi_anakomidi_synaksi;
            MetathesiEortis.Text = saint.Metathesi_eortis;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                Saints f1 = new Saints();
                this.Hide();
                f1.Show(this);
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Change to service Update
            // Receive form inputs and set to variables
            string name = onoma.Text;
            string property = idiotita.Text;
            string photo= comboBox10.Text;
            string celebration_date = hmeromhnia_eortis.Text;

            string small = comboBox9.Text;
            string big = comboBox8.Text;
            string orthross = comboBox7.Text;
            string election = comboBox6.Text;
            string theia_leit = comboBox5.Text;

            string hymn = Ymnografoi.Text;
            string xairetism = xairetismoi_ymn_box.Text;
            string egkom = egkomia_ymn.Text;
            string eulog = eulogitaria_ymn.Text;
            string wishes = euxes_ymn_comboBox.Text;
            string music = mousiko_parartima_ymnografos.Text;

            string decision = comboBox4.Text;
            string approvement = comboBox3.Text;
            string img_eksw = comboBox1.Text;


            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            string pub_date = hmeromhnia_ekdosis.Text;
            string pub_place = topos_ekdosis.Text;

            string disk = comboBox11.Text;
            string fyllada = comboBox12.Text;

            int quantity;
            string synaksi = mnANSYcomboBox.Text;
            string metathesi_eortis = MetathesiEortis.Text;
            string xristis_dimiourgias = "rararararara";


            if (mnANSYcomboBox.Text == "-")
            {
                synaksi = "";
            }
            if (comboBox10.Text == "-")
            { photo = ""; }

            if (comboBox9.Text == "-")
            { small = ""; }

            if (comboBox8.Text == "-")
            { big = ""; }

            if (comboBox7.Text == "-")
            { orthross = ""; }

            if (comboBox6.Text == "-")
            { election = ""; }

            if (comboBox5.Text == "-")
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

            if (comboBox4.Text == "-")
            { decision = ""; }

            if (comboBox3.Text == "-")
            { approvement = ""; }

            if (comboBox1.Text == "-")
            { img_eksw = ""; }

            if (comboBox11.Text == "-")
            { disk = ""; }

            if (comboBox12.Text == "-")
            { fyllada = ""; }

            if (posotita.Text == "")
            { quantity = 0; }
            else
            { quantity = Int32.Parse(posotita.Text); }

            if (metathesi_eortis == "ΗΗ-ΜΜ" || metathesi_eortis == "")
            {
                metathesi_eortis = "";
            }

            if (celebration_date == "ΗΗ-ΜΜ" || celebration_date == "")
            {
                celebration_date = "";
            }


            if (name != "" && property != "" && celebration_date != "" && metathesi_eortis!="")
            {
                svr = new Services();
                bool flag = svr.UpdateAgios(extID, name, property, photo, celebration_date, small, big, orthross, election, theia_leit, hymn, xairetism, egkom, eulog, wishes, music, decision,
                    approvement, img_eksw, title, publishe, pub_date, pub_place, disk, fyllada, quantity, metathesi_eortis,synaksi,  xristis_dimiourgias);

                if (flag)
                {
                    MessageBox.Show("Τα στοιχεία του Αγίου ανανεώθηκαν  στην βάση.");
                    this.Hide();
                   
                }
                else
                {
                    MessageBox.Show("Υπήρξε κάποιο σφάλμα στην ανανέωση, προσπαθήστε ξανά.");
                }
            }
            else
            {
                MessageBox.Show("Τα κελιά (ΟΝΟΜΑ, ΙΔΙΟΤΗΤΑ, ΜΝΗΜΗ/ΑΝΑΚΟΜΙΔΗ/ΣΥΝΑΞΗ, ΜΕΤΑΘΕΣΗ ΕΟΡΤΗΣ, ΗΜΕΡΟΜΗΝΙΑ ΕΟΡΤΗΣ)\n είναι υποχρεωτικά για να ολοκληρωθεί η ΕΙΣΑΓΩΓΗ!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Saints f1 = new Saints();
                this.Hide();
                f1.Show(this);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void onoma_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
            }
        }

        private void idiotita_TextChanged(object sender, EventArgs e)
        {
             if (Regex.Match(idiotita.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                idiotita.Text = string.Empty;
            }
        }

  

        private void MetathesiEortis_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(MetathesiEortis.Text, "[^0-9-]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                MetathesiEortis.Text = string.Empty;
            }
        }

        private void hmeromhnia_eortis_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(hmeromhnia_eortis.Text, "[^0-9-]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                hmeromhnia_eortis.Text = string.Empty;
            }
        }

        private void plhrhs_titlos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(plhrhs_titlos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                plhrhs_titlos.Text = string.Empty;
            }
        }

        private void ekdotis_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(ekdotis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                ekdotis.Text = string.Empty;
            }
        }

        private void topos_ekdosis_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(topos_ekdosis.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                topos_ekdosis.Text = string.Empty;
            }
        }

        private void hmeromhnia_ekdosis_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(hmeromhnia_ekdosis.Text, "[^0-9-πμχ. ]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                hmeromhnia_ekdosis.Text = string.Empty;
            }
        }

        private void posotita_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(posotita.Text, "[^0-9]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                posotita.Text = string.Empty;
            }
        }

        private void psifiaki_morfi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
