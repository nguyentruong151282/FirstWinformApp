using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DataTransferObject;

namespace INVWAREHOUSE.DataAccessLayer
{
    public class DanhSachHoaDonDAL
    {
        private static DanhSachHoaDonDAL instance;

        public static DanhSachHoaDonDAL Instance
        {
            get { if (instance == null) instance = new DanhSachHoaDonDAL(); return DanhSachHoaDonDAL.instance; }

            private set { DanhSachHoaDonDAL.instance = value; }
        }

        private DanhSachHoaDonDAL() { }

        public DataTable LoadBillList()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Tên Khách Hàng", typeof(string));
            D.Columns.Add("Địa Chỉ", typeof(string));
            D.Columns.Add("SDT", typeof(string));
            D.Columns.Add("Tên Series", typeof(string));
            D.Columns.Add("Công Suất", typeof(int));
            D.Columns.Add("Option", typeof(string));
            D.Columns.Add("Mã QR",typeof(string));
            D.Columns.Add("Ngày", typeof(DateTime));


            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.ThongTinHoaDons select s;
                
                foreach (var data in Q)
                {

                    D.Rows.Add(data.TenKH, data.DiaChi, data.SDT, data.TenSeries, data.cs, data.opt, data.qr,data.ngay);
                    
                }

            }

            return D;
        }

        public DataTable LoadBillListByDay(string date1, string date2, string noidung, string danhmuc)
        {
            DateTime d1 = DateTime.Parse(date1);
            DateTime d2 = DateTime.Parse(date2);
            

            DataTable D = new DataTable();
            D.Columns.Add("Tên Khách Hàng", typeof(string));
            D.Columns.Add("Địa Chỉ", typeof(string));
            D.Columns.Add("SDT", typeof(string));
            D.Columns.Add("Tên Series", typeof(string));
            D.Columns.Add("Công Suất", typeof(int));
            D.Columns.Add("Option", typeof(string));
            D.Columns.Add("Mã QR", typeof(string));
            D.Columns.Add("Ngày", typeof(DateTime));


            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                

                if (noidung == "" && danhmuc == "")
                {
                    var Q = from s in DB.ThongTinHoaDons where s.ngay > d1 && s.ngay < d2 select s;
                    foreach (var data in Q)
                        D.Rows.Add(data.TenKH, data.DiaChi, data.SDT, data.TenSeries, data.cs, data.opt, data.qr, data.ngay); 
                }
                else
                    if(danhmuc == "Tên KH")
                {
                    var Q = from s in DB.ThongTinHoaDons where s.ngay > d1 && s.ngay < d2 && s.TenKH == noidung select s;
                    foreach (var data in Q)
                        D.Rows.Add(data.TenKH, data.DiaChi, data.SDT, data.TenSeries, data.cs, data.opt, data.qr, data.ngay);
                }
                else if(danhmuc == "Tên Series")
                {
                    var Q = from s in DB.ThongTinHoaDons where s.ngay > d1 && s.ngay < d2 && s.TenSeries == noidung select s;
                    foreach (var data in Q)
                        D.Rows.Add(data.TenKH, data.DiaChi, data.SDT, data.TenSeries, data.cs, data.opt, data.qr, data.ngay);
                }
                else
                {
                    var Q = from s in DB.ThongTinHoaDons where s.ngay > d1 && s.ngay < d2 && s.qr == noidung select s;
                    foreach (var data in Q)
                        D.Rows.Add(data.TenKH, data.DiaChi, data.SDT, data.TenSeries, data.cs, data.opt, data.qr, data.ngay);
                }
            }

            return D;
        }

        public int RemoveBillByQR(string qr)
        {
            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = (from d in DB.ThongTinHoaDons where d.qr == qr select d).SingleOrDefault();
                DB.ThongTinHoaDons.Remove(Q);
                return DB.SaveChanges();
            }
        }
  
    }
}
