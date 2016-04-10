using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vehicle
{

    class Helicopter : IVehicle
    {
        int _fuelConsumptionPer100km
        {
            set
            {
                if (value < 100)
                    throw new InvalidOperationException("!");
                _fuelConsumptionPer100km = value;
            }
            get { return _fuelConsumptionPer100km; }
        }



        string _modelName = "Helicopter";

        string IVehicle.ModelName

        {
            set { _modelName = value; }
            get { return _modelName; }
        }

        int _dateOfManufacture;


        int IVehicle.DateOfManufacture
        {
            set
            {
                if (value < 1980)
                    throw new InvalidOperationException("!");
                _dateOfManufacture = value;
            }
            get { return _dateOfManufacture; }
        }

        int _distance;
        int IVehicle.Distance
        {
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("!");
                _distance = value;
            }

            get { return _distance; }
        }

    }
}