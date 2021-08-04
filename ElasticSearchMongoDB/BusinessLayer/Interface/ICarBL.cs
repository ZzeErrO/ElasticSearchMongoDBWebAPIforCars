using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace BusinessLayer.Interface
{
    public interface ICarBL
    {
        public List<Car> Get();
        public Car Get(string id);
        public Car Create(Car car);
        public void Update(string id, Car carIn);
        public void Remove(Car carIn);
        public void Remove(string id);
    }
}
