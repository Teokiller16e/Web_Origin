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
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Agioi WHERE Id_Number =" + id, connection);
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

                         saint = new Agios(idNumber, onom, proper, foto, cel_date, mikros, megas, orthros, elect, theia_leitourg, ymnos, xairet, egkwmi, eulogitar,
                                                euxs, mousik, apofas, approve, eiko_eks, titloss, publisher, publish_place, publish_date, disc, phototypia_fyllada, posot,
                                                Metathesi_Eortis, synakss, user_dimi);
                    }
                }
            }
            else { MessageBox.Show("Κάτι πήγε στραβά, παρακαλούμε προσπαθήστε ξανά."); }
            return saint;
        }

        internal Models.User GetUser(int id)
        {
            User xristis = new User();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");

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
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE  FROM Church.dbo.Agioi WHERE ID =" + id, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (!dataReader.Equals(null))
            { return true; }
            return false;
        }
        internal Boolean DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
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
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
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
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");
            connection.Open();


            SqlCommand cmd = new SqlCommand("UPDATE  Church.dbo.Xristes  SET Firstname='" + firstName + "',Lastname='" + lastName + "',Username='" + userName + "'" +
                ",Password='" + pass + "',Administrator= '" + adminRights + "' WHERE Id_Number='" + id + "'", connection);


            SqlDataReader dataReader = cmd.ExecuteReader();

            if (!dataReader.Equals(null))
            { flag = true; }



            return flag;
        }

        internal List<User> getUsers()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");

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

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1MMBGHG;Initial Catalog=Church;Integrated Security=True");

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Church.dbo.Agioi", connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                List<Agios> agioi = new List<Agios>();


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

                        Agios saint = new Agios(id, onom, proper, foto, cel_date, mikros, megas, orthros, elect, theia_leitourg, ymnos, xairet, egkwmi, eulogitar,
                                                euxs, mousik, apofas, approve, eiko_eks, titloss, publisher, publish_place, publish_date, disc, phototypia_fyllada, posot,
                                                Metathesi_Eortis, synakss, user_dimi);
                        agioi.Add(saint);
                    }
                }
                return agioi;
            }
            else { return null; }
        }
    }
}
