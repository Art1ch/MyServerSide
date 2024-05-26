using RAGE;
using RAGE.Elements;
using System;

namespace MyClientSIde.Player
{
    public class Client_Events: Events.Script
    {
        public Client_Events()
        {
            Events.OnOutgoingDamage += OnOutgoingDamageHandler;
            Events.OnEntityStreamIn += OnEntityStreamInHandler;
            Events.OnEntityStreamOut += OnEntityStreamOutHandler;
            Events.OnPlayerEnterVehicle += OnPlayerEnterVehicleHandler;
            Events.OnPlayerDeath += OnPlayerDeathHandler;
            Events.OnPlayerCreateWaypoint += OnPlayerCreateWaypointHandler;

            RAGE.Input.Bind(RAGE.Ui.VirtualKeys.F5, true, () =>
            {
                if (RAGE.Elements.Player.LocalPlayer.Vehicle != null)
                {
                    Events.CallRemote("repairveh");
                }
                return;
            });

            RAGE.Input.Bind(RAGE.Ui.VirtualKeys.F6, true, () =>
            {
                if (RAGE.Elements.Player.LocalPlayer.Vehicle != null)
                {
                    Events.CallRemote("destroyveh");
                }
                return;
            });

            Events.Add("clienttest", OnClientTestHandler);
            Events.Add("test", testHandler);
            Events.Add("CreateAngryGuy", OnCreateAngryGuy);

        }


        private void OnEntityStreamInHandler(Entity entity)
        {
            if (entity.Type == RAGE.Elements.Type.Vehicle)
            {
                RAGE.Chat.Output("You see a car!");
            }
        }

        public void OnEntityStreamOutHandler(Entity entity)
        {
            if (entity.Type == RAGE.Elements.Type.Vehicle)
            {
                RAGE.Chat.Output("Car has disappered!");
            }
        }

        private void OnCreateAngryGuy(object[] args)
        {
            var ped = (RAGE.Elements.Ped)args[0];
            var player = (RAGE.Elements.Player)args[1];
            ped.GiveWeaponTo(0xB1CA77B1, 300, false, true);
            RAGE.Game.Ai.TaskCombatPed(ped.Handle, player.Handle, 1, 1);
        }

        private void OnPlayerCreateWaypointHandler(Vector3 marker_position)
        {
            MapMarker.MapMarkerCoords = marker_position;
        }

        private void OnClientTestHandler(object[] args)
        {
            Chat.Output("ClientTestHandler");

            var player = (RAGE.Elements.Player)args[0];
            var ped = (RAGE.Elements.Ped)args[1];
            var veh = (RAGE.Elements.Vehicle)args[2];
            var coords = MapMarker.MapMarkerCoords;


            RAGE.Game.Ai.TaskEnterVehicle(ped.Handle, veh.Handle, 1000000000, -1, 2f, 1, 0);
            if (coords != null)
            {
                Chat.Output($"Coords : {coords.X}, {coords.Y}, {coords.Z}");
                RAGE.Game.Ai.TaskVehicleDriveToCoordLongrange(ped.Handle, veh.Handle, coords.X, coords.Y, coords.Z, 3000f, 2, 100f);
            }
            else { Chat.Output($"Place a marker on the map!"); }


        }

        private void testHandler(object[] args)
        {
            PlayerInfo player_info = new PlayerInfo((string)args[0], (string)args[1], (int)args[2], (int)args[3]);
            RAGE.Chat.Output($"Name: {player_info.Name}");
            RAGE.Chat.Output($"Email: {player_info.Email}");
            RAGE.Chat.Output($"Age: {player_info.Age}");
            RAGE.Chat.Output($"Money: {player_info.Money}");
        }


        private void OnPlayerDeathHandler(RAGE.Elements.Player player, uint reason, RAGE.Elements.Player killer, Events.CancelEventArgs cancel)
        {
            RAGE.Chat.Output("You dead (CLIENT)");
        }


        private void OnOutgoingDamageHandler(Entity sourceEntity, Entity targetEntity, RAGE.Elements.Player sourcePlayer, ulong weaponHash, ulong boneIdx, int damage, Events.CancelEventArgs cancel)
        {
            if (targetEntity.Type == RAGE.Elements.Type.Player)
            {
                RAGE.Chat.Output("Don't fight with each other!");
            }
        }
        private void OnPlayerEnterVehicleHandler(Vehicle vehicle, int seatId)
        {
            vehicle.SetInvincible(false);
            vehicle.SetCanBeDamaged(true);
            RAGE.Chat.Output($"{vehicle.GetEngineHealth()}");
            RAGE.Chat.Output("CLIENT ENTER VEH");
        }
    }
}
