using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAlarmClock
{
    public partial class UserHome : System.Web.UI.Page
    {
        static int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            soundList.Items.Clear();
            Directory.GetFiles("C:\\Users\\idont\\source\\repos\\OnlineAlarmClock\\soundFiles\\");
            int count = 0;
            foreach (string file in Directory.GetFiles("C:\\Users\\idont\\source\\repos\\OnlineAlarmClock\\soundFiles\\"))
            {
                string name = file.Remove(0, 56);
                soundList.Items.Insert(count, name);
                count++;
            }

            string username = Request.Cookies["username"].Value;
            string connectionString = "Data Source = PUMA-DESKTOP; Initial Catalog = alarm_clocks; Persist Security Info = True; User ID = rlogin; Password = Password9";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT userId FROM users WHERE username=\'" + username + "\'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                userId = reader.GetInt32(0);
            }
            else
            {
                string script = "alert(\"You are not logged in...\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                //INSERT ALERT DIALOG BOX WITH JAVASCRIPT   ---NOT LOGGED IN---
            }
            con.Close();
            
            con.Open();
            string tableOutput = "";
            command = new SqlCommand("GET_USER_ALARMS", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("USERID", SqlDbType.Int).Value = userId;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                HttpCookie alarmInfo = new HttpCookie(reader["alarmID"].ToString());
                alarmInfo["alarmTime"] = reader["alarmTime"].ToString();
                alarmInfo["alarmSound"] = reader["alarmSound"].ToString();
                Response.Cookies.Add(alarmInfo);

                tableOutput += "<div class=\"listItem\"  >" 
                    + "<p>" + reader["alarmName"] + "</p>" 
                    + "<p>" + reader["alarmDesc"] + "</p>" 
                    + "<p>" + TimeSpan.FromSeconds((int)reader["alarmTime"]) + "</p>" 
                    + "<button id=\""+ reader["alarmID"] +"\" onclick=\"startAlarm(this)\">Start</button>" 
                    + "<button id=\""+ reader["alarmID"] + "\" onclick=\"deleteAlarm(this)\">Delete</button>" 
                    + "</div>";
            }
            
            reader.Close();
            con.Close();
            list.Text = tableOutput;
        }

        [WebMethod] public static void playSound(string file)
        {
            string path = "C:\\Users\\idont\\source\\repos\\OnlineAlarmClock\\soundFiles\\" + file;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.Play();
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = PUMA-DESKTOP; Initial Catalog = alarm_clocks; Persist Security Info = True; User ID = rlogin; Password = Password9";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("INSERT_ALARM", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("ALARMNAME", SqlDbType.VarChar).Value = alarmName.Text;
            command.Parameters.AddWithValue("ALARMDESC", SqlDbType.VarChar).Value = alarmDescription.Text;
            command.Parameters.AddWithValue("ALARMTIME", SqlDbType.Int).Value = Request.Cookies["alarmtime000"].Value;
            command.Parameters.AddWithValue("ALARMSOUND", SqlDbType.VarChar).Value = soundList.SelectedValue;
            command.Parameters.AddWithValue("USERID", SqlDbType.Int).Value = userId;
            command.Parameters.AddWithValue("MATHPROBLEM", SqlDbType.Bit).Value = mathCheck.Checked;
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            Response.Redirect("UserHome.aspx");
        }

        [WebMethod] public static void deleteAlarm(int alarmId)
        {
            string connectionString = "Data Source = PUMA-DESKTOP; Initial Catalog = alarm_clocks; Persist Security Info = True; User ID = rlogin; Password = Password9";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("DELETE_ALARM", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("ALARMID", SqlDbType.Int).Value = alarmId;
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            

        }

        
    }
}