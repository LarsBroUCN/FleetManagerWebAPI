using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.WebAPI.Data
{

    [Serializable]
    public class DaoFactoryException : Exception
    {
        public DaoFactoryException() { }
        public DaoFactoryException(string message) : base(message) { }
        public DaoFactoryException(string message, Exception inner) : base(message, inner) { }
        protected DaoFactoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
