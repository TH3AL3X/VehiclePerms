using Rocket.API;
using Rocket.API.Collections;
using Rocket.API.Serialisation;
using Rocket.Core;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Framework.UI.Devkit;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace VehiclePerms
{
    public class VehiclePerms : RocketPlugin<VehicleConfig>
    {
        public static VehiclePerms Instance;

        public static VehicleConfig Config;

        protected override void Load()
        {
            Instance = this;

            VehicleManager.onEnterVehicleRequested += OnEnterVehicle;
            VehicleManager.onExitVehicleRequested += OnLeaveVehicle;
        }


        private void OnLeaveVehicle(Player player, InteractableVehicle vehicle, ref bool cancel, ref Vector3 pendingLocation, ref float pendingYaw)
        {
            foreach (Vehicle vehiclegroups in VehiclePerms.Config.Vehicle)
            {
                UnturnedPlayer playerextrapolate = UnturnedPlayer.FromPlayer(player);
                if (vehicle.id == vehiclegroups.id && vehiclegroups.RemoveFromTheGroupAfterLeave)
                    R.Permissions.RemovePlayerFromGroup(vehiclegroups.GroupPermission, playerextrapolate);
            }
        }

        private void OnEnterVehicle(Player player, InteractableVehicle vehicle, ref bool cancel)
        {
            foreach (Vehicle vehiclegroups in VehiclePerms.Config.Vehicle)
            {
                UnturnedPlayer playerextrapolate = UnturnedPlayer.FromPlayer(player);
                if (vehicle.id == vehiclegroups.id)
                    R.Permissions.AddPlayerToGroup(vehiclegroups.GroupPermission, playerextrapolate);
            }
        }

        protected override void Unload()
        {
                VehicleManager.onEnterVehicleRequested -= OnEnterVehicle;
                VehicleManager.onExitVehicleRequested -= OnLeaveVehicle;
        }
    }
}
