using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVWAREHOUSE
{
    class DataProvider
    {

        private static DataProvider instance; 

        private string connectionSTR = @"Data Source =.\sqlexpress; Initial Catalog = invwarehouse; Integrated Security = True";

        

        public static DataProvider Instance // Accessor
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }

            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    var listpara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }

                    }
                }

                data = command.ExecuteScalar();

                conn.Close();

            }

            return data;
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    var listpara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                conn.Close();

            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }

                    }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

    }
}
