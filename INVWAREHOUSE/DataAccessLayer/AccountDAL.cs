using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DTO;

namespace INVWAREHOUSE.DAO
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return AccountDAL.instance; }

            private set { AccountDAL.instance = value; }
        }

        private AccountDAL() { }

        public bool CheckAccountForLogin(string username, string password) // Có Sử Dụng
        {
            string query = "exec Usp_Login @usr , @pwd";

            DataTable D = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });

            if (D.Rows.Count > 0)

            {
                DataRow R = D.Rows[0];

                CurrentAccountDTO L = new CurrentAccountDTO(R);

                return true;

            }

            else
                return false;
        }

        public bool DeleteAccount(string username)
        {

            string query = "exec Usp_DeleteAccount @usr";

            int D = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username });

            if (D > 0)

                return true;

            else

                return false;
        }

        public string CheckAccountExistAndAccessLevel(string username)
        {

            string query = "exec Usp_CheckAccountExist @usr";

            DataTable D = DataProvider.Instance.ExecuteQuery(query, new object[] { username });

            if (D.Rows.Count > 0)

            {

                DataRow DL = D.Rows[0];

                AccountDTO L = new AccountDTO(DL);

                switch (L.AccessLevel)
                {
                    case "Admin":
                        return "Admin";

                    case "Manager":
                        return "Manager";

                    default:
                        return "Staff";
                }

            }

            else

                return "None";
        }

        public bool AddAccount(string username, string password, string accesslevel)
        {

            string query = "exec Usp_AddAccount @usr , @pwd , @acc";

            int D = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password, accesslevel });

            if (D == 2)

                return true;

            else

                return false;
        }

        public DataTable LoadAccountListByAccessLevel(string acc)
        {

            DataTable F = new DataTable();
            F.Columns.Add("ID");
            F.Columns.Add("TaiKhoan");
            F.Columns.Add("AccessLevel");

            string query = "exec Usp_LoadDanhSachTaiKhoan @acc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { acc });

            foreach (DataRow dtr in data.Rows)
            {
                AccountDTO L = new AccountDTO(dtr);

                F.Rows.Add(new object[] { L.IDTaiKhoan, L.TenDangNhap, L.AccessLevel });

            }
            return F;

        }

        public List<string> LoadAccessLevelType()
        {
            List<string> A = new List<string>();

            string query = "select * from TaiKhoanDangNhap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow dtr in data.Rows)
            {
                AccountDTO L = new AccountDTO(dtr);

                if (!A.Contains(L.AccessLevel))

                    A.Add(L.AccessLevel);
            }

            return A;

        }

        public bool ChangePassword(string username, string password)
        {

            string query = "exec Usp_ChangePassword @usr , @pwd";

            int D = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password });

            if (D == 1)

                return true;

            else

                return false;
        }

        public bool ResetPassword(string username, string password = null)
        {
            int D = 0;

            string query = "exec Usp_Resetpassword @usr , @pwd";

            if (password == null)
            {
                D = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, "1" });
            }
            else
            {
                D = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password });
            }

            if (D == 1)

                return true;

            else

                return false;
        }

        public bool EditInfo(int A, string Ten, string Tuoi, string Diachi, string SDT)
        {
            int E = 0;

            if (Ten != "") E++;
            if (Tuoi != "") E++;
            if (Diachi != "") E++;
            if (SDT != "") E++;

            int c = Convert.ToInt32(Tuoi);

            string query = "exec Usp_UpdateThongTin @ten , @tuoi , @dc , @SDT , @id";

            int D = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Ten,c,Diachi,SDT,A});

            if (D == E && D!=0)

                return true;

            else

                return false;
          
        }
    }
}
