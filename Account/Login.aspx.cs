using System;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;

public partial class Account_Login : Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["connREG"].ConnectionString;
    }

    private void LogInUser(string username, string password)
    {
        SqlConnection conn = new SqlConnection(GetConnectionString());
        string sql = "SELECT login,haslo FROM dbo.uzytkownicy WHERE login ='" + username + "' AND haslo ='" + password + "'";

        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);

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