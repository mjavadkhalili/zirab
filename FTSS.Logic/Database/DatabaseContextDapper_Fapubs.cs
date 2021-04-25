﻿using FTSS.Models.Database;
using FTSS.Models.Database.StoredProcedures;
using FTSS.Models.Database.StoredProcedures.Fapubs.Prsn;
using System;

namespace FTSS.Logic.Database
{
	public class DatabaseContextDapper_Fapubs: IDatabaseContextDapper_Fapubs
    {
        #region properties
        private string _connectionString { get; set; }

        private string GetConnectionString()
        {
            return _connectionString;
        }
        #endregion properties

        private readonly DP.DapperORM.BaseSP<SP_User_Login.Inputs, SP_User_Login.Outputs> _SP_User_Login;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ConnectionString"></param>
        public DatabaseContextDapper_Fapubs(string ConnectionString, DP.DapperORM.ISqlExecuter executer = null)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new ArgumentNullException("رشته اتصال به دیتابیس یافت نشد!");

            _connectionString = ConnectionString;
            if (executer == null)
                executer = new DP.DapperORM.SqlExecuter(GetConnectionString());
            _SP_User_Login = new DP.DapperORM.BaseSP<SP_User_Login.Inputs, SP_User_Login.Outputs>("Prsn.SP_User_Login", executer);
      
        }


        #region SPs
        public DBResult SP__User_Login(SP_User_Login.Inputs inputs)
        {
            var rst = _SP_User_Login.Single(inputs);
            return rst;
        }
        #endregion SPs
    }
}
