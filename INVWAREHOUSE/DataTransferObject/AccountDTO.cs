using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVWAREHOUSE.DTO
{
    public class AccountDTO
    {
            private int iDTaiKhoan;
            private string tenDangNhap;
            private string matKhau;
            private string accessLevel;

            /* 
             Nếu để Field là private Static thì sẽ bị lỗi giá trị row sau ghi đè giá trị row trước
            */

            public int IDTaiKhoan { get => iDTaiKhoan; set => iDTaiKhoan = value; }
            public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
            public string MatKhau { get => matKhau; set => matKhau = value; }
            public string AccessLevel { get => accessLevel; set => accessLevel = value; }

        public AccountDTO(int Id, string TKDN, string MK, string AL )
        {
            this.AccessLevel = AL;
            this.TenDangNhap = TKDN;
            this.MatKhau = MK;
            this.IDTaiKhoan = Id;
        }

        public AccountDTO(DataRow row)
        {
            
            this.TenDangNhap = row["TenDangNhap"].ToString();

            this.MatKhau = row["MatKhau"].ToString();

            this.AccessLevel = row["AccessLevel"].ToString();

            this.IDTaiKhoan = (int)row["IDTaiKhoan"];
        }
    }
}
