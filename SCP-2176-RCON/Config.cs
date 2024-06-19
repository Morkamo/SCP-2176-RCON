using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace SCP_2176_RCON
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Накладываемые эффекты на игроков при взрыве SCP-2176-RCON (в пределах комнаты) {EffectType} : {Duration}")]
        public Dictionary<EffectType, float> Effects { get; set; } = new Dictionary<EffectType, float>()
        {
            [EffectType.Flashed] = 5f,
            [EffectType.Ensnared] = 5f,
        };

        [Description("Радиус действия - используется при взрыве на поверхности (RoomType.Surface)")]
        public float Radius { get; set; } = 10f;

        [Description("Настройки предмета SCP-2176-RCON")]
        public Item Item { get; set; } = new Item();
    }
}