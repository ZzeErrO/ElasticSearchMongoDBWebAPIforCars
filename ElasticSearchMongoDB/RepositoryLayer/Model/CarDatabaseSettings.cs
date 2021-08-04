using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Model
{
    public class CarDatabaseSettings : ICarDatabaseSettings
    {
        public string CarsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICarDatabaseSettings
    {
        string CarsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
