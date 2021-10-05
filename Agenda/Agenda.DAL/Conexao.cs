using System.Data.SqlClient;

namespace Agenda.DAL
{
    public static class Conexao
    {
        private static SqlConnection con = null;

        private static string strCon = @"Data Source=DESK01\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;Connect Timeout=30;
                               Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection AbreConexao()
        {
            con = new SqlConnection(strCon);
            con.Open();
            return con;
        }

        public static void FecharConexao()
        {
            con.Close();
        }
    }
}
