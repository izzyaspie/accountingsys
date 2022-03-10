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

namespace AccountingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=localhost;database=accountingSys;UID=sa;password=123456789");
            SqlCommand cmd = new SqlCommand("select * from Userlogins where UserName=@UserName and Password =@Password", con);
            cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Connection open here   
            con.Open();
            //int i = cmd.ExecuteNonQuery();
           
            con.Close();
            if (dt.Rows.Count > 0)
            {
                
                MessageBox.Show("Successfully loged in");
                //after successful it will redirect  to next page .  
                WelcomePage settingsForm = new WelcomePage(dt.Rows[0][1].ToString(), dt.Rows[0][0].ToString());
                
                this.Hide();
                settingsForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter Correct Username and Password");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
