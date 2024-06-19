using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Map;
using UnityEngine;

using evArgs = Exiled.Events.Handlers.Player;
using MapArgs = Exiled.Events.Handlers.Map;

namespace SCP_2176_RCON
{
    [CustomItem(ItemType.SCP2176)]
    public class Item : CustomItem
    {
        public override uint Id { get; set; } = 1;
        public override float Weight { get; set; } = 1f;
        public override string Name { get; set; } = "SCP-2176-RCON";
        public override string Description { get; set; } = "<color=green><b>This SCP-2176-RCON</b></color>";
        public override SpawnProperties SpawnProperties { get; set; } = new();
        public override ItemType Type { get; set; } = ItemType.SCP2176;
        
        protected override void SubscribeEvents()
        {
            MapArgs.ExplodingGrenade += OnExplodingGrenade;
            base.SubscribeEvents();
        }
        
        protected override void UnsubscribeEvents()
        {
            MapArgs.ExplodingGrenade -= OnExplodingGrenade;
            base.UnsubscribeEvents();
        }
        
        protected static void CreateCollider(ExplodingGrenadeEventArgs ev)
        {
            // ReSharper disable once Unity.PreferNonAllocApi
            Collider[] _colliders = Physics.OverlapSphere(ev.Position, Plugin.Instance.Config.Radius);

            foreach (Collider collider in _colliders)
            {
                if (Player.Get(collider) is not null) 
                    foreach (KeyValuePair<EffectType, float> effect in Plugin.Instance.Config.Effects)
                    {
                        Player.Get(collider).EnableEffect(effect.Key, effect.Value);
                    }
            }
        }
        
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            if (Check(ev.Projectile))
            {
                ev.IsAllowed = false;
                
                if (Room.Get(ev.Position).Type is not RoomType.Surface)
                    foreach (Player player in Room.Get(ev.Position).Players)
                    {
                        foreach (KeyValuePair<EffectType, float> effect in Plugin.Instance.Config.Effects)
                        {
                            player.EnableEffect(effect.Key, effect.Value);
                        }
                    }
                
                else
                    CreateCollider(ev);
            }
        }
    }
}