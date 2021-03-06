using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TropicBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Blades");
            Tooltip.SetDefault("A huge double sided blade");
        }

        public override void SetDefaults()
        {
            item.damage = 140;    //The damage stat for the Weapon.
            item.melee = true;     //This defines if it does Melee damage and if its effected by Melee increasing Armor/Accessories.
            item.width = 100;    //The size of the width of the hitbox in pixels.
            item.height = 88;    //The size of the height of the hitbox in pixels.
            item.useTime = 10;   //How fast the Weapon is used.
            item.useAnimation = 10;     //How long the Weapon is used for.
            item.channel = true;
            item.useStyle = 100;    //The way your Weapon will be used, 1 is the regular sword swing for example
            item.knockBack = 3f;    //The knockback stat of your Weapon.
            item.value = Item.buyPrice(0, 12, 50, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 7;   //The color the title of your Weapon when hovering over it ingame                    
            item.shoot = mod.ProjectileType("TropicBlade");  //This defines what type of projectile this weapon will shoot  
            item.noUseGraphic = true; // this defines if it does not use graphic
        }

        public override bool UseItemFrame(Player player)     //this defines what frame the player use when this weapon is used
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }
    }
}