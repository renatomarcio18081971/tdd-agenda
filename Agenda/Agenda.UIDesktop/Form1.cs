using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string strCon = @"Data Source=DESK01\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;Connect Timeout=30;
                              Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                string sql = "insert into contato(id, nome) values (NEWID(), " + "'" + txtContato.Text + "')";
                SqlCommand com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();
            }
        }
    }
}
