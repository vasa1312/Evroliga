using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EuroLeague.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string upit = "SELECT * FROM Fantasy";
                SqlDataAdapter adapter = new SqlDataAdapter(upit,connection);
                DataTable table = new DataTable();

                adapter.Fill(table);

                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "" || TextBox2.Text == "")
            {
                Label4.Text = "Fill the fields";
                return;
            }

            try
            {
                connection.Open();

                int fantasyID = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                string fullName = TextBox1.Text;
                int fantasyPoints = int.Parse(TextBox2.Text);

                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();
                SqlParameter p3 = new SqlParameter();

                p1.Value = fantasyID;
                p2.Value = fullName;
                p3.Value = fantasyPoints;

                p1.ParameterName = "fantasyID";
                p2.ParameterName = "fullName";
                p3.ParameterName = "fantasyPoints";

                string upit = "UPDATE Fantasy SET imePrezime = @fullName, brojFantasyPoena = @fantasyPoints WHERE fantasyID = @fantasyID";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);
                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch(Exception ex)
            {
                Label4.Text = "Error.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || GridView1.SelectedRow == null)
            {
                Label4.Text = "Fill the fields or select row!";
                return;
            }

            try
            {
                connection.Open();

                int fantasyID = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                SqlParameter p1 = new SqlParameter();
                p1.Value = fantasyID;
                p1.ParameterName = "fantasyID";
     
                string upit = "DELETE FROM Fantasy WHERE fantasyID = @fantasyID";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);
                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                Label4.Text = "Error.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            if(row == null)
            {
                Label1.Text = "Please select row!";
                return;
            }

            TextBox1.Text = row.Cells[2].Text;
            TextBox2.Text = row.Cells[3].Text;
        }
    }
}