using System;
using System.Web.Security;
using System.Web.UI;
using MySql.Data.MySqlClient;

public partial class Account_Login : Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["usrdb"].ConnectionString;
    }

    private void LogInUser(string username, string password)
    {
        MySqlConnection conn = new MySqlConnection(GetConnectionString());
        string sql = "SELECT login,haslo FROM uzytkownicy WHERE login ='" + username + "' AND haslo ='" + password + "'";

        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        string validInfo;
        validInfo = (string)cmd.ExecuteScalar();

        if (validInfo != null)
        {
            FormsAuthentication.SetAuthCookie(username, true);
            Response.Redirect("~/Default.aspx");
            //Response.Write("Logowanie pomyślne");
        }
        else
        {
            Response.Write("Logowanie niepomyślne");
        }
        conn.Close();
    }

    protected void LogIn(object sender, EventArgs e)
    {
        LogInUser(UserName.Text,
                    Password.Text);
    }
}