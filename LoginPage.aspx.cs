using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAlarmClock
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginClicked(object sender, EventArgs e)
        {
            bool checkPassword = CheckPassword();
            
            if (checkPassword == true)
            {

                Response.Cookies["username"].Value = usernameBox.Text;
                Response.Redirect("UserHome.aspx");
            }
            else
            {

            }
        }

        protected void CancelClicked(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


        protected bool CheckPassword()
        {
            string connectionString = null;
            connectionString = "Data Source = ***; Initial Catalog = alarm_clocks; Persist Security Info = True; User ID = ***; Password = ***";
            SqlConnection con;

            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CHECK_PASSWORD", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERNAME", SqlDbType.VarChar).Value = usernameBox.Text;
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString(0) == passwordBox.Text)
                    {
                        return true;
                    }
                    else
                    {
                        string script = "alert(\"Wrong Password. Try Again.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        //INSERT ALERT DIALOG BOX WITH JAVASCRIPT HERE   ---WRONG PASSWORD---
                        return false;
                    }
                }
                else
                {
                    string script = "alert(\"Username or password incorrect. Try Again.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    //INSERT ALERT DIALOG BOX WITH JAVASCRIPT HERE   ---WRONG USERNAME OR PASSWORD---
                    return false;
                }
            }
        }
    }
}