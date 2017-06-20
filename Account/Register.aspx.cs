using System;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

public partial class Account_Register : Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["usrdb"].ConnectionString;
    }

    private void InsertUser(string username, string password, string email, string name, string bday, string gender, string city, string street, string number, string post_code, string state, string surname, string phone)
    {
        MySqlConnection conn = new MySqlConnection(GetConnectionString());

        conn.Open();
        string checkIfUsrExist = "SELECT login FROM uzytkownicy WHERE login='" + username + "'";
        MySqlCommand check = new MySqlCommand(checkIfUsrExist, conn);

        string validInfo;
        validInfo = (string)check.ExecuteScalar();

        if (validInfo != null)
        {
            conn.Close();
            Response.Write("Użytkownik już istnieje, wybierz inną nazwę użytkownika.");
        }
        else
        {

            try
            {
                string sql_usr = "INSERT INTO uzytkownicy (id_uzytkownika, id_adres, id_dane, login, haslo, e_mail) VALUES "
                + " (@id_uzytkownika,@id_adres,@id_dane,@login,@haslo,@e_mail)";

                string sql_addr = "INSERT INTO adresy (id_adres, ulica, nr_domu, miasto, kod_pocztowy, wojewodztwo) VALUES "
                            + " (@id_adres,@ulica,@nr_domu,@miasto,@kod_pocztowy,@wojewodztwo)";

                string sql_usrData = "INSERT INTO dane_osobowe (id_dane, imie, nazwisko, plec, data_urodzenia, nr_telefonu) VALUES "
                            + " (@id_dane,@imie,@nazwisko,@plec,@data_urodzenia,@nr_telefonu)";

                string getLastUID = "SELECT MAX(id_uzytkownika) FROM uzytkownicy";
                MySqlCommand cmd = new MySqlCommand(sql_usr, conn);
                MySqlCommand cmd2 = new MySqlCommand(sql_addr, conn);
                MySqlCommand cmd3 = new MySqlCommand(sql_usrData, conn);
                MySqlCommand cmdLastUID = new MySqlCommand(getLastUID, conn);

                int uid = (Int32)cmdLastUID.ExecuteScalar() + 1;
                int dataid = uid;
                int addressid = uid;

                MySqlParameter[] param = new MySqlParameter[6];
                param[0] = new MySqlParameter("@id_uzytkownika", MySqlDbType.Int32, 10);
                param[1] = new MySqlParameter("@id_adres", MySqlDbType.Int32, 10);
                param[2] = new MySqlParameter("@id_dane", MySqlDbType.Int32, 10);
                param[3] = new MySqlParameter("@login", MySqlDbType.VarChar, 50);
                param[4] = new MySqlParameter("@haslo", MySqlDbType.VarChar, 50);
                param[5] = new MySqlParameter("@e_mail", MySqlDbType.VarChar, 50);

                param[0].Value = uid;
                param[1].Value = dataid;
                param[2].Value = addressid;
                param[3].Value = username;
                param[4].Value = password;
                param[5].Value = email;

                MySqlParameter[] param2 = new MySqlParameter[6];
                param2[0] = new MySqlParameter("@id_adres", MySqlDbType.Int32, 10);
                param2[1] = new MySqlParameter("@ulica", MySqlDbType.VarChar, 50);
                param2[2] = new MySqlParameter("@nr_domu", MySqlDbType.VarChar, 50);
                param2[3] = new MySqlParameter("@miasto", MySqlDbType.VarChar, 50);
                param2[4] = new MySqlParameter("@kod_pocztowy", MySqlDbType.VarChar, 50);
                param2[5] = new MySqlParameter("@wojewodztwo", MySqlDbType.VarChar, 50);

                param2[0].Value = addressid;
                param2[1].Value = street;
                param2[2].Value = number;
                param2[3].Value = city;
                param2[4].Value = post_code;
                param2[5].Value = state;

                MySqlParameter[] param3 = new MySqlParameter[6];
                param3[0] = new MySqlParameter("@id_dane", MySqlDbType.Int32, 10);
                param3[1] = new MySqlParameter("@imie", MySqlDbType.VarChar, 50);
                param3[2] = new MySqlParameter("@nazwisko", MySqlDbType.VarChar, 50);
                param3[3] = new MySqlParameter("@plec", MySqlDbType.VarChar, 50);
                param3[4] = new MySqlParameter("@data_urodzenia", MySqlDbType.VarChar, 50);
                param3[5] = new MySqlParameter("@nr_telefonu", MySqlDbType.VarChar, 50);

                param3[0].Value = dataid;
                param3[1].Value = name;
                param3[2].Value = surname;
                param3[3].Value = gender;
                param3[4].Value = bday;
                param3[5].Value = phone;



                for (int i = 0; i < param2.Length; i++)
                {
                    cmd2.Parameters.Add(param2[i]);
                }

                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();

                for (int i = 0; i < param3.Length; i++)
                {
                    cmd3.Parameters.Add(param3[i]);
                }

                cmd3.CommandType = CommandType.Text;
                cmd3.ExecuteNonQuery();

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
                Response.Write("Rejestracja pomyślna.");
            }
        }
        
        
    }

    protected void CreateUser_Click(object sender, EventArgs e)
    {
        InsertUser(UserName.Text,
                    Password.Text,
                    Email.Text,
                    Name.Text,
                    Bday.Text,
                    Gender.SelectedItem.Text,
                    City.Text,
                    Street.Text, 
                    Number.Text, 
                    PostCode.Text, 
                    State.Text, 
                    Surname.Text, 
                    Phone.Text);
    }
}