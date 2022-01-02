using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DataTransferObject;

namespace INVWAREHOUSE.DataAccessLayer
{
    class ThongTinTaiKhoanDAL
    {
        private static ThongTinTaiKhoanDAL instance;

        public static ThongTinTaiKhoanDAL Instance
        {
            get { if (instance == null) instance = new ThongTinTaiKhoanDAL(); return ThongTinTaiKhoanDAL.instance; }

            private set { ThongTinTaiKhoanDAL.instance = value; }
        }

        private ThongTinTaiKhoanDAL() { }

        public List<string> LoadInfoAccountWithID(string id)
        {
            string query = "select * from ThongTinTaiKhoan where IDTaiKhoan = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<string> A = new List<string>();

            if(data.Rows.Count>0)
            {
                DataRow dtr = data.Rows[0];

                ThongTinTaiKhoanDTO F = new ThongTinTaiKhoanDTO(dtr);

                A.Add(F.Ten);
                A.Add(F.Tuoi.ToString());
                A.Add(F.DiaChi);
                A.Add(F.SDT);
            }

            return A;
        }
    }
}
