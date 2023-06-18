using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzzWF
{
    public class dal : DBConnect
    {
        DBConnect connect = new DBConnect();

        public DataTable getData()
        {
            return connect.getData("Select * from CUSTOMERS");
        }

        //public int kiemtramatrung(string ma)
        //{
        //    string sql = "Select count(*) from CUSTOMERS where Id = '" + ma.Trim() + "'";
        //    return connect.kiemtramatrung(ma, sql);
        //}

        public bool ThemKH(Customer kh)
        {
            string sql = string.Format("Insert into CUSTOMERS values('{0}', N'{1}', N'{2}', '{3}')", kh.Id, kh.Name, kh.City, kh.Phone);
            thucthisql(sql);
            return true;
        }

        public bool SuaKH(Customer kh)
        {
            string sql = string.Format("Update CUSTOMERS Set Name = N'{0}', City = N'{1}', Phone = '{2}' Where Id = '{3}'", kh.Name, kh.City, kh.Phone, kh.Id);
            thucthisql(sql);
            return true;
        }

        public bool XoaKH(string ma)
        {
            string sql = "Delete From CUSTOMERS Where Id = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }

    }
}
