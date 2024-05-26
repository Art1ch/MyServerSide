using GTANetworkAPI;

namespace ServerSide.CommandAttributes
{
    class RequiredHealthAttribute : CommandConditionAttribute
    {
        private int _health;

        public RequiredHealthAttribute(int health = 100)
        {
            _health = health;
        }

        public override bool Check(Player player, string cmdName, string cmdText)
        {
            if (player.Health > _health) { return false; }
            return true;
        }
    }
}
