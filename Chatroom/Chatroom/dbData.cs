using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Data.SQLite;
namespace Chatroom
{
    public class dbData
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void SetConnection()
        {
            string fileName = "chatRoomUsers.db";
            string pathDB = HttpContext.Current.Server.MapPath("~/DataBase/" + fileName);
            //string pathDB = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DataBase/chatRoomUsers.db");
            sql_con = new SQLiteConnection
                ("Data Source="+ pathDB + ";Version=3;New=False;Compress=True;");
        }
        public int ExecuteNonQuery(string txtQuery)
        {
            int res = 0;
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = txtQuery;
                res = sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception)
            {
                sql_con.Close();
            }
            
            return res;
        }
        public DataSet ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = txtQuery;
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
             
            sql_con.Close();
            return DS;
        }

    }
}