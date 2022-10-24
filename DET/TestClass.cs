using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tibero.DbAccess;

namespace DET
{
    class TestClass
    {
        public static string resultID = string.Empty;
        public static string resultPW = string.Empty;
        public static string resultNM = string.Empty;
        public static string resultAGE = string.Empty;

        public static string strconn = "Provider = tbprov.Tbprov.6; Location=127.0.0.1,8640; Data Source = tiberia; User ID = Yoon; Password=9598";

        public static string[] ContainerC(string sql)
        {

            Tibero.DbAccess.OleDbConnectionTbr conn = new OleDbConnectionTbr(strconn);

            try
            {
                conn.Open();

                Tibero.DbAccess.OleDbCommandTbr cmd1 = new OleDbCommandTbr();

                cmd1.CommandText = sql;
                cmd1.Connection = conn;

                OleDbDataReader reader1 = cmd1.ExecuteReader();

                List<string> list = new List<string>();

                if (reader1.Read())
                {
                    for (int i = 0; i < reader1.FieldCount; i++)
                    {
                        list.Add(reader1[i].ToString());
                    }
                }

                conn.Close();

                string[] arySQLResult = list.ToArray();

                if (arySQLResult.Length > 0)
                {

                    resultID = arySQLResult[0].ToString();
                    resultPW = arySQLResult[1].ToString();
                    resultNM = arySQLResult[2].ToString();
                    resultAGE = arySQLResult[3].ToString();

                }


                return arySQLResult;
            }
            catch (Exception)
            {
                conn.Close();

                throw;
            }
        }

        public static string[] GetUserInfo()
        {
            string[] strarry = { resultID, resultPW, resultNM, resultAGE };
            return strarry;
        }

        public static DataTable SelectData(string sql)
        {
            try
            {
                DataTable dtresult = new DataTable();

                Tibero.DbAccess.OleDbConnectionTbr conn = new OleDbConnectionTbr(strconn);
                conn.Open();

                Tibero.DbAccess.OleDbCommandTbr cmd1 = new OleDbCommandTbr();

                cmd1.CommandText = sql;
                cmd1.Connection = conn;

                OleDbDataReader reader = cmd1.ExecuteReader();

                dtresult.Load(reader);

                return dtresult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string[] ContaienrD(string sql)
        {
            Tibero.DbAccess.OleDbConnectionTbr conn = new OleDbConnectionTbr(strconn);

            try
            {
                conn.Open();

                Tibero.DbAccess.OleDbCommandTbr cmd1 = new OleDbCommandTbr();

                cmd1.CommandText = sql;
                cmd1.Connection = conn;

                OleDbDataReader reader1 = cmd1.ExecuteReader();

                List<string> list = new List<string>();

                if (reader1.Read())
                {
                    for (int i = 0; i < reader1.FieldCount; i++)
                    {
                        list.Add(reader1[i].ToString());
                    }
                }

                conn.Close();
                string[] arySQLResult = list.ToArray();
                return arySQLResult;
            }
            catch (Exception)
            {
                conn.Close();

                throw;
            }

        }

        //public static string[] ContainerE(string CR)
        //{
        //    Tibero.DbAccess.OleDbConnectionTbr conn = new OleDbConnectionTbr(strconn);
        //    try
        //    {
        //        conn.Open();

        //        Tibero.DbAccess.OleDbCommandTbr cmd1 = new OleDbCommandTbr();

        //        cmd1.CommandText = CR;
        //        cmd1.Connection = conn;

        //        OleDbDataReader reader1 = cmd1.ExecuteReader();

        //        List<string> CRC = new List<string>();
        //        if (reader1.Read())
        //        {
        //            for (int i = 0; i < reader1.FieldCount; i++)
        //            {
        //                CRC.Add(reader1[i].ToString());
        //            }

        //        }
        //        conn.Close();
        //        string[] CRCSQLResult = CRC.ToArray();
        //        return CRCSQLResult;
        //    }
        //    catch
        //    {

        //    }
        //}
        /// <summary>
        /// //////////////////////////////////////////////////////접속 테스트 구역////////////////////////////////////////////////////////////////
        /// </summary>
        public class Data
        {
            public string Data1 { get; private set; }
            public string Data2 { get; private set; }
            public string Data3 { get; private set; }
            public string Data4 { get; private set; }

            public static string strconn = "Provider = tbprov.Tbprov.6; Location=127.0.0.1,8640; Data Source = tiberia; User ID = Yoon; Password=9598";
            public Data(string data1, string data2, string data3, string data4)
            {
                this.Data1 = data1;
                this.Data2 = data2;
                this.Data3 = data3;
                this.Data4 = data4;

            }


        }

    }
}
