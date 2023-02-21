using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TszFungChan
{
    public abstract class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double RentalPrice { get; set; }
        public bool IsReserved { get; set; }
        
        public Vehicle(int _ID, string name, double rentalPrice, bool isReserved)
        {
            ID = _ID;
            Name = name;
            RentalPrice = rentalPrice;
            IsReserved = isReserved;
        }

        public void ReserveVehicle()
        {
            IsReserved = true;
        }

        public void CancelReserve()
        {
            IsReserved = false;
        }

        public override string ToString()
        {
            return $"{ID, 10} {Name, -30} {RentalPrice, 13}";
        }

        public virtual string DisplayWOAvailable()
        {
            return $"{ID,10} {Name,-30} {RentalPrice,13}";
        }
    }
}
