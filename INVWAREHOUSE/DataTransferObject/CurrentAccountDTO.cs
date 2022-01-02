using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVWAREHOUSE.DTO
{
    public class CurrentAccountDTO
    {
        private static int iDTaiKhoan;
        private static string tenDangNhap;
        private static string matKhau;
        private static string accessLevel;
 

        public int IDTaiKhoan { get => iDTaiKhoan; set => iDTaiKhoan = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string AccessLevel { get => accessLevel; set => accessLevel = value; }

        public CurrentAccountDTO(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();

            this.MatKhau = row["MatKhau"].ToString();

            this.AccessLevel = row["AccessLevel"].ToString();

            this.IDTaiKhoan = (int)row["IDTaiKhoan"];
        }


        public CurrentAccountDTO() { }

    }
}


