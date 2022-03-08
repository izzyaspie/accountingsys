using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountingsys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=localhost;database=accountingsys;UID=sa;password=123456789");
                SqlCommand cmd = new SqlCommand("select * from UserLogins where UserName=@UserName and Password = @Password", con);
                cmd.Parameters.AddWithValue("@UserName", usernameBox.Text);
                cmd.Parameters.AddWithValue("@Password", passWordBox.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                con.Open();
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    settings_form welcomePage = new settings_form(dt.Rows[0][1].ToString());

                    Hide();
                    welcomePage.ShowDialog();
                    Close();

                }
                else
                {
                    MessageBox.Show("Wrong user info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }
    }
}
