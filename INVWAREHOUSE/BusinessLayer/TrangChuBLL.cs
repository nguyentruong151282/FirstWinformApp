using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DataAccessLayer;
using INVWAREHOUSE.DataTransferObject;
using INVWAREHOUSE.DTO;

namespace INVWAREHOUSE.BusinessLayer
{
    public class TrangChuBLL
    {

        private static TrangChuBLL instance;

        public static TrangChuBLL Instance
        {
            get { if (instance == null) instance = new TrangChuBLL(); return TrangChuBLL.instance; }

            private set { TrangChuBLL.instance = value; }
        }

        private TrangChuBLL() { }

        public List<string> LoadDSSeries()
        {
            List<string> A = new List<string>();

            A = DanhMucSanPhamDAL.Instance.LoadDanhSachSeries();

            return A;
        }

        public int LoadProductQty(string w)
        {
            return DanhMucSanPhamDAL.Instance.LoadProductQty(w);
        }

        public List<string> LoadSeriesList()
        {
            return DanhMucSanPhamDAL.Instance.LoadSeriesList();
        }

        public List<string> LoadPowerList()
        {
            return DanhMucSanPhamDAL.Instance.LoadPowerList();
        }

        public List<string> LoadOptList()
        {
            return DanhMucSanPhamDAL.Instance.LoadOptList();
        }

        public List<string> LoadQR(string a, string b, string c)
        {
            return DanhMucSanPhamDAL.Instance.LoadQR(a,b,c);
        }

        public int LoadQrQty(string a, string b, string c)
        {
            return DanhMucSanPhamDAL.Instance.LoadQRqty(a, b, c);
        }

        public int AddProduct(string series, string cs, string opt, string qr)
        {
            if (opt == "") opt = "None";
            if (series == "" || series == "Tất Cả") return -1;
            if (!Int32.TryParse(cs,out int a)) return -2;
            
            if (qr.Length != 6 || qr.Contains(" ")) return -4;
            else
            {
                if (DanhMucSanPhamDAL.Instance.SearchByQR(qr).Count > 0) return -6;
                else return DanhMucSanPhamDAL.Instance.AddProduct(series, a, opt, qr);

            }
        }

        public int ChangeProductInfo(string a, string cs, string opt, string qr, string qrcu)
        {
            if (opt == "") opt = "None";
            if (!Int32.TryParse(cs, out int z)) return -2;
            
            if (qr.Length != 6 || qr.Contains(" ")) return -4;
            else
                
            {
                if (DanhMucSanPhamDAL.Instance.SearchByQR(qr).Count > 0) return -6;
                else return DanhMucSanPhamDAL.Instance.ChangeProductInfo(a, z, opt, qr, qrcu);

            }
            
        }

        public int RemoveProduct(string tenkh, string diachi, string SDT, string qr)
        {
            if (tenkh == "") return -1;
            if (diachi == "") return -2;
            if (SDT == "") return -3;
            return DanhMucSanPhamDAL.Instance.RemoveProduct(tenkh, diachi, SDT, qr);
        }
    }
}
