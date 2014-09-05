using Lucy.Handlers.MySql.CustomException;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Handlers.MySql
{
    public class MySqlDatabase : IDatabase
    {
        public MySqlDatabase(string connString)
        {
            if (connString == null || connString == string.Empty)
                throw new InvalidConnectionStringException();
            this.ConnectionString = connString;
        }

        public string ConnectionString { get; set; }
        
        public DataTable ExecuteCommand(DbCommand command)
        {
            using (var conn = new MySqlConnection(this.ConnectionString))
            {
                command.Connection = conn;
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }

        }


        public DbCommand CreateCommand(string query,string type)
        {
            using (var conn = new MySqlConnection(this.ConnectionString))
            {
                var Command = conn.CreateCommand();
                if (type.Equals("Query"))
                    Command.CommandType = CommandType.Text;
                else
                    Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = query;
                return Command;
            }
        }

    }
}
