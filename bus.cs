using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzzWF
{
    public class bus
    {
        dal a = new dal();
        public DataTable getData()
        {
            return a.getData();
        }

        //public int kiemtramatrung(string ma)
        //{
        //    return a.kiemtramatrung(ma);
        //}
        public bool ThemKH(Customer kh)
        {
            return a.ThemKH(kh);
        }
        public bool SuaKH(Customer kh)
        {
            return a.SuaKH(kh);
        }
        public bool XoaKH(string ma)
        {
            return a.XoaKH(ma);
        }

    }
}
