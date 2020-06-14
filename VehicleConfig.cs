using Rocket.API;
using System;
using System.Collections.Generic;

namespace VehiclePerms
{
    public class VehicleConfig : IRocketPluginConfiguration
    {
        public List<Vehicle> Vehicle;

        public void LoadDefaults()
        {
            this.Vehicle = new List<Vehicle>()
            {
                new Vehicle("default", 77, false),
                new Vehicle("vip", 12, true)
            };
        }
    }
}