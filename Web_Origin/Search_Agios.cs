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
            string name = onoma.Text;
            string property = idiotita.Text;
            bool photo = true;// eikones.Text;
            var celebration_date = hmeromhnia_eortis.Text; // only var
            bool small = true;// mikros_esperinos.Text;
            bool big = true;// megas_esperinos.Text;
            bool orthross = true; //orthros.Text;
            bool election = true;// eklogi.Text;
            bool theia_leit = true;// theia_leitourgeia.Text;
            string hymn = iera_paraklisi_ymnografos.Text;
            string xairetism = xairetismoi_ymnografos.Text;
            string egkom = egkwmia_ymnografos.Text;
            string eulog = eulogitiria_ymnografos.Text;
            string wishes = eyxes_ymnografos.Text;
            string music = mousiko_parartima_ymnografos.Text;
            bool decision = true; // apofaseis_apokatataksews.Text;
            bool approvement = true;// egkrisi.Text;
            bool img_eksw = true; // photo_ekswfyllou.Text;
            string title = plhrhs_titlos.Text;
            string publishe = ekdotis.Text;
            int pub_date = 22;// hmeromhnia_ekdosis.Text;
            string pub_place = topos_ekdosis.Text;
            bool disk = true; // digital_diskos.Text;
            string fyllada = fyllada_fwtotypia.Text;
            int quantity = 22;// posotita.Text;
            string synaksi = null;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Ekklisia;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                //SqlCommand command = new SqlCommand("DELETE  FROM Ekklisia.dbo.Agioi WHERE ID= 12", connection);
                //string query = "SELECT * FROM Ekklisia.dbo.Agioi WHERE Onoma='" + name+ "'"; 
                string query = "SELECT * FROM Ekklisia.dbo.Agioi WHERE Onoma='" + name + "'OR Idiotita='" + property + "' OR Eikona='" + photo + "'OR Date_eortis='" + celebration_date + "' OR Mikros_esperinos='"
                    + small + "'OR Megalos_esperinos='" + big + "' OR Orthros='" + orthross + "'OR Eklogi='" + election + "' OR Theia_leitourgeia='" + theia_leit + "'OR Ymnografos='"
                    + hymn + "' OR Xairetismoi='" + xairetism + "'OR Egkomia='" + egkom + "' OR Eulogitaria='" + eulog + "'OR Eyxes='" + wishes + "' OR Mousiko_parartima='"
                    + music + "'OR Apofasi='" + decision + "' OR Egkrisi='" + approvement + "' OR Eikona_ekswfyllou='" + img_eksw + "'OR Plhrhs_titlos='" + title + "' OR Ekdotis='"
                    + publishe + "'OR Topos_ekdosis='" + pub_place + "' OR Date_ekdosis='" + pub_date +  "'OR CD='" + disk + "' OR Phototypia='" + fyllada + "' OR Posotita='" 
                    + quantity + "'OR Mnimi_anakomidi_synaksi='"+ synaksi+ "'";

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
                            Boolean fyllad = dataReader.GetBoolean(24);
                            int posot = dataReader.GetInt32(25);
                            var synakss = dataReader["Mnimi_anakomidi_synaksi"].ToString();
                           

                            //Models.User user = new Models.User(id, firstname, lastname, username, password, administrator);
                            Agios saint = new Agios(id,onom,proper,foto, cel_date,mikros,megas,orthros,elect,theia_leitourg,ymnos,xairet,egkwmi,eulogitar,euxs,mousik,apofas,approve,
                                eiko_eks,titloss,publisher,publish_place,publish_date,disc,fyllad,posot,synakss);

                            agioi.Add(saint);
                        }

                        MessageBox.Show("Agios searched");
                }
                else
                {
                    MessageBox.Show("Agios not searched");
                }

            }

           
        }
    }
}
