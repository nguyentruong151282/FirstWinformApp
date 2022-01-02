using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DTO;

namespace INVWAREHOUSE.DataAccessLayer
{
    class DanhMucSanPhamDAL
    {
        private static DanhMucSanPhamDAL instance;

        public static DanhMucSanPhamDAL Instance
        {
            get { if (instance == null) instance = new DanhMucSanPhamDAL(); return DanhMucSanPhamDAL.instance; }

            private set { DanhMucSanPhamDAL.instance = value; }
        }

        private DanhMucSanPhamDAL() { }

        public List<string> LoadDanhSachSeries()
        {
            List<string> A = new List<string>();

            A = EF.Instance.ReadProductInfo();

            A.Insert(0, "Tất Cả");

            return A;
        }

        public int LoadProductQty(string w)
        {
            if(w!="Tất Cả") return EF.Instance.ReadProductQuantity(w);

            else
            {
                int A = 0;

                foreach(string item in LoadDanhSachSeries())
                {
                    A += EF.Instance.ReadProductQuantity(item);
                }

                return A;
            }

        }

        public List<string> LoadSeriesList()
        {
            List<string> A = new List<string>();

            A = EF.Instance.ReadProductDetailSeries();

            A.Insert(0, "Tất Cả");

            return A;
        }

        public List<string> LoadPowerList()
        {
            List<string> A = new List<string>();

            A = EF.Instance.ReadProductDetailCongSuat();

            A.Insert(0, "Tất Cả");

            return A;
        }

        public List<string> LoadOptList()
        {
            List<string> C = new List<string>();

            C = EF.Instance.ReadProductDetailOpt();

            C.Insert(0, "Tất Cả");

            return C;
        }

        public List<string> LoadQR(string a, string b, string c)
        {
               
            return EF.Instance.ReadProductDetailQR(a, b, c);
        }

        public int LoadQRqty(string a, string b, string c)
        {
  

            int z = LoadQR(a, b, c).Count();

            return z;
        }

        public List<string> SearchByQR(string s)
        {
            return EF.Instance.SearchByQR(s);
        }

        public int AddProduct(string s, int c, string o, string q)
        {
            int res = 0;
            ChiTietSanPham F = new ChiTietSanPham();
            F.TenSeries = s;
            F.CongSuat = c;
            F.opt = o;
            F.MaQR = q;

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                DB.ChiTietSanPhams.Add(F);

                var restemp = DB.SaveChanges();

                res = (int)restemp;

            }

            return res;
        }

        public int ChangeProductInfo(string s, int c, string o, string q, string qrcu)
        {
            int res = 0;
            using (var DB = new invwarehouseEntities())
            {

                var result = DB.ChiTietSanPhams.SingleOrDefault(b => b.MaQR == qrcu);
                if (result != null)
                {

                    result.TenSeries = s;
                    result.CongSuat = c;
                    result.opt = o;
                    result.MaQR = q;

                    var restemp = DB.SaveChanges();

                    res = (int)restemp;
                }
            }
            return res;
        }

        public int RemoveProduct(string ten, string diachi, string SDT, string qr)
        { 
            int res = 0;
            List<string> A = Instance.SearchByQR(qr);
            if (A.Count == 0) return -6;


            else
            {

                using (invwarehouseEntities DB = new invwarehouseEntities())
                {
                    var Q = (from d in DB.ChiTietSanPhams where d.MaQR == qr select d).SingleOrDefault();
                    DB.ChiTietSanPhams.Remove(Q);
                    var tthd = new ThongTinHoaDon();
                    tthd.TenKH = ten;
                    tthd.DiaChi = diachi;
                    tthd.SDT = SDT;
                    tthd.ngay = DateTime.Now;
                    tthd.TenSeries = A[0];
                    tthd.cs = Convert.ToInt32(A[1]);
                    tthd.opt = A[2];
                    tthd.qr = qr;
                    DB.ThongTinHoaDons.Add(tthd);
                    var restemp = DB.SaveChanges();
                    res = Convert.ToInt32(restemp);

                }
            }
            return res;
        }

    }
}
