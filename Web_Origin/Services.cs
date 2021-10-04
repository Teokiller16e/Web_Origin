using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Web_Origin.Models;

namespace Web_Origin
{
    public  class Services
    {
   
        internal Agios GetSaint(int id)
        {
            Agios saint = new Agios();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Agioi WHERE ID =" + id, connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                if (!dataReader.Equals(null))
                {
                    // loop for retrieving all the possible users from the database
                    while (dataReader.Read())
                    {
                        var idNumber = dataReader.GetInt32(0);
                        string onom = dataReader["Onoma"].ToString();
                        string proper = dataReader["Idiotita"].ToString();
                        string foto = dataReader["Eikona"].ToString();
                        string cel_date = dataReader["Date_eortis"].ToString();
                        string mikros = dataReader["Mikros_esperinos"].ToString();
                        string megas = dataReader["Megalos_esperinos"].ToString();
                        string orthros = dataReader["Orthros"].ToString();
                        string elect = dataReader["Eklogi"].ToString();
                        string theia_leitourg = dataReader["Theia_leitourgeia"].ToString();
                        string ymnos = dataReader["Ymnografos"].ToString();
                        string xairet = dataReader["Xairetismoi"].ToString();
                        string eulogitar = dataReader["Eulogitaria"].ToString();
                        string egkwmi = dataReader["Egkomia"].ToString();
                        string euxs = dataReader["Eyxes"].ToString();
                        string mousik = dataReader["Mousiko_parartima"].ToString();
                        string apofas = dataReader["Apofasi"].ToString();
                        string approve = dataReader["Egkrisi"].ToString();
                        string eiko_eks = dataReader["Eikona_ekswfyllou"].ToString();
                        string titloss = dataReader["Plhrhs_titlos"].ToString();
                        string publisher = dataReader["Ekdotis"].ToString();
                        string publish_place = dataReader["Topos_ekdosis"].ToString();
                        int posot = dataReader.GetInt32(22);
                        string disc = dataReader["CD"].ToString();
                        string phototypia_fyllada = dataReader["Phototypia"].ToString();
                        string publish_date = dataReader["Date_ekdosis"].ToString();
                        string Metathesi_Eortis = dataReader["Metathesi_eortis"].ToString();
                        string synakss = dataReader["Mnimi_anakomidi_synaksi"].ToString();
                        string user_dimi = dataReader["Xristis_dhmiourgias"].ToString();

                        // new fields : 
                        string liti = dataReader["Lith"].ToString();
                        string typikon = dataReader["Typikon_akolouthias"].ToString();
                        string megalynaria = dataReader["Megalynaria_ymnografos"].ToString();
                        string synaksarion = dataReader["Synaksarion_ymnografos"].ToString();
                        string symplirwsi_akolouth = dataReader["Symplirwsi_akolouthias_ymnografos"].ToString();
                        string ekdot_paragwg = dataReader["Ekdotiki_paragwgh"].ToString();

                        saint = new Agios(idNumber, onom, proper, foto, cel_date, mikros, megas, orthros, elect, theia_leitourg, ymnos, xairet, egkwmi, eulogitar,
                                                euxs, mousik, apofas, approve, eiko_eks, titloss, publisher, publish_place, publish_date, disc, phototypia_fyllada, posot,
                                                Metathesi_Eortis, synakss, user_dimi,liti,typikon,megalynaria,synaksarion,symplirwsi_akolouth,ekdot_paragwg);
                    }
                }
            }
            else { MessageBox.Show("Κάτι πήγε στραβά, παρακαλούμε προσπαθήστε ξανά."); }
            return saint;
        }

