using System;
using Exiled.API.Features;
using Exiled.CustomItems.API;

namespace SCP_2176_RCON
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        
        public override string Author => "Morkamo";
        public override string Name => "SCP-2176-RCON";
        public override string Prefix => "SCP-2176-RCON";
        public override Version Version => new Version(1, 0, 0);

        public Item _Item;
        
        public override void OnEnabled()
        {
            Instance = this;
            _Item = new Item();
            
            Config.Item.Register();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            _Item = null;
            
            Config.Item.Unregister();
            
            base.OnDisabled();
        }
    }
}