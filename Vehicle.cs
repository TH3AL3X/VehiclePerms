using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePerms
{
    public sealed class Vehicle
    {
        public string GroupPermission;
        public ushort id;
        public bool RemoveFromTheGroupAfterLeave;

        public Vehicle()
        {
        }

        public Vehicle(string GroupPermissions, ushort ids, bool RemoveFromTheGroupAfterLeaves)
        {
            GroupPermissions = GroupPermission;
            id = ids;
            RemoveFromTheGroupAfterLeaves = RemoveFromTheGroupAfterLeave;
        }
    }
}