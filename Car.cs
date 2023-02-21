using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TszFungChan
{
    public class Car : Vehicle
    {
        public enum Category
        {
            Hatchback,
            Sedan,
            SUV,
            Sports
        }

        public enum Type
        {
            Standard,
            Exotic
        }

        public Category CarCategory;
        public Type CarType;

        public Car(int _ID, string name, double rentalPrice, Category carCategory, Type carType, bool isReserved) : base(_ID, name, rentalPrice, isReserved)
        {
            CarCategory = carCategory;
            CarType = carType;
        }

        public override string ToString()
        {
            return base.ToString() + $" {CarCategory, -10} {CarType, -10} {(IsReserved? "No":"Yes"), -10}";
        }

        public override string DisplayWOAvailable()
        {
            return base.DisplayWOAvailable() + $" {CarCategory,-10} {CarType,-10}";
        }
    }
}
