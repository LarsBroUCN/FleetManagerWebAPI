using FleetManager.WebAPI.Data.Daos.Rest.Dto;
using FleetManager.WebAPI.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.WebAPI.Data.Daos.Rest
{
    // TODO: (Step 4) implement data access object for the Locations resource in the FleetManager WebAPI

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Location model class as type parameter

    class LocationDao : BaseDao<IDataContext<IRestClient>>, IDao<Location>
    {
        public LocationDao(IDataContext<IRestClient> dataContext) : base(dataContext)
        {
        }

        public Location Create(Location model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/location", Method.POST);
            request.AddParameter("Name", model.Name);

            IRestResponse<IEnumerable<LocationDto>> response = client.Post<IEnumerable<LocationDto>>(request);



            return model; //TODO Should return from database, response LocationDta to Location
        }

        public bool Delete(Location model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/location/{id}", Method.DELETE);
            request.AddUrlSegment("id", model.Id);

            IRestResponse<IEnumerable<LocationDto>> response = client.Post<IEnumerable<LocationDto>>(request);

            return false; //TODO Should return from correct response currently only returns false
        }

        public IEnumerable<Location> Read()
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/locations", Method.GET);

            IRestResponse<IEnumerable<LocationDto>> response = client.Get<IEnumerable<LocationDto>>(request);

            List<Location> result = new();

            foreach (LocationDto location in response.Data)
            {
                result.Add(location.Map());
            }

            return result;
        }

        public IEnumerable<Location> Read(Func<Location, bool> predicate) //Get all a choose one, bad for larger databases
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/locations", Method.GET);

            IRestResponse<IEnumerable<LocationDto>> response = client.Get<IEnumerable<LocationDto>>(request);

            List<Location> result = new();

            foreach (LocationDto location in response.Data)
            {
                result.Add(location.Map());
            }

            return result.Where(predicate);
        }

        public bool Update(Location model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/location/{id}", Method.PUT);
            request.AddUrlSegment("id", model.Id);
            request.AddParameter("Name", model.Name);

            IRestResponse<IEnumerable<LocationDto>> response = client.Post<IEnumerable<LocationDto>>(request);

            return false; //TODO Should return from correct response currently only returns false
        }
    }
}
