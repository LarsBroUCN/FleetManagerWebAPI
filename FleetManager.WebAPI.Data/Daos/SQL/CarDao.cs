using FleetManager.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FleetManager.WebAPI.Data.Daos.SQL
{
    // TODO: (Step 4) implement data access object for the Cars table in the SQL Server database

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Car model class as type parameter

    class CarDao : BaseDao<IDataContext<IDbConnection>>, IDao<Car>
    {
        public CarDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
        {
            
        }

        public Car Create(Car model)
        {

            String quary = "INSERT INTO Cars (Brand, Mileage, Reserved) VALUES (@Brand, @Mileage, @Reserved,)"; // TODO Missing location
            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope
            connection.Query<Car>(quary, new { brand = model.Brand, mileage = model.Mileage, reserved = model.Reserved,}); //.First();
            return model;
        }

        public bool Delete(Car model)
        {
            String quary = "DELETE FROM Cars WHERE Id = @id";
            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope
            return !(connection.Query<Car>(quary, new {id = model.Id}).Any());
        }

        public IEnumerable<Car> Read()
        {
            String quary = "SELECT * FROM Cars";

            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope

            return connection.Query<Car>(quary);
        }

        public IEnumerable<Car> Read(Func<Car, bool> predicate)
        {
            String quary = "SELECT * FROM Cars";

            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope

            return connection.Query<Car>(quary).Where(predicate);
        }

        public IEnumerable<Car> Read(int id)
        {

            return null;
        }

        public bool Update(Car model)
        {
            bool temp = false;
            String quary = "SELECT* FROM Cars";
            using IDbConnection connection = DataContext.Open(); //By using "using", the connection objekt gets disposed after it leaves scope
            if (model.Brand != null)
            {
                quary = "Update Cars Set Brand = @Brand WHERE id = @Id";
                temp = connection.Query<Car>(quary, new { id = model.Id, brand = model.Brand }).Any();
            }
            if (model.Mileage != null)
            {
                quary = "Update Cars Set Mileage = @Mileage WHERE id = @Id";
                temp = connection.Query<Car>(quary, new { id = model.Id, mileage = model.Mileage }).Any();
            }
            else
            {
                quary = "Update Cars Set Mileage = @Mileage WHERE id = @Id";
                connection.Query<Car>(quary, new { id = model.Id, mileage = 0 }).Any();
            }
            if (model.Reserved != null)
            {
                quary = "Update Cars Set Reserved = @Reserved WHERE id = @Id";
                temp = connection.Query<Car>(quary, new { id = model.Id, reserved = model.Reserved }).Any();
            }
            if (model.Location != null) // TODO Virker ikke
            {
                quary = "Update Cars Set Location = @Location WHERE id = @Id";
                temp = connection.Query<Car>(quary, new { location = model.Location }).Any();
            }
            return temp;
        }
    }
}
