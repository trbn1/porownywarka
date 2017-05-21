using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Account_Register : Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["connREG"].ConnectionString;
    }

    private void InsertUser(string username, string password, string email, string name, string bday, string gender, string city, string street, string number, string post_code, string state, string surname, string phone)
    {
        SqlConnection conn = new SqlConnection(GetConnectionString());
        string sql_usr = "INSERT INTO dbo.uzytkownicy (id_uzytkownika, id_adres, id_dane, login, haslo, e_mail) VALUES "
                    + " (@id_uzytkownika,@id_adres,@id_dane,@login,@haslo,@e_mail)";

        string sql_addr = "INSERT INTO dbo.adresy (id_adres, ulica, nr_domu, miasto, kod_pocztowy, wojewodztwo) VALUES "
                    + " (@id_adres,@ulica,@nr_domu,@miasto,@kod_pocztowy,@wojewodztwo)";

        string sql_usrData = "INSERT INTO dbo.dane_osobowe (id_dane, imie, nazwisko, plec, data_urodzenia, nr_telefonu) VALUES "
                    + " (@id_dane,@imie,@nazwisko,@plec,@data_urodzenia,@nr_telefonu)";

        string getLastUID = "SELECT MAX(id_uzytkownika) FROM dbo.uzytkownicy";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql_usr, conn);
            SqlCommand cmd2 = new SqlCommand(sql_addr, conn);
            SqlCommand cmd3 = new SqlCommand(sql_usrData, conn);
            SqlCommand cmdLastUID = new SqlCommand(getLastUID, conn);

            int uid = (Int32)cmdLastUID.ExecuteScalar() + 1;
            int dataid = uid;
            int addressid = uid;

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id_uzytkownika", SqlDbType.Int, 10);
            param[1] = new SqlParameter("@id_adres", SqlDbType.Int, 10);
            param[2] = new SqlParameter("@id_dane", SqlDbType.Int, 10);
            param[3] = new SqlParameter("@login", SqlDbType.VarChar, 50);
            param[4] = new SqlParameter("@haslo", SqlDbType.VarChar, 50);
            param[5] = new SqlParameter("@e_mail", SqlDbType.VarChar, 50);

            param[0].Value = uid;
            param[1].Value = dataid;
            param[2].Value = addressid;
            param[3].Value = username;
            param[4].Value = password;
            param[5].Value = email;

            SqlParameter[] param2 = new SqlParameter[6];
            param2[0] = new SqlParameter("@id_adres", SqlDbType.Int, 10);
            param2[1] = new SqlParameter("@ulica", SqlDbType.VarChar, 50);
            param2[2] = new SqlParameter("@nr_domu", SqlDbType.VarChar, 50);
            param2[3] = new SqlParameter("@miasto", SqlDbType.VarChar, 50);
            param2[4] = new SqlParameter("@kod_pocztowy", SqlDbType.VarChar, 50);
            param2[5] = new SqlParameter("@wojewodztwo", SqlDbType.VarChar, 50);

            param2[0].Value = addressid;
            param2[1].Value = street;
            param2[2].Value = number;
            param2[3].Value = city;
            param2[4].Value = post_code;
            param2[5].Value = state;

            SqlParameter[] param3 = new SqlParameter[6];
            param3[0] = new SqlParameter("@id_dane", SqlDbType.Int, 10);
            param3[1] = new SqlParameter("@imie", SqlDbType.VarChar, 50);
            param3[2] = new SqlParameter("@nazwisko", SqlDbType.VarChar, 50);
            param3[3] = new SqlParameter("@plec", SqlDbType.VarChar, 50);
            param3[4] = new SqlParameter("@data_urodzenia", SqlDbType.VarChar, 50);
            param3[5] = new SqlParameter("@nr_telefonu", SqlDbType.VarChar, 50);

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
        Response.Write("Rejestracja pomyślna.");
    }
}