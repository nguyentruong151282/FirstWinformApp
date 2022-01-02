using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVWAREHOUSE.DAO;

namespace INVWAREHOUSE.BusinessLayer
{
    public class FormLoginBLL
    {
        private static FormLoginBLL instance;

        public static FormLoginBLL Instance
        {
            get { if (instance == null) instance = new FormLoginBLL(); return FormLoginBLL.instance; }

            private set { FormLoginBLL.instance = value; }
        }

        private FormLoginBLL() { }

        public bool Login(string usr, string pwd)
        {
            return AccountDAL.Instance.CheckAccountForLogin(usr, pwd);
        }
    }
}
