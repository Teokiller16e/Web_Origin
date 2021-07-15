namespace Web_Origin.Models
{
    class Agios
    {
        //Properties :
        public int? ID { get; set; }
        public string Onoma { get; set; }
        public string Idiotita { get; set; }
        public string Eikona { get; set; }
        public string Date_Eortis { get; set; }
        public string Mikros_esperinos { get; set; }
        public string Megalos_esperinos { get; set; }
        public string Orthros { get; set; }
        public string Eklogi { get; set; }
        public string Theia_leitourgeia { get; set; }
        public string Ymnografos { get; set; }
        public string Xairetismoi { get; set; }
        public string Egkomia { get; set; }
        public string Eulogitaria { get; set; }
        public string Eyxes { get; set; }
        public string Mousiko_parartima { get; set; }
        public string Apofasi { get; set; }
        public string Egkrisi { get; set; }
        public string Eikona_ekswfyllou { get; set; }
        public string Plhrhs_titlos { get; set; }
        public string Ekdotis { get; set; }
        public string Topos_ekdosis { get; set; }
        public string Date_ekdosis { get; set; }
        public string CD { get; set; }
        public string Phototypia { get; set; }
        public int Posotita { get; set; }
        public string Metathesi_eortis { get; set; }
        public string Mnimi_anakomidi_synaksi { get; set; }
        public string Xristis_dhmiourgias { get; set; }

        // Default
        public Agios() { }

        // Constructor:
        public Agios(int ID, string Onoma, string Idiotita, string Eikona, string Date_Eortis, string Mikros_esperinos, string Megalos_esperinos, string Orthros, string Eklogi,
            string Theia_leitourgeia,string Ymnografos, string Xairetismoi, string Egkomia,string Eulogitaria, string Eyxes, string Mousiko_parartima, string Apofasi, string Egkrisi,
            string Eikona_ekswfyllou, string Plhrhs_titlos, string Ekdotis,string Topos_ekdosis, string Date_ekdosis, string CD, string Phototypia, int Posotita,string Metathesi_eortis,
            string Mnimi_anakomidi_synaksi,string Xristis_dhmiourgias)
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
            this.Metathesi_eortis = Metathesi_eortis;
            this.Mnimi_anakomidi_synaksi = Mnimi_anakomidi_synaksi;
            this.Xristis_dhmiourgias = Xristis_dhmiourgias;
        }


    }
}
