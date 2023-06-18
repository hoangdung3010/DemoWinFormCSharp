using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzzWF
{
    public class DBConnect
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataTable dt;
        string chuoikn = "Data Source=DESKTOP-PBAV582\\SQLEXPRESS;Initial Catalog=Zzz;Integrated Security=True";

        public void ketnoi()
        {
            con = new SqlConnection(chuoikn);
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        public void ngatkn()
        {
            con = new SqlConnection(chuoikn);
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public void thucthisql(string sql)
        {
            ketnoi();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ngatkn();
        }

        public DataTable getData(string sql)
        {
            ketnoi();
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            ngatkn();
            return dt;
        }


    }
}
