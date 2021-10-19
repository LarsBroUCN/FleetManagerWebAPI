using FleetManager.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.WebAPI
{
    public class SQLServerDataContext : IDataContext<IDbConnection>
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FleetManager;Integrated Security=True";

        public IDbConnection Open()
        {
            SqlConnection connection = new(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
