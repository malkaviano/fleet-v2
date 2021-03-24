using System;
using System.Collections.Generic;

namespace Business
{
    public abstract class Vehicle
    {
        private string chassis;

        public string Chassis
        {
            get { return this.chassis; }
            protected set
            {
                if (value is null)
                {
                    throw new Exception("Chassis cannot be null");
                }

                this.chassis = value;
            }
        }

        private string color;

        public string Color
        {
            get { return this.color; }
            protected set
            {
                if (value is null)
                {
                    throw new Exception("Color cannot be null");
                }

                this.color = value;
            }
        }

        public VehicleCategory Category { get; protected set; }

        public byte Passenger { get; protected set; }
    }
}
