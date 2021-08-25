using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SalesWebMvc.Data
{
    public class bd
    {
        private string _connectionString = @"Integrated Security=False;
        Data Source=.\WORKBENCH;
        Initial Catalog=ControleVendas; userid=developer;password=1234567 ;";

        public DataTable retornaDataTable<T>(string query) where T : IDbConnection, new()
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    var table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
            }
        }
    }
}
