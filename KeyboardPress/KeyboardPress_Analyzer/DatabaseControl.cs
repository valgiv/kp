﻿using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    public static class DatabaseControl
    {
        public static List<ObjWin> WindowsList = new List<ObjWin>();

        public static Tuple<int, string>[] GetWindowsByIds(int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                    return null;

                return WindowsList.Where(x => ids.Contains(x.record_id)).Select(x => new Tuple<int, string>(x.record_id, x.proc_name)).ToArray();
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public static Tuple<int, string>[] GetWindowsIdsByProcName(string[] procNames)
        {
            try
            {
                if (procNames == null || procNames.Length == 0)
                    return null;
                
                return WindowsList.Where(x => procNames.Contains(x.proc_name)).Select(x => new Tuple<int, string>(x.record_id, x.proc_name)).ToArray();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public static void ReloadWindowsList()
        {
            try
            {
                var dt = DBHelper.GetDataTableDb("SELECT record_id, proc_name FROM KP_WINDOWS");
                if (dt == null)
                    throw new Exception($"Failled {nameof(DatabaseControl)}.{nameof(ReloadWindowsList)}");

                WindowsList = new List<ObjWin>();

                dt.AsEnumerable().ToList().ForEach(x => WindowsList.Add(new ObjWin()
                {
                    record_id = x.Field<int>("record_id"),
                    proc_name = x.Field<string>("proc_name")
                }));
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public static void SaveWindows(string[] proccessNames)
        {
            try
            {
                string sql = "";

                proccessNames.Distinct().Where(x => !(WindowsList.Select(y => y.proc_name).ToArray()).Contains(x)).ToList().ForEach(x =>
                {
                    sql += $"INSERT INTO KP_WINDOWS (proc_name) VALUES ('{x.ToString()}') ";
                });

                var result = DBHelper.ExecSqlDb(sql, true);
                if (result != "OK")
                    throw new Exception($"Failled {nameof(DatabaseControl)}.{nameof(SaveWindows)} {result} (sql: {sql})");

                ReloadWindowsList();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

    }
}
