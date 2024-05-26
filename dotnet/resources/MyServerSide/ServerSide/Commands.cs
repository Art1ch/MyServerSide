using GTANetworkAPI;
using ServerSide.CommandAttributes;
using System;

namespace ServerSide
{
    public class Commands : Script
    {
        [Command("veh")]
        public void CreateVehicle(Player player, string veh_name = "adder")
        {
            var user_veh = NAPI.Util.VehicleNameToModel(veh_name);
            NAPI.Vehicle.CreateVehicle(user_veh, player.Position, player.Rotation, 28,28, "TEST VEH");
        }

        [Command("gun")]
        public void GivePlayerGun(Player player, string gun = "pistol", int ammo = 500)
        {
            if (ammo > int.MaxValue)
                ammo = int.MaxValue;
            var user_gun = NAPI.Util.WeaponNameToModel(gun);
            NAPI.Player.GivePlayerWeapon(player, user_gun, ammo);
        }

        [RequiredHealth(75)]
        [Command("healme")]
        public void Heal_myself(Player player)
        {
            player.Health = 100;
            player.SendChatMessage("Command /healme was correctly worked");
        }

        [Command("createmarkerandcolshape")]
        public void Create_Colshape(Player player)
        {
            NAPI.ColShape.CreateCylinderColShape(player.Position, 2f, 1f, player.Dimension);
            NAPI.Marker.CreateMarker(1, new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 2f), player.Position, player.Rotation, 4f, new Color(255,255,255), false, player.Dimension);
        }

        [Command("kill")]
        public void Kill_Player(Player player)
        {
            player.Health = 0;
        }

        [Command("test")]
        public void OnTest(Player player, string name, string email, int age, int money)
        {
            var player_data = player.GetAllData();
            NAPI.ClientEvent.TriggerClientEvent(player, "test", name, email, age, money);
        }

        [Command("servertest")]
        public void CreateServerPed(Player player)
        {
            var ped = NAPI.Ped.CreatePed(0x5442C66B, player.Position, 0f, 0);
            
        }

        [Command("clienttest")]
        public void CreateClientPed(Player player)
        {
            var ped = NAPI.Ped.CreatePed(0x5442C66B, player.Position + new Vector3(5f,0,0), 0f, 0);
            var veh = NAPI.Vehicle.CreateVehicle(VehicleHash.Adder, player.Position + new Vector3(7.5f, 0, 0), 0, 1, 1);
            NAPI.ClientEvent.TriggerClientEventForAll("clienttest", player, ped, veh);
        }

        [Command("angry")]
        public void CreateAngryGuy(Player player)
        {
            var ped = NAPI.Ped.CreatePed(0x5442C66B, player.Position + new Vector3(5f, 0, 0), 0f, 0);
            NAPI.ClientEvent.TriggerClientEventForAll("CreateAngryGuy", ped, player);
        }
    }
}
