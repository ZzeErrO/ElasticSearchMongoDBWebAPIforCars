using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace RepositoryLayer.Interface
{
    public interface ICarRL
    {
        public List<Car> Get();
        public Car Get(string id);
        public Car Create(Car car);
        public void Update(string id, Car carIn);
        public void Remove(Car carIn);
        public void Remove(string id);
    }
}
