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
using System.Text.RegularExpressions;

namespace Web_Origin
{
    public partial class Insert_Agios : Form
    {
        public int emptySpaceCounter = 0;
        public int emptySpaceCounter2 = 0;
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

        public void button3_Click_1(object sender, EventArgs e)
        {
            // Receive form inputs and set to variables
            var name = onoma.Text;

            //string name = N+onoma.Text;
            string  property = idiotita.Text;

            bool photo = false ;
            if(comboBox4.Text == "ΝΑΙ")
            { photo = true; }

            //checked
            bool small =false;
            if (comboBox6.Text == "ΝΑΙ")
            { small = true; }

            bool big = false ;
            if (comboBox5.Text == "ΝΑΙ")
            { big = true; }

            bool orthross = false;
            if (comboBox3.Text == "ΝΑΙ")
            { orthross = true; }

            bool election = false;
            if (comboBox2.Text == "ΝΑΙ")
            { election = true; }
            
            bool theia_leit = false;
            if (comboBox17.Text == "ΝΑΙ")
            { theia_leit = true; }

            string hymn = Ymnografoi.Text;
            if(hymn == "Επιλέξτε") { hymn = ""; }
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;

            bool decision=false;
            if (comboBox16.Text == "ΝΑΙ")
            { decision = true; }
           

            bool approvement=false;
            if (comboBox15.Text == "ΝΑΙ")
            { approvement = true; }
           

            bool img_eksw = false; 
            if (comboBox14.Text == "ΝΑΙ")
            { img_eksw = true; }
           

            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            int pub_date;

            if (hmeromhnia_ekdosis.Text=="")
            { pub_date = 0; }
            else
            { pub_date = Int32.Parse(hmeromhnia_ekdosis.Text); }

            string pub_place = topos_ekdosis.Text;

            bool disk=false;
            if (comboBox13.Text == "ΝΑΙ")
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
            if (metathesi_eortis != "ΜΜ-ΗΗ" && metathesi_eortis!="")
            {
                metathesi_eortis = metathesi_eortis + "-1970";
            }
            else { metathesi_eortis = MetathesiEortis.Text ; }

            var celebration_date = hmeromhnia_eortis.Text;
            if (celebration_date != "ΜΜ-ΗΗ" && celebration_date != "")
            {
                celebration_date = celebration_date + "-1970";
            }



            if (name != "" && property != "" && celebration_date != "" && metathesi_eortis!="" )// +σύναξη προσωρινό
            {
                //Here the insert has to check to the database
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
                connection.Open();


                SqlCommand cmd = new SqlCommand("insert into Agioi(Onoma,Idiotita,Eikona,Date_eortis,Mikros_esperinos,Megalos_esperinos,Orthros,Eklogi,Theia_leitourgeia,Ymnografos,Xairetismoi,Egkomia,Eulogitaria,Eyxes,Mousiko_parartima,Apofasi,Egkrisi,Eikona_ekswfyllou,Plhrhs_titlos,Ekdotis,Topos_ekdosis,Date_ekdosis,CD,Phototypia,Posotita,Metathesi_Eortis,Mnimi_anakomidi_synaksi)" +
                "values ('" + name + "','" + property + "','" + photo + "','" + celebration_date + "','" + small + "','" + big + "','" + orthross + "','" + election + "','" + theia_leit + "','" + hymn + "','" + xairetism + "','" + egkom + "','" + eulog + "','" + wishes + "','" + music + "','" + decision + "','" + approvement + "','" + img_eksw + "','" + title + "','" + publishe + "','" + pub_place + "','" + pub_date + "','" + disk + "','" + fyllada + "','" + quantity + "','" + metathesi_eortis + "','" + synaksi + "')", connection);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (!dataReader.Equals(null))
                {
                    MessageBox.Show("Η καταχώρηση του Αγίου ολοκληρώθηκε με επιτυχία !");
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
                MessageBox.Show("Τα κελιά (ΟΝΟΜΑ, ΙΔΙΟΤΗΤΑ, ΜΝΗΜΗ/ΑΝΑΚΟΜΙΔΗ/ΣΥΝΑΞΗ, ΜΕΤΑΘΕΣΗ ΕΟΡΤΗΣ, ΗΜΕΡΟΜΗΝΙΑ ΕΟΡΤΗΣ)\n είναι υποχρεωτικά για να ολοκληρωθεί η ΕΙΣΑΓΩΓΗ!");
            }
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(idiotita.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                idiotita.Text = string.Empty;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void eulogitiria_ymnografos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(eulogitiria_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                eulogitiria_ymnografos.Text = string.Empty;
            }
        }

        // We need to fix that here :
        private void MetathesiEortis_Enter(object sender, EventArgs e)
        {
            if (MetathesiEortis.Text == "MM-HH")
            {
                MetathesiEortis.Text = "";
                MetathesiEortis.ForeColor = Color.LightGray;
            }

        }

        private void MetathesiEortis_Leave(object sender, EventArgs e)
        {
            if (MetathesiEortis.Text == "")
            {
                MetathesiEortis.Text = "MM-HH";
                MetathesiEortis.ForeColor = Color.DimGray;
            }

        }

        private void onoma_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
            }
        }

        private void mnhmh_anakomidi_sinaxi_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(mnhmh_anakomidi_sinaxi.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                mnhmh_anakomidi_sinaxi.Text = string.Empty;
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

        private void xairetismoi_ymnografos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(xairetismoi_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                xairetismoi_ymnografos.Text = string.Empty;
            }
        }

        private void egkwmia_ymnografos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(egkwmia_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                egkwmia_ymnografos.Text = string.Empty;
            }
        }

        private void eyxes_ymnografos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(eyxes_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                eyxes_ymnografos.Text = string.Empty;
            }
        }

        private void mousiko_parartima_ymnografos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(mousiko_parartima_ymnografos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο  δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                mousiko_parartima_ymnografos.Text = string.Empty;
            }
        }

        private void plhrhs_titlos_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(plhrhs_titlos.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
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

        private void psifiaki_morfi_TextChanged(object sender, EventArgs e)
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

        private void hmeromhnia_ekdosis_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.Match(hmeromhnia_ekdosis.Text, "[^0-9]+").Success))
            {
                MessageBox.Show("Το πεδίο της ποσότητας δέχεται μόνο ψηφία");
                hmeromhnia_ekdosis.Text = string.Empty;
            }
        }

        private void hmeromhnia_eortis_TextChanged(object sender, EventArgs e)
        {
            if (emptySpaceCounter <= 0)
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

    }
}
