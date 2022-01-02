using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVWAREHOUSE.DataTransferObject
{
    public class DanhMucSanPhamDTO
    {
        private string tenSeries;
        private int soLuong;
        private int iD;

        public string TenSeries { get => tenSeries; set => tenSeries = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int ID { get => iD; set => iD = value; }

        public DanhMucSanPhamDTO(int id, string ten, int soluong)
        {
            this.ID = id;

            this.TenSeries = ten;

            this.SoLuong = soLuong;
        }

        public DanhMucSanPhamDTO(DataRow row)
        {
            this.ID = (int)row["id"];

            this.SoLuong = (int)row["SoLuong"];

            this.TenSeries = row["TenSeries"].ToString();
        }
    }
}
