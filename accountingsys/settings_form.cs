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
    public partial class settings_form : Form
    {
        public settings_form(string username)
        {
            
            InitializeComponent();
            label2.Text = username;
        }

        private void settings_form_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=localhost;database=accountingsys;UID=sa;password=123456789");
            SqlCommand cmd = new SqlCommand("select * from UserLogins ", con);
            

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            con.Open();
            con.Close();
            dataGridView1.DataSource = dt; 



        }
    }
}
