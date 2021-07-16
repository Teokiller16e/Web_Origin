using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Web_Origin.Models;

namespace Web_Origin
{
    public partial class SearchResult : Form
    {
        public int selectedIdNumber { get; set; }
        List<Agios> diathesimoiAgioi { get; set; }
        Services ss { get; set; }
        public SearchResult()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert_Agios mainMenu = new Insert_Agios();
            mainMenu.Show();
        }

        internal void Agioi_Load(List<Agios> agioi)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            diathesimoiAgioi = new List<Agios>();
            diathesimoiAgioi = agioi;

            listView1.Items.Clear();

            foreach (var agios in agioi)
            {
                var row = new string[] { (agios.ID).ToString(), (agios.Onoma).ToString() , (agios.Idiotita).ToString(),agios.Eikona.ToString(),agios.Date_Eortis.ToString(),
                agios.Mikros_esperinos.ToString(),agios.Megalos_esperinos.ToString(),agios.Orthros.ToString(),agios.Eklogi.ToString(),agios.Theia_leitourgeia.ToString(),
                agios.Ymnografos,agios.Xairetismoi,agios.Egkomia,agios.Eulogitaria,agios.Eyxes,agios.Mousiko_parartima,agios.Apofasi.ToString(),agios.Egkrisi.ToString(),
                agios.Eikona_ekswfyllou.ToString(),agios.Plhrhs_titlos,agios.Ekdotis,agios.Topos_ekdosis,agios.Date_ekdosis.ToString(),agios.CD.ToString(),
                agios.Phototypia.ToString(), agios.Posotita.ToString(),agios.Metathesi_eortis,agios.Mnimi_anakomidi_synaksi};

                var lvi = new ListViewItem(row);
                lvi.Tag = agios;
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
             selectedIdNumber = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ss = new Services();
            if (selectedIdNumber != 0)
            {
                if (ss.DeleteAgios(selectedIdNumber) == true)
                {
                    MessageBox.Show("Η διαγραφή Άγιου ολοκληρώθηκε με επιτυχία");
                    SearchResult f1 = new SearchResult();
                    this.Hide();
                    f1.Show();
                }
                else { MessageBox.Show("Υπήρξε σφάλμα, παρακαλούμε προσπαθήστε ξανά"); }
            }
            else
            {
                MessageBox.Show("Δεν έχετε επιλέξει κανέναν από τους παραπάνω Αγίους.");
            }
        }
    }

}
