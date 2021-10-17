using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.WebAPI.Data.Daos
{
    /// <summary>
    /// Dao super class that ensures the IDataContext is provided when a new dao is instantiated
    /// </summary>
    /// <typeparam name="TDataContext"></typeparam>
    class BaseDao<TDataContext> : IDataContext
    {
        protected TDataContext DataContext { get; }

        public BaseDao(TDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
