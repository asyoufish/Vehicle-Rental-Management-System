using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TszFungChan
{
    public class Motorcycle : Vehicle
    {
        public enum Category
        {
            Cruiser,
            Sports,
            Dirt
        }

        public enum Type
        {
            Bike,
            Trike
        }

        public Category MotorCategory;
        public Type MotorType;

        public Motorcycle(int _ID, string name, double rentalPrice, Category motorCategory, Type motorType, bool isReserved) : base(_ID, name, rentalPrice, isReserved)
        {
            MotorCategory = motorCategory;
            MotorType = motorType;
        }

        public override string ToString()
        {
            return base.ToString() + $" {MotorCategory,-10} {MotorType,-10} {(IsReserved ? "No" : "Yes"),-10}";
        }

        public override string DisplayWOAvailable()
        {
            return base.DisplayWOAvailable() + $" {MotorCategory,-10} {MotorType,-10}";
        }
    }
}
