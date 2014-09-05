using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Handlers.MySql
{
    public interface IDatabase
    {
        DataTable ExecuteCommand(DbCommand query);
        DbCommand CreateCommand(string query,string type);
    }
}
