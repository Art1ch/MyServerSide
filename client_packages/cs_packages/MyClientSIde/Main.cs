using RAGE;
using RAGE.Elements;
using System.ComponentModel;


namespace MyClientSIde
{
    public class Main : Events.Script
    {
        public Main()
        {
            Events.OnPlayerReady += OnPlayerReady;
        }

        private void OnPlayerReady()
        {
            RAGE.Chat.Output("Welcome to Test server!");
        }

       


    }
}
