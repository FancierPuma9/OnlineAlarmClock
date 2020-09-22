using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAlarmClock
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitClicked(object sender, EventArgs e)
        {
            bool checkSuccess = performCheck();
            if (checkSuccess == true)
            {
                string connectionString = null;
                connectionString = "Data Source = ***; Initial Catalog = alarm_clocks; Persist Security Info = True; User ID = ***; Password = ***";
                SqlConnection con;
                
                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT_REGISTRATION", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USERNAME", SqlDbType.VarChar).Value = usernameBox.Text;
                    cmd.Parameters.AddWithValue("@PASSWORD", SqlDbType.VarChar).Value = passwordBox.Text;
                    cmd.Parameters.AddWithValue("@EMAIL", SqlDbType.VarChar).Value = emailBox.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Response.Redirect("HomePage.aspx");

                string script = "alert(\"Registration Successful!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---CHECK FAILED---
            }
        }

        protected void CancelClicked(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


        protected bool performCheck()
        {
            bool inputValidity = checkInputValidity();
            bool serverValidity = checkServerValidity();

            if (inputValidity == true && serverValidity == true)
            {

                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT    ---REGISTRATION SUCCESS---
                return true;
            }
            else if (inputValidity == true && serverValidity == false)
            {
                
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT
                return false;
            }
            else if (inputValidity == false && serverValidity == true)
            {
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT  
                return false;
            }
            else
            {
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT
                return false;
            }
        }


        protected bool checkInputValidity()
        {
            if (passwordBox.Text == confirmPasswordBox.Text && emailBox.Text == emailConfirmBox.Text)
            {
                return true;
            }
            else if (passwordBox.Text != confirmPasswordBox.Text || emailBox.Text != emailConfirmBox.Text)
            {
                string input = "ijfsikhjdiusdijakijsdnikjsa";

                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "document.body.appendChild(alertBox(\"Alert Box\"))", true);
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---EMAIL BOX OR PASSWORD BOX NEEDS TO BE CONFIRMED---
                return false;
            }
            else
            {
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---???---
                return false;
            }
        }
        
        protected bool checkServerValidity()
        {
            int success1 = 0;
            string connectionString = null;
            connectionString = "Data Source = ***; Initial Catalog = alarm_clocks; Persist Security Info = True; User ID = ***; Password = ***";
            SqlConnection con;
            con = new SqlConnection(connectionString);
            
            try
            {
                con.Open();
                

                
                try
                {
                    string query = "SELECT username FROM users WHERE username =\'" + usernameBox.Text + "\'";
                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (usernameBox.Text == reader.GetString(0))
                        {
                            string script = "alert(\"Username already taken.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---USERNAME IS ALREADY TAKEN---
                            return false;
                        }
                    }
                    else
                    {
                        success1 += 1;
                    }
                } catch (Exception ex)
                {
                    //THIS IS AN ERROR   ---QUERY ERROR
                }
                con.Close();

                con.Open();
                try
                {
                    string query = "SELECT email FROM users WHERE email=\'" + emailBox.Text + "\'";
                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (emailBox.Text == reader.GetString(0))
                        {
                            string script = "alert(\"This Email is already registered to an account.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---EMAIL IS ALREADY TAKEN---
                            return false;
                        }
                    }
                    else
                    {
                        success1 += 1;
                    }
                } catch (Exception ex)
                {
                    //THIS IS AN ERROR   ---QUERY ERROR---
                }
                con.Close();

                if (success1 == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string input = "error";
                
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alertBox("+input+")", true);
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---SERVER CONNECTION ERROR---
                return false;
            }
        }

    }
}