        internal Models.User GetUser(int id)
        {
            User xristis = new User();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Xristes WHERE Id_Number =" + id, connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                if (!dataReader.Equals(null))
                {
                    // loop for retrieving all the possible users from the database
                    while (dataReader.Read())
                    {
                        var idNumber = dataReader.GetInt32(0);
                        var firstname = dataReader["Firstname"].ToString();
                        var lastname = dataReader["Lastname"].ToString();
                        var username = dataReader["Username"].ToString();
                        var password = dataReader["Password"].ToString();
                        var administrator = dataReader.GetBoolean(5);

                        xristis = new User(idNumber, firstname, lastname, username, password, administrator);  
                    }
                }  
            }
            else { MessageBox.Show("Κάτι πήγε στραβά, παρακαλούμε προσπαθήστε ξανά."); }
            return xristis;
        }
        //Updates for Users and Administrators
        internal Boolean DeleteAgios(int id)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE  FROM Church.dbo.Agioi WHERE ID =" + id, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (!dataReader.Equals(null))
            { return true; }
            return false;
        }
        internal Boolean DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE  FROM Church.dbo.Xristes WHERE Id_Number ="+id, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (!dataReader.Equals(null))
            { return true; }
             return false;
        }
        internal Boolean InsertUser(string firstName, string lastName, string userName , string pass, bool adminRights)
        {
            bool flag = false;

            //Here the insert has to check to the database
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");
            connection.Open();


                SqlCommand cmd = new SqlCommand("insert into Church.dbo.Xristes(Firstname,Lastname,Username,Password,Administrator)" +
                "values ('" + firstName + "','" + lastName + "','" + userName + "','" + pass + "','" + adminRights + "')", connection);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (!dataReader.Equals(null))
                {flag = true;}
                
                
            
            return flag;
        }

        internal Boolean UpdateUser(int id,string firstName, string lastName, string userName, string pass, bool adminRights)
        {
            bool flag = false;

            //Here the insert has to check to the database
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");
            connection.Open();


            SqlCommand cmd = new SqlCommand("UPDATE  Church.dbo.Xristes  SET Firstname='" + firstName + "',Lastname='" + lastName + "',Username='" + userName + "'" +
                ",Password='" + pass + "',Administrator= '" + adminRights + "' WHERE Id_Number='" + id + "'", connection);


            SqlDataReader dataReader = cmd.ExecuteReader();

            if (!dataReader.Equals(null))
            { flag = true; }



            return flag;
        }

        internal Boolean UpdateAgios(int idNumber, string onom, string proper, string foto, string cel_date, string mikros, string megas, string orthros, string elect,
            string theia_leitourg, string ymnos, string xairet, string egkwmi, string eulogitar,string euxes, string mousik, string apofas, string approve, string eiko_eks,
            string titloss, string publisher, string publish_date, string publish_place, string disc, string phototypia_fyllada,int posot,string Metathesi_Eortis, string synakss
            ,string xristis_dimiourgias,string Liti, string Typikon_akolouthias, string Megalynaria_ymnografos, string Synaksarion_ymnografos,
            string Symplirwsh_akolouthias_ymnografos, string Ekdotiki_paragwgh)
        {
            bool flag = false;

            //Here the insert has to check to the database
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");
            connection.Open();

            SqlCommand cmd = new SqlCommand("UPDATE  Church.dbo.Agioi  SET Onoma='" + onom + "',Idiotita='" + proper + "',Eikona='" + foto + "'" +
               ",Date_eortis='" + cel_date + "',Mikros_esperinos= '" + mikros + "',Megalos_esperinos='" + megas + "',Orthros='" + orthros + "'" +
               ",Eklogi='" + elect + "',Theia_leitourgeia= '" + theia_leitourg + "',Ymnografos='" + ymnos + "',Xairetismoi='" + xairet + "'" +
               ",Egkomia='" + egkwmi + "',Eulogitaria= '" + eulogitar + "',Eyxes='" + euxes + "',Mousiko_parartima='" + mousik + "'" +
               ",Apofasi='" + apofas + "',Egkrisi= '" + approve + "',Eikona_ekswfyllou='" + eiko_eks + "',Plhrhs_titlos='" + titloss + "'" +
               ",Ekdotis='" + publisher + "',Topos_ekdosis= '" + publish_place + "',Posotita='" + posot + "',CD='" + disc + "'" +
               ",Phototypia='" + phototypia_fyllada + "',Date_ekdosis= '" + publish_date + "',Metathesi_eortis='" + Metathesi_Eortis + "',Mnimi_anakomidi_synaksi='" 
               + synakss + "',Xristis_dhmiourgias= '" + xristis_dimiourgias + "',Lith= '" + Liti + "',Typikon_akolouthias= '" + Typikon_akolouthias +
               "',Megalynaria_ymnografos= '" + Megalynaria_ymnografos + "',Synaksarion_ymnografos= '" + Synaksarion_ymnografos +
               "',Symplirwsi_akolouthias_ymnografos= '" + Symplirwsh_akolouthias_ymnografos + "',Ekdotiki_paragwgh= '" + Ekdotiki_paragwgh + "' WHERE ID='" + idNumber + "'", connection);

           
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (!dataReader.Equals(null))
            { flag = true; }
            return flag;
        }

        internal List<User> getUsers()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Xristes", connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                List<User> xristes = new List<User>();


                if (!dataReader.Equals(null))
                {
                    // loop for retrieving all the possible users from the database
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var firstname = dataReader["Firstname"].ToString();
                        var lastname = dataReader["Lastname"].ToString();
                        var username = dataReader["Username"].ToString();
                        var password = dataReader["Password"].ToString();
                        var administrator = dataReader.GetBoolean(5);

                        User user = new User(id, firstname, lastname, username, password, administrator);

                        xristes.Add(user);
                    }
                }
                return xristes;
            }
            else { return null; }
        }

        internal List<Agios> getSaints()
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Persist Security Info=True;Trusted_Connection=False;User ID=administrator;Password=administrator;Integrated Security=False");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Agioi", connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                List<Agios> agioi = new List<Agios>();
                Agios saint = new Agios();


                if (!dataReader.Equals(null))
                {
                    // loop for retrieving all the possible users from the database
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        string onom = dataReader["Onoma"].ToString();
                        string proper = dataReader["Idiotita"].ToString();
                        string foto = dataReader["Eikona"].ToString();
                        string cel_date = dataReader["Date_eortis"].ToString();
                        string mikros = dataReader["Mikros_esperinos"].ToString();
                        string megas = dataReader["Megalos_esperinos"].ToString();
                        string orthros = dataReader["Orthros"].ToString();
                        string elect = dataReader["Eklogi"].ToString();
                        string theia_leitourg = dataReader["Theia_leitourgeia"].ToString();
                        string ymnos = dataReader["Ymnografos"].ToString();
                        string xairet = dataReader["Xairetismoi"].ToString();
                        string eulogitar = dataReader["Eulogitaria"].ToString();
                        string egkwmi = dataReader["Egkomia"].ToString();
                        string euxs = dataReader["Eyxes"].ToString();
                        string mousik = dataReader["Mousiko_parartima"].ToString();
                        string apofas = dataReader["Apofasi"].ToString();
                        string approve = dataReader["Egkrisi"].ToString();
                        string eiko_eks = dataReader["Eikona_ekswfyllou"].ToString();
                        string titloss = dataReader["Plhrhs_titlos"].ToString();
                        string publisher = dataReader["Ekdotis"].ToString();
                        string publish_place = dataReader["Topos_ekdosis"].ToString();
                        int posot = dataReader.GetInt32(22);
                        string disc = dataReader["CD"].ToString();
                        string phototypia_fyllada = dataReader["Phototypia"].ToString();
                        string publish_date = dataReader["Date_ekdosis"].ToString();
                        string Metathesi_Eortis = dataReader["Metathesi_eortis"].ToString();
                        string synakss = dataReader["Mnimi_anakomidi_synaksi"].ToString();
                        string user_dimi = dataReader["Xristis_dhmiourgias"].ToString();

                        // new fields : 
                        string liti = dataReader["Lith"].ToString();
                        string typikon = dataReader["Typikon_akolouthias"].ToString();
                        string megalynaria = dataReader["Megalynaria_ymnografos"].ToString();
                        string synaksarion = dataReader["Synaksarion_ymnografos"].ToString();
                        string symplirwsi_akolouth = dataReader["Symplirwsi_akolouthias_ymnografos"].ToString();
                        string ekdot_paragwg = dataReader["Ekdotiki_paragwgh"].ToString();

                        saint = new Agios(id, onom, proper, foto, cel_date, mikros, megas, orthros, elect, theia_leitourg, ymnos, xairet, egkwmi, eulogitar,
                                                euxs, mousik, apofas, approve, eiko_eks, titloss, publisher, publish_place, publish_date, disc, phototypia_fyllada, posot,
                                                Metathesi_Eortis, synakss, user_dimi, liti, typikon, megalynaria, synaksarion, symplirwsi_akolouth, ekdot_paragwg);


                        agioi.Add(saint);
                    }
                }
                return agioi;
            }
            else { return null; }
        }
    }
}
