﻿using Microsoft.Xna.Framework;
using Terraria;

namespace LuckyRunes.RuneEvents.PlayerEvents
{
    /// <summary>A simple event which simply heals a player if bits > 50 are donated.</summary>
    class HealEvent : PlayerEvent
    {
        public override string Name => "Heal";
        public override string Message => "You get healed!";
        public override float Impact => 1.9f;
        public override float Alignment => 0.25f;

        public override void PlayerEffect(Player player)
        { 
            player.HealEffect(100);
            player.statLife += 100;
            if (player.statLife > player.statLifeMax2)
                player.statLife = player.statLifeMax2;
        }
    }
}
