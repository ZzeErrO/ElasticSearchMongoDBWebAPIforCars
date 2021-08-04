using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class CarBL : ICarBL
    {
        readonly ICarRL carRL;
        public CarBL(ICarRL carRL)
        {
            this.carRL = carRL;
        }

        public List<Car> Get()
        {
            try
            {
                return this.carRL.Get();
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
            return this.carRL.Get(id);
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
                return this.carRL.Create(car);
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
                this.carRL.Remove(carIn);
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
                this.carRL.Remove(id);
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
                this.carRL.Update(id, carIn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
