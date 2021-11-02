using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.WebAPI.Data.Daos.Rest.Dto
{
    class CarDto
    {
        public string Href { get; set; }
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public string LocationHref { get; set; }
    }
}
