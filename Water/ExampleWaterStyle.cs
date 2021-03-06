﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Water
{
    public class ExampleWaterStyle : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
        {
            return Main.bgStyle == mod.GetSurfaceBgStyleSlot("ExampleSurfaceBgStyle");
        }

        public override int ChooseWaterfallStyle()
        {
            return mod.GetWaterfallStyleSlot("ExampleWaterfallStyle");
        }

        public override int GetSplashDust()
        {
            return 89;
        }

        public override int GetDropletGore()
        {
            return mod.GetGoreSlot("Gores/ExampleDroplet");
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.025f;
            g = 0.2f;
            b = 0.05f;
        }
    }
}