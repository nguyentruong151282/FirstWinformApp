using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVWAREHOUSE.DataAccessLayer;
using INVWAREHOUSE.DataTransferObject;
using INVWAREHOUSE.DTO;

namespace INVWAREHOUSE.BusinessLayer
{
    public class DanhSachHoaDonBLL
    {
        private static DanhSachHoaDonBLL instance;

        public static DanhSachHoaDonBLL Instance
        {
            get { if (instance == null) instance = new DanhSachHoaDonBLL(); return DanhSachHoaDonBLL.instance; }

            private set { DanhSachHoaDonBLL.instance = value; }
        }

        private DanhSachHoaDonBLL() { }

        public DataTable LoadAllBill()
        {
            return DanhSachHoaDonDAL.Instance.LoadBillList();
        }

        public DataTable LoadBillListByDay(string date1, string date2, string nd, string dm)
        {
            return DanhSachHoaDonDAL.Instance.LoadBillListByDay(date1, date2, nd, dm);
        }

        public List<string> AllColumn()
        {
            List<string> A = new List<string>();
            A.Add("Tất cả");
            A.Add("Tên KH");
            A.Add("Tên Series");
            A.Add("Mã QR");
            return A;
        }

        public int Check(string cat, string t)
        {
            if (cat == "Tên KH")
                if (t == "") return -1; else return 1;
            if (cat == "Tên Series")
                if (t == "") return -2; else return 1;
            if (cat == "Mã QR")
                if (t.Length != 6 || t.Contains(" ")) return -3; else return 1;
            else return -4;
        }

        public bool CheckAdminManagerRight()
        {
            CurrentAccountDTO F = new CurrentAccountDTO();
            if (F.AccessLevel == "Staff")
                return false;
            else
                return true;
        }

        public string GetQRFromCell(DataGridViewRow Row)
        {
            return Row.Cells[6].Value.ToString();
        }

        public int RemoveBillByQR(string qr)
        {
            return DanhSachHoaDonDAL.Instance.RemoveBillByQR(qr);
        }

    }
}
