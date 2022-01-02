using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVWAREHOUSE.DataTransferObject
{
    class ThongTinTaiKhoanDTO
    {
        private int iDTaiKhoan;
        private string ten;
        private int tuoi;
        private string diaChi;
        private string sDT;


        public int IDTaiKhoan { get => iDTaiKhoan; set => iDTaiKhoan = value; }
        public string Ten { get => ten; set => ten = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }

        public ThongTinTaiKhoanDTO(DataRow row)
        {
            this.IDTaiKhoan = (int)row["IDTaiKhoan"];

            this.Ten = row["Ten"].ToString();

            if(row["Tuoi"].ToString() != "")

            this.Tuoi = (int)row["Tuoi"];

            this.DiaChi = row["DiaChi"].ToString();

            this.SDT = row["SDT"].ToString();
        }
    }
}
