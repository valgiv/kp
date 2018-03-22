﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    interface IDatabase
    {
        void Db_SaveChanges();

        void Db_LoadData();

        void Db_DelateDataFromDatabase();

        void Db_DeleteDataFromLocalMemory();
    }
}