using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pattern.AbstractFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FordCar carFord = (FordCar)new CarFactory(CarBrand.Ford).Create();
            Console.WriteLine($"Created car {carFord.GetBrand()}");

            SeatCar carSeat = (SeatCar)new CarFactory(CarBrand.Seat).Create();
            Console.WriteLine($"Created car {carSeat.GetBrand()}");

            Console.ReadKey();
        }
    }

    interface IVehicle
    {
        string GetBrand();
    }

    interface ICar : IVehicle
    {
    }

    interface IVehicleFactory
    {
        IVehicle Create();
    }

    class CarFactory : IVehicleFactory
    {
        private CarBrand Brand;

        Dictionary<CarBrand, Type> brandMap = new Dictionary<CarBrand, Type>
        {
            { CarBrand.Ford, typeof(FordCar) },
            { CarBrand.Seat, typeof(SeatCar) }
        };
        
        public CarFactory(CarBrand brand)
        {
            this.Brand = brand;
        }

        public IVehicle Create()
        {
            return (ICar)Activator.CreateInstance(this.brandMap[this.Brand]);
        }
    }

    class FordCar : ICar
    {
        public string GetBrand()
        {
            return "Ford";
        }
    }

    class SeatCar : ICar
    {
        public string GetBrand()
        {
            return "Seat";
        }
    }

    enum CarBrand
    {
        Ford,
        Seat
    }

}
