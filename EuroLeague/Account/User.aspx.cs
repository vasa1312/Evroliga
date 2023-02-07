using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EuroLeague.Account
{
    public partial class User : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "" || TextBox2.Text == "") {
                Label3.Text = "Fill the fields.";
                return;
            }

            try
            {
                connection.Open();

                string fullName = TextBox1.Text;
                int fantasyPoints = int.Parse(TextBox2.Text);

                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();

                p1.Value = fullName;
                p2.Value = fantasyPoints;

                p1.ParameterName = "fullName";
                p2.ParameterName = "fantasyPoints";

                string upit = "INSERT INTO Fantasy (imePrezime, brojFantasyPoena) VALUES (@fullName, @fantasyPoints)";
                SqlCommand command = new SqlCommand(upit, connection);

                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                command.ExecuteNonQuery();

                Response.Redirect("~/Account/User.aspx", false);
            }
            catch (Exception ex)
            {
                Label3.Text = "Error.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}