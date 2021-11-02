using FleetManager.WebAPI.Model;
using System.Collections.Generic;

namespace FleetManager.WebAPI.Data
{
    public interface IDataContext
    {

    }

    /// <summary>
    /// Interface for generic connections to a datasource
    /// </summary>
    /// <typeparam name="TConnection">Type of connection (e.g., IDbConnection for a database connection)</typeparam>
    public interface IDataContext<TConnection> : IDataContext //Cann be changed depending on client and webclient
    {
        TConnection Open();
    }

    public interface ITypedDataContext : IDataContext
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Location> Locations { get; }

        Car Add(Car car);
        Location Add(Location location);

        bool Remove(Car car);
        bool Remove(Location location);
    }
}
