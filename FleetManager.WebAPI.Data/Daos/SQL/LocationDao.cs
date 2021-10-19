using Dapper;
using FleetManager.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.WebAPI.Data.Daos.SQL
{
    // TODO: (Step 4) implement data access object for the Locations table in the SQL Server database

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Location model class as type parameter

    class LocationDao : BaseDao<IDataContext<IDbConnection>>, IDao<Location>
    {
        public LocationDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
        {
        }

        public Location Create(Location model)
        {
            String quary = "INSERT * INTO Locations";
            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope
            return connection.Query<Location>(quary).First();
        }

        public bool Delete(Location model)
        {
            String quary = "Delete Locations Where Id = @Id";
            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope
            return !(connection.Query<Location>(quary).Any());
        }

        IEnumerable<Location> IDao<Location>.Read()
        {
            String quary = "SELECT * FROM Locations";

            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope

            return connection.Query<Location>(quary);
        }

        public IEnumerable<Location> Read(Func<Location, bool> predicate)
        {
            String quary = "SELECT * FROM Locations";

            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope

            return connection.Query<Location>(quary).Where(predicate);
        }

        public bool Update(Location model)
        {
            String quary = "Update Locations Where Id = @Id";
            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope
            return connection.Query<Location>(quary).Any();
        }
    }
}
