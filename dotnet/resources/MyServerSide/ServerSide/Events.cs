using GTANetworkAPI;
using System;
using System.Net.Mail;


namespace ServerSide
{
    class Events : Script
    {
        [ServerEvent(Event.PlayerSpawn)]
        private void OnPlayerSpawn(Player player)
        {
            player.Armor = 100;
            player.SendNotification("You were spawned", true);
        }

        [ServerEvent(Event.PlayerDeath)]
        private void OnPlayerDeath(Player player, Player killer, uint reason)
        {
            var real_reason = (DeathReason)reason;
            player.SendChatMessage(real_reason.ToString());
            if (killer == null)
                player.SendNotification($"Ops, you have died, reason of death: {real_reason.ToString()}");
            else { player.SendNotification($"Ops, you were killed by {killer.Name}, reason of death: {real_reason.ToString()}"); }
        }


        [ServerEvent(Event.PlayerEnterVehicle)]
        private void OnPlayerEnterVehicle(Player player, Vehicle veh, sbyte seatID)
        {
            player.SendChatMessage("You have entered the vehicle");
            veh.PrimaryColor = 55;
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        private void OnPlayerExitVehicle(Player player, Vehicle veh)
        {
            player.SendChatMessage("You have exited the vehicle");
            veh.PrimaryColor = 42;
        }

        [ServerEvent(Event.PlayerEnterColshape)]
        public void OnPlayerEnterColshape(ColShape colshape, Player player)
        {
            player.SendChatMessage(player.Name + " has entered colshape");
        }

        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColshape(ColShape colshape, Player player)
        {
            player.SendChatMessage(player.Name + " has exited colshape");
        }

        //[ServerEvent(Event.VehicleDamage)]
        //public void OnVehicleDamage(Vehicle veh, float body_loss, float engine_loss)
        //{
        //    float totalDamage = body_loss + engine_loss;
        //    NAPI.Chat.SendChatMessageToAll($"{ totalDamage}");
        //}

        [RemoteEvent("repairveh")]
        public void OnRepairVeh(Player player)
        {
            player.Vehicle.Repair();
            player.SendChatMessage("Your vehicle has been repaired!");
        }

        [RemoteEvent("destroyveh")]
        public void OnDestroyVehicle(Player player)
        {
            var a = player.Vehicle;
            a.Delete();
        }

        
    }
}
