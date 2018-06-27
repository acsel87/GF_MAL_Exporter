using Dapper;
using ExportLibrary.Models;
using System.Collections.Generic;
using System.Data;

namespace ExportLibrary.DataAccess
{
    public class SqlConnector : IListSource
    {
        private bool IsAdd { get; set; }
        private bool IsBackup { get; set; }

        public SqlConnector(bool isAdd = false, bool isBackup = true)
        {
            IsAdd = isAdd;
            IsBackup = isBackup;
        }

        public void CreateGF(List<GFModel> models)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("ExportList")))
            {
                var p = new DynamicParameters();

                if (IsBackup)
                {
                    connection.Execute("dbo.spGF_Backup", commandType: CommandType.StoredProcedure);
                }

                if (!IsAdd)
                {
                    connection.Execute("dbo.spGF_Clear", commandType: CommandType.StoredProcedure);
                }

                foreach (GFModel m in models)
                {                    
                    p.Add("@Name", m.Name);
                    p.Add("@Year", m.Year);
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spGF_Insert", p, commandType: CommandType.StoredProcedure);
                   
                    m.Id = p.Get<int>("@id");
                }
            }
        }

        public void CreateMAL(List<MALModel> models)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("ExportList")))
            {
                var p = new DynamicParameters();

                if (IsBackup)
                {
                    connection.Execute("dbo.spMAL_Backup", commandType: CommandType.StoredProcedure);
                }

                if (!IsAdd)
                {
                    connection.Execute("dbo.spMAL_Clear", commandType: CommandType.StoredProcedure);
                }

                foreach (MALModel m in models)
                {
                    p.Add("@Name", m.Name);
                    p.Add("@Status", m.Status);
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spMAL_Insert", p, commandType: CommandType.StoredProcedure);

                    m.Id = p.Get<int>("@id");
                }
            }
        }
    }
}