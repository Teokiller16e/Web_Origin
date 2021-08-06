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
            // Initialize variables 
            var name = onoma.Text;
            string  property = idiotita.Text;
            string photo = comboBox4.Text;
            string small = comboBox6.Text;
            string big = comboBox5.Text;
            string orthross = comboBox3.Text;
            string election = comboBox2.Text;
            string theia_leit = comboBox17.Text;
            string hymn = Ymnografoi.Text;
            string xairetism = xairetismoi_ymn_box.Text;
            string egkom = egkomia_ymn.Text;
            string eulog = eulogitaria_ymn.Text;
            string wishes = euxes_ymn_comboBox.Text;
            string music = mousiko_parartima_ymnografos.Text;
            string decision = comboBox16.Text;
            string approvement = comboBox15.Text;
            string img_eksw = comboBox14.Text;
            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            string pub_date = hmeromhnia_ekdosis.Text;
            string pub_place = topos_ekdosis.Text;
            string disk = comboBox13.Text;
            string fyllada = comboBox12.Text;
            int quantity;
            string synaksi = mnANSYcomboBox.Text;
            string metathesi_eortis = MetathesiEortis.Text;
            string celebration_date = hmeromhnia_eortis.Text;
            string xristis_dimiourgias="rararararara";

            if (mnANSYcomboBox.Text == "-")
            {
                synaksi = "";
            }

            if (comboBox4.Text == "-")
            { photo = ""; }

            if (comboBox6.Text == "-")
            { small = ""; }

            if (comboBox5.Text == "-")
            { big = ""; }

            if (comboBox3.Text == "-")
            { orthross = ""; }

            if (comboBox2.Text == "-")
            { election = ""; }

            if (comboBox17.Text == "-")
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

            if (comboBox16.Text == "-")
            { decision = ""; }

            if (comboBox15.Text == "-")
            { approvement = ""; }

            if (comboBox14.Text == "-")
            { img_eksw = ""; }
            
            if (comboBox13.Text == "-")
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

            if (name != "" && property != "" && celebration_date != ""  )// +σύναξη προσωρινό
            {
                //Here the insert has to check to the database
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
                connection.Open();


                SqlCommand cmd = new SqlCommand("insert into Church.dbo.Agioi(Onoma,Idiotita,Eikona,Date_eortis,Mikros_esperinos,Megalos_esperinos,Orthros,Eklogi,Theia_leitourgeia," +
                    "Ymnografos,Xairetismoi,Egkomia,Eulogitaria,Eyxes,Mousiko_parartima,Apofasi,Egkrisi,Eikona_ekswfyllou,Plhrhs_titlos,Ekdotis,Topos_ekdosis,Date_ekdosis," +
                    "CD,Phototypia,Posotita,Metathesi_eortis,Mnimi_anakomidi_synaksi,Xristis_dhmiourgias)" +
                "values ('" + name + "','" + property + "','" + photo + "','" + celebration_date + "','" + small + "','" + big + "','" + orthross + "','" + election + "','" + theia_leit + "','" + hymn + "','" + xairetism + "','" + egkom + "','" + eulog + "','" + wishes + "','" + music + "','" + decision + "','" + approvement + "','" + img_eksw + "','" + title + "','" + publishe + "','" + pub_place + "','" + pub_date + "','" + disk + "','" + fyllada + "','" + quantity + "','" + metathesi_eortis + "','" + synaksi + "','" + xristis_dimiourgias + "')", connection);

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
                    MessageBox.Show("Υπήρξε κάποιο σφάλμα στην προσθήκη Αγίου, παρακαλούμε προσπαθήστε ξανά.");
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

      

        // We need to fix that here :
        private void MetathesiEortis_Enter(object sender, EventArgs e)
        {
            /*if (MetathesiEortis.Text == "HH-MM")
            {
                MetathesiEortis.Text = "";
                MetathesiEortis.ForeColor = Color.LightGray;
            }*/

        }

        private void MetathesiEortis_Leave(object sender, EventArgs e)
        {
           /* if (MetathesiEortis.Text == "")
            {
                MetathesiEortis.Text = "HH-MM";
                MetathesiEortis.ForeColor = Color.DimGray;
            }*/

        }

        private void onoma_TextChanged(object sender, EventArgs e)
        {
            if (Regex.Match(onoma.Text, "[^ έύίόάήώςερτυθιοπλκξηγφδσαζχψωβνμςΈΎΊΌΆΉΏΕΡΤΥΘΙΟΠΛΚΞΗΓΦΔΣΑΖΧΨΩΒΝΜ]+").Success)
            {
                MessageBox.Show("Το πεδίο του ονόματος δέχεται μόνο ελληνικούς χαρακτήρες/γραμματοσειρά");
                onoma.Text = string.Empty;
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
            if ((Regex.Match(hmeromhnia_ekdosis.Text, "[^0-9-πμχ. ]+").Success))
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
