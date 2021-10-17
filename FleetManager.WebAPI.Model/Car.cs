using System;

namespace FleetManager.WebAPI.Model
{
    public class Car : BaseModel
    {
        public string Brand { get; set; }
        public int? Mileage { get; set; }
        public DateTime? Reserved { get; set; }
        public Location Location { get; set; }
    }
}
