using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DataTransferObject;

namespace INVWAREHOUSE.DTO
{
    public class EF
    {
        private static EF instance;

        public static EF Instance
        {
            get { if (instance == null) instance = new EF(); return EF.instance; }

            private set { EF.instance = value; }
        }

        private EF() { }

        

        public int ReadProductQuantity(string w)
        {
            int A;

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.DanhMucSanPhams where s.TenSeries == w select s.SoLuong;

                if (Q != null)

                    A = Q.SingleOrDefault<int>();

                else

                    A = 0;
                
            }

            return A;
        }

        public List<string> ReadProductInfo()
        {
            
            List<string> A = new List<string>();

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.DanhMucSanPhams select s.TenSeries  ;

                foreach (var data in Q)
                {         
                    A.Add(data.ToString());
                }

            }

            return A;

        }

        public List<string> ReadProductDetailSeries()
        {

            List<string> A = new List<string>();

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.ChiTietSanPhams select s.TenSeries;

                foreach (var data in Q)
                {
                    if(!A.Contains(data.ToString()))
                    A.Add(data.ToString());
                }

            }

            return A;

        }

        public List<string> ReadProductDetailCongSuat()
        {

            List<string> A = new List<string>();

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.ChiTietSanPhams select s.CongSuat;

                foreach (var data in Q)
                {
                    if (!A.Contains(data.ToString()))
                        A.Add(data.ToString());
                }

            }

            return A;

        }

        public List<string> ReadProductDetailOpt()
        {

            List<string> A = new List<string>();

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.ChiTietSanPhams select s.opt
;

                foreach (var data in Q)
                {
                    if (!A.Contains(data.ToString()))
                        A.Add(data.ToString());
                }

            }

            return A;

        }

        public List<string> ReadProductDetailQR(string ten, string cs, string option)
        {
            
            
            List<string> A = new List<string>();

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                int b = -1;

                if (Int32.TryParse(cs, out int z)) b = z;

                if (ten == "Tất Cả") ten = null;

                if (option == "Tất Cả") option = null;

                var Q = from s in DB.ChiTietSanPhams where (s.TenSeries == ten || ten == null ) && (s.CongSuat == b || b == -1) && (s.opt == option || option == null) select s.MaQR;

                foreach (var data in Q)
                {
                        A.Add(data.ToString());

                }

               
            }

            return A;

        }

        public List<string> SearchByQR(String Qr)
        {
            List<string> A = new List<string>();

            using (invwarehouseEntities DB = new invwarehouseEntities())
            {
                var Q = from s in DB.ChiTietSanPhams where s.MaQR == Qr select s ;

                foreach (var data in Q)
                {
                   
                    A.Add(data.TenSeries);
                    A.Add(data.CongSuat.ToString());
                    A.Add(data.opt);
                    A.Add(data.MaQR);
                }

            }

            return A;
        }

    }
}
