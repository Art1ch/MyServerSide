using System;
using System.Collections.Generic;
using System.Text;

namespace MyClientSIde
{
    public class PlayerInfo
    {
        public readonly string Name;
        public readonly string Email;
        public readonly int Age;
        public readonly int Money;

        public PlayerInfo(string name, string email, int age, int money)
        {
            Name = name;
            Email = email;
            Age = age;
            Money = money;
        }
    }
}
