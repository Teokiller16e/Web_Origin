using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Origin.Models
{
    class Agios
    {

        public int? ID { get; set; }
        public string Onoma { get; set; }
        public string Idiotita { get; set; }
        public Boolean Eikona { get; set; }
        public DateTime Date_Eortis { get; set; }
        public Boolean Mikros_esperinos { get; set; }
        public Boolean Megalos_esperinos { get; set; }
        public Boolean Orthros { get; set; }
        public Boolean Eklogi { get; set; }
        public Boolean Theia_leitourgeia { get; set; }
        public string Ymnografos { get; set; }
        public string Xairetismoi { get; set; }
        public string Egkomia { get; set; }
        public string Eulogitaria { get; set; }
        public string Eyxes { get; set; }
        public string Mousiko_parartima { get; set; }
        public Boolean Apofasi { get; set; }
        public Boolean Egkrisi { get; set; }
        public Boolean Eikona_ekswfyllou { get; set; }
        public string Plhrhs_titlos { get; set; }
        public string Ekdotis { get; set; }
        public string Topos_ekdosis { get; set; }
        public int Date_ekdosis { get; set; }
        public Boolean CD { get; set; }
        public Boolean Phototypia { get; set; }
        public int Posotita { get; set; }
        public string Mnimi_anakomidi_synaksi { get; set; }

        // Default
        public Agios() { }

        // Constructor:
        public Agios(int ID, string Onoma, string Idiotita,Boolean Eikona,DateTime Date_Eortis,Boolean Mikros_esperinos,Boolean Megalos_esperinos, Boolean Orthros, Boolean Eklogi,
            Boolean Theia_leitourgeia,string Ymnografos, string Xairetismoi, string Egkomia,string Eulogitaria, string Eyxes, string Mousiko_parartima, Boolean Apofasi, Boolean Egkrisi, 
            Boolean Eikona_ekswfyllou, string Plhrhs_titlos, string Ekdotis,string Topos_ekdosis, int Date_ekdosis,Boolean CD, Boolean Phototypia, int Posotita,
            string Mnimi_anakomidi_synaksi)
        {
            this.ID = ID;
            this.Onoma = Onoma;
            this.Idiotita = Idiotita;
            this.Eikona = Eikona;
            this.Date_Eortis = Date_Eortis;
            this.Mikros_esperinos = Mikros_esperinos;
            this.Megalos_esperinos = Megalos_esperinos;
            this.Orthros = Orthros;
            this.Eklogi = Eklogi;
            this.Theia_leitourgeia = Theia_leitourgeia;
            this.Ymnografos = Ymnografos;
            this.Xairetismoi = Xairetismoi;
            this.Egkomia = Egkomia;
            this.Eulogitaria = Eulogitaria;
            this.Eyxes = Eyxes;
            this.Mousiko_parartima = Mousiko_parartima;
            this.Apofasi = Apofasi;
            this.Egkrisi = Egkrisi;
            this.Eikona_ekswfyllou = Eikona_ekswfyllou;
            this.Plhrhs_titlos = Plhrhs_titlos;
            this.Ekdotis = Ekdotis;
            this.Topos_ekdosis = Topos_ekdosis;
            this.Date_ekdosis = Date_ekdosis;
            this.CD = CD;
            this.Phototypia = Phototypia;
            this.Posotita = Posotita;
            this.Mnimi_anakomidi_synaksi = Mnimi_anakomidi_synaksi;
        }


    }
}
