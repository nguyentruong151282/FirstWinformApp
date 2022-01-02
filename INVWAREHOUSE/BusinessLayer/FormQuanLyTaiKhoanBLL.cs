using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVWAREHOUSE.DAO;
using INVWAREHOUSE.DataAccessLayer;
using INVWAREHOUSE.DataTransferObject;
using INVWAREHOUSE.DTO;

namespace INVWAREHOUSE.BusinessLayer
{
    class FormQuanLyTaiKhoanBLL
    {
        private static FormQuanLyTaiKhoanBLL instance;

        public static FormQuanLyTaiKhoanBLL Instance
        {
            get { if (instance == null) instance = new FormQuanLyTaiKhoanBLL(); return FormQuanLyTaiKhoanBLL.instance; }

            private set { FormQuanLyTaiKhoanBLL.instance = value; }
        }

        private FormQuanLyTaiKhoanBLL() { }

        public DataTable LoadAccountList(string acc)
        {
            return AccountDAL.Instance.LoadAccountListByAccessLevel(acc);
        }

        public List<String> LoadAccessLevelType()
        {
            List<string> A = new List<string>();

            A.Add("Tất Cả");

            foreach (var i in AccountDAL.Instance.LoadAccessLevelType())

                A.Add(i);

            return A;
        }

        public List<string> LoadCurrentAccountInfo()
        {
            List<string> A = new List<string>();

            CurrentAccountDTO F = new CurrentAccountDTO();

            A.Add(F.TenDangNhap);

            A.Add(F.AccessLevel);

            A.Add(F.MatKhau);

            A.Add(F.IDTaiKhoan.ToString());

            return A;
        }

        public string SelectingAccountID(DataGridViewRow row)
        {
            return row.Cells[0].Value.ToString();
        }

        public string SelectingAccountTenTK(DataGridViewRow row)
        {
            return row.Cells[1].Value.ToString();
        }

        public List<string> LoadInfoAccountWithID(string id)
        {

            return ThongTinTaiKhoanDAL.Instance.LoadInfoAccountWithID(id);

        }

        public int AddAccountPopup(string TKDN, string MK, string Access)
        {
            string A = Instance.LoadCurrentAccountInfo()[1]; // quyền truy cập của tài khoản hiện tại

            if (Access == "Manager" && A == "Manager")

                return -1; 

            else
            {
                if (AccountDAL.Instance.CheckAccountExistAndAccessLevel(TKDN) != "None") return -2;

                else
                {
                    if (AccountDAL.Instance.AddAccount(TKDN, MK, Access)) return 1;

                    else return -3;
                }
            }    
        }

        public int RemoveAccountPopup(string TKDN)
        {


            string P = LoadCurrentAccountInfo()[1]; // lấy quyền truy cập tài khoản hiện tại


            if (P == "Staff") return 0; // Tài Khoản Staff 


            else if (P == "Manager")
            {

                if (AccountDAL.Instance.CheckAccountExistAndAccessLevel(TKDN) != "Staff")

                    return 1; //Tài Khoản Manager nhưng Tài Khoản cần xóa không phải Staff

                else
                {
                    if (AccountDAL.Instance.DeleteAccount(TKDN))

                        return 10; // Thành Công

                    else

                        return 11; //Lỗi
                }

            }

            else
            {
                if (AccountDAL.Instance.CheckAccountExistAndAccessLevel(TKDN) == "Admin")

                    return 12; // Lỗi tài Khoản Admin là duy nhất

                else
                {
                    if (AccountDAL.Instance.DeleteAccount(TKDN))

                        return 10; // Thành Công

                    else

                        return 11; //Lỗi
                }

            }

        }

        public int ChangePasswordPopup(string MKCU ,string MKMOI)
        {
            string A = LoadCurrentAccountInfo()[0]; // Lấy Tên Tài Khoản Hiện Tại

            string B = LoadCurrentAccountInfo()[2]; // Lấy MK cũ để so sánh

            if ( B != MKCU) return -1; // sai mật khẩu cũ
            
            else
            {
                if (AccountDAL.Instance.ChangePassword(A, MKMOI)) return 1;

                else
                    return 0;
            }

        }

        public int ResetPasswordPopup(string TKDN)
        {
            string A = LoadCurrentAccountInfo()[1]; // Lấy Quyền Truy Cập Tài Khoản Hiện Tại

            if (A != "Admin") return -1;

            else
            {
                if (AccountDAL.Instance.ChangePassword(TKDN, "1")) return 1;

                else return -2;
            }
      
        }

        public bool EditInfo(string Ten, string Tuoi, string Diachi, string SDT, string id)
        {
            int A = Convert.ToInt16(id); // ID Tài Khoản

            return AccountDAL.Instance.EditInfo(A, Ten, Tuoi, Diachi, SDT);

        }
    }
    
}
