﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace KeyboardPress_Analyzer.Helper
{
    public static class DBHelper
    {
        private static Guid userId;
        private static string connStr;

        private static string ConnStr
        {
            get
            {
                if (String.IsNullOrWhiteSpace(connStr))
                    connStr = $@"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}kpData.mdf;
Integrated Security=True";
                return connStr;
            }
        }
        public static Guid UserId
        {
            get
            {
                if(userId == null || userId == new Guid())
                {
                    userId = SelectTopRow<Guid>("SELECT TOP 1 guid_id FROM KP_USER");
                }
                if(userId == null || userId == new Guid())
                {
                    var tmp = Guid.NewGuid();
                    if (ExecSqlDb($"INSERT INTO KP_USER (guid_id, name) VALUES ('{tmp}', '{tmp}')", true) != "OK")
                        throw new Exception("Klaida duomenų bazėje, nepavyksta sukurti vartotojo");
                    userId = SelectTopRow<Guid>("SELECT TOP 1 guid_id FROM KP_USER");

                    if (userId != tmp)
                        throw new Exception("Klaida. Nepavyksta gauti vartotojo");
                }
                
                return userId;
            }
        }

        private static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnStr);
            return conn;
        }

        public static bool TestConnection()
        {
            try
            {
                using(var conn = GetConnection())
                {
                    conn.Open();

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static DataSet GetDataSetDb(string sql)
        {
            try
            {
                var ds = new DataSet();
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var sda = new SqlDataAdapter(sql, conn);
                    sda.Fill(ds);

                    conn.Close();
                }
                return ds;
            }
            catch(Exception ex)
            {
                throw new Exception("Klaida naudojantis duomenų baze: " + ex.Message.ToString());
            }
        }

        public static DataTable GetDataTableDb(string sql)
        {
            try
            {
                var dt = new DataTable();
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var sda = new SqlDataAdapter(sql, conn);
                    sda.Fill(dt);

                    conn.Close();
                }
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception("Klaida naudojantis duomenų baze: " + ex.Message.ToString());
            }
        }

        public static string ExecSqlDb(string sql, bool silentMode)
        {
            string result = "OK";
            try
            {
                using(var conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand comand = new SqlCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                if (silentMode)
                    result = "Klaida naudojantis duomenų baze: " + ex.Message.ToString();
                else
                    throw new Exception("Klaida naudojantis duomenų baze: " + ex.Message.ToString());
            }

            return result;
        }

        public static T SelectTopRow<T>(string sql)
        {
            var dt = GetDataTableDb(sql);
            if (dt == null || dt.Rows.Count == 0)
                return default(T);

            return (T)dt.Rows[0][0];
        }
    }
}