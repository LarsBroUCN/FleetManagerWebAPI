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
    // TODO: (Step 4) implement data access object for the Cars resource in the FleetManager WebAPI

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Car model class as type parameter

    class CarDao : BaseDao<IDataContext<IRestClient>>, IDao<Car>
    {
        public CarDao(IDataContext<IRestClient> dataContext) : base(dataContext)
        {

        }

        public Car Create(Car model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/cars", Method.POST);
            request.AddParameter("Brand", model.Brand);
            request.AddParameter("Mileage", model.Mileage);
            request.AddParameter("Location", model.Location);

            IRestResponse<IEnumerable<CarDto>> response = client.Post<IEnumerable<CarDto>>(request);

            return model; //TODO Should return from database, response CarDta to Car
        }

        public bool Delete(Car model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/Cars/{id}", Method.DELETE);
            request.AddUrlSegment("id", model.Id);

            IRestResponse<IEnumerable<CarDto>> response = client.Post<IEnumerable<CarDto>>(request);

            return false; //TODO Should return from correct response currently only returns false
        }

        public IEnumerable<Car> Read()
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/cars", Method.GET);

            IRestResponse<IEnumerable<CarDto>> response = client.Get<IEnumerable<CarDto>>(request);

            List<Car> result = new();

            foreach (CarDto car in response.Data)
            {
                result.Add(car.Map());
            }

            return result;
        }

        public IEnumerable<Car> Read(Func<Car, bool> predicate) //Get all a choose one, bad for larger databases
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/cars", Method.GET);

            IRestResponse<IEnumerable<CarDto>> response = client.Get<IEnumerable<CarDto>>(request);

            List<Car> result = new();

            foreach (CarDto car in response.Data)
            {
                result.Add(car.Map());
            }

            return result.Where(predicate);
        }

        public bool Update(Car model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/Cars/{id}", Method.PUT);
            request.AddUrlSegment("id", model.Id);
            request.AddParameter("Brand", model.Brand);
            request.AddParameter("Mileage", model.Mileage);
            request.AddParameter("Location", model.Location);

            IRestResponse<IEnumerable<CarDto>> response = client.Post<IEnumerable<CarDto>>(request);

            return false; //TODO Should return from correct response currently only returns false
        }
    }
}
