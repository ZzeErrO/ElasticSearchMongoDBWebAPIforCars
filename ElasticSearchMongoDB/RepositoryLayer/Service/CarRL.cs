using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;
using MongoDB.Driver;
using RepositoryLayer.Interface;
using RepositoryLayer.Model;

namespace RepositoryLayer.Service
{
    public class CarRL : ICarRL
    {
        private readonly IMongoCollection<Car> _car;
        public CarRL(ICarDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _car = database.GetCollection<Car>(settings.CarsCollectionName);
        }
        
        public List<Car> Get()
        {
            try
            {
                var cars =  this._car.Find(car => true).ToList();

                return cars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Car Get(string id)
        {
            try
            {
                return this._car.Find<Car>(car => car.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Car Create(Car car)
        {
            try
            {
                this._car.InsertOne(car);
                return car;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Car carIn)
        {
            try
            {
                this._car.DeleteOne(car => car.Id == carIn.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(string id)
        {
            try
            {
                this._car.DeleteOne(car => car.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(string id, Car carIn)
        {
            try
            {
                this._car.ReplaceOne(car => car.Id == id, carIn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
