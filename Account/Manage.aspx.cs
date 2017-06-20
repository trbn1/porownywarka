using System;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

public partial class Account_Manage : Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["usrdb"].ConnectionString;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        string username = Context.User.Identity.Name;
        UserName.Text = username;

        MySqlConnection conn = new MySqlConnection(GetConnectionString());

        try
        {
            conn.Open();

            string getUsr = "SELECT id_uzytkownika, e_mail FROM uzytkownicy WHERE login='" + username + "'";
            MySqlCommand cmdUsr = new MySqlCommand(getUsr, conn);
            using (MySqlDataReader readData = cmdUsr.ExecuteReader())
            {
                while (readData.Read())
                {
                    usrID.Text = readData.GetString(0);
                    Email.Text = readData.GetString(1);
                }
            }
            int uid = Convert.ToInt32(usrID.Text);
            int dataid = uid;
            int addressid = uid;

            string sql_addr = "SELECT ulica, nr_domu, miasto, kod_pocztowy, wojewodztwo FROM adresy WHERE id_adres=" + addressid;
            MySqlCommand cmdAddr = new MySqlCommand(sql_addr, conn);
            using (MySqlDataReader readData = cmdAddr.ExecuteReader())
            {
                while (readData.Read())
                {
                    Street.Text = readData.GetString(0);
                    Number.Text = readData.GetString(1);
                    City.Text = readData.GetString(2);
                    PostCode.Text = readData.GetString(3);
                    State.Text = readData.GetString(4);
                }
            }

            string sql_usrData = "SELECT imie, nazwisko, plec, DATE_FORMAT(data_urodzenia, '%Y-%m-%d') AS data, nr_telefonu FROM dane_osobowe WHERE id_dane=" + dataid;
            MySqlCommand cmdUsrData = new MySqlCommand(sql_usrData, conn);
            using (MySqlDataReader readData = cmdUsrData.ExecuteReader())
            {
                while (readData.Read())
                {
                    Name.Text = readData.GetString(0);
                    Surname.Text = readData.GetString(1);
                    Gender.Text = readData.GetString(2);
                    Bday.Text = readData.GetString(3);
                    Phone.Text = readData.GetString(4);
                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Select Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            conn.Close();
        }
    }

    private void UpdateUser(string usrID, string username, string password, string email, string name, string bday, string gender, string city, string street, string number, string post_code, string state, string surname, string phone)
    {
        MySqlConnection conn = new MySqlConnection(GetConnectionString());

        try
        {
            conn.Open();
            int uid = Convert.ToInt32(usrID);
            int dataid = uid;
            int addressid = uid;
            string sql_usr = "UPDATE uzytkownicy SET haslo=@haslo, e_mail=@e_mail WHERE id_uzytkownika=" + uid;
            string sql_addr = "UPDATE adresy SET ulica=@ulica, nr_domu=@nr_domu, miasto=@miasto, kod_pocztowy=@kod_pocztowy, wojewodztwo=@wojewodztwo WHERE id_adres=" + addressid;
            string sql_usrData = "UPDATE dane_osobowe SET imie=@imie, nazwisko=@nazwisko, plec=@plec, data_urodzenia=@data_urodzenia, nr_telefonu=@nr_telefonu WHERE id_dane=" + dataid;
            MySqlCommand cmd = new MySqlCommand(sql_usr, conn);
            MySqlCommand cmd2 = new MySqlCommand(sql_addr, conn);
            MySqlCommand cmd3 = new MySqlCommand(sql_usrData, conn);

            MySqlParameter[] param = new MySqlParameter[2];
            param[0] = new MySqlParameter("@haslo", MySqlDbType.VarChar, 50);
            param[1] = new MySqlParameter("@e_mail", MySqlDbType.VarChar, 50);

            param[0].Value = password;
            param[1].Value = email;

            MySqlParameter[] param2 = new MySqlParameter[5];
            param2[0] = new MySqlParameter("@ulica", MySqlDbType.VarChar, 50);
            param2[1] = new MySqlParameter("@nr_domu", MySqlDbType.VarChar, 50);
            param2[2] = new MySqlParameter("@miasto", MySqlDbType.VarChar, 50);
            param2[3] = new MySqlParameter("@kod_pocztowy", MySqlDbType.VarChar, 50);
            param2[4] = new MySqlParameter("@wojewodztwo", MySqlDbType.VarChar, 50);

            param2[0].Value = street;
            param2[1].Value = number;
            param2[2].Value = city;
            param2[3].Value = post_code;
            param2[4].Value = state;

            MySqlParameter[] param3 = new MySqlParameter[5];
            param3[0] = new MySqlParameter("@imie", MySqlDbType.VarChar, 50);
            param3[1] = new MySqlParameter("@nazwisko", MySqlDbType.VarChar, 50);
            param3[2] = new MySqlParameter("@plec", MySqlDbType.VarChar, 50);
            param3[3] = new MySqlParameter("@data_urodzenia", MySqlDbType.VarChar, 50);
            param3[4] = new MySqlParameter("@nr_telefonu", MySqlDbType.VarChar, 50);

            param3[0].Value = name;
            param3[1].Value = surname;
            param3[2].Value = gender;
            param3[3].Value = bday;
            param3[4].Value = phone;

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
            string msg = "Update Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void UpdateUser_Click(object sender, EventArgs e)
    {
        UpdateUser(usrID.Text,
                    UserName.Text,
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
        Response.Write("Zmiana danych pomyślna.");
    }
}