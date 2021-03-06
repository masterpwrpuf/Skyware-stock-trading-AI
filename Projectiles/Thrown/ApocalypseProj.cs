using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
	public class ApocalypseProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Apocalypse";
            projectile.width = 10;
            projectile.height = 16;

            projectile.aiStyle = 1;
            projectile.aiStyle = 113;

            projectile.thrown = true;
            projectile.friendly = true;

            projectile.penetrate = -1;
            projectile.timeLeft = 600;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BoneJavelin;

        }
		
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
	            Main.dust[dust].noGravity = true;		
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(5) == 0) target.AddBuff(mod.BuffType("FelBrand"), 180);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
			for (int I = 0; I < 8; I++)
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
        }
    }
}
