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

    private void InsertUser(string username, string password, string email, string name, string bday, string gender, string city)
    {
        SqlConnection conn = new SqlConnection(GetConnectionString());
        string sql = "INSERT INTO dbo.uzytkownicy (id_uzytkownika, login, haslo, e_mail) VALUES "
                    + " (@id_uzytkownika,@login,@haslo,@e_mail)";

        string getLastUID = "SELECT MAX(id_uzytkownika) FROM dbo.uzytkownicy";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlCommand cmdLastUID = new SqlCommand(getLastUID, conn);

            int id_uzytkownika = (Int32)cmdLastUID.ExecuteScalar() + 1;
            int id_dane = id_uzytkownika;
            int id_adres = id_uzytkownika;

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id_uzytkownika", SqlDbType.Int, 10);
            param[1] = new SqlParameter("@login", SqlDbType.VarChar, 50);
            param[2] = new SqlParameter("@haslo", SqlDbType.VarChar, 50);
            param[3] = new SqlParameter("@e_mail", SqlDbType.VarChar, 50);

            param[0].Value = id_uzytkownika;
            param[1].Value = username;
            param[2].Value = password;
            param[3].Value = email;


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
                    City.Text);
        Response.Write("Rejestracja pomyślna.");
    }
}