using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace SpiritMod
{
	public class MyWorld : ModWorld
	{
		private int WillGenn = 0;
		
		private int Meme;
        public static int SpiritTiles = 0;
		public static int VerdantTiles = 0;

        public static bool downedScarabeus = false;
        public static bool downedAncientFlyer = false;
        public static bool downedAtlas = false;
        public static bool downedInfernon = false;
        public static bool downedDusking = false;
        public static bool downedIlluminantMaster = false;
        public static bool downedOverseer = false;

        public static bool VerdantBiome = false;
		public static bool Magicite = false;
		public static bool spiritBiome = false;
        public static bool flierMessage = false;

        public override void TileCountsAvailable(int[] tileCounts)
        {
            SpiritTiles = tileCounts[mod.TileType("SpiritDirt")] + tileCounts[mod.TileType("SpiritStone")] + tileCounts[mod.TileType("Spiritsand")] + tileCounts[mod.TileType("SpiritIce")];
			 VerdantTiles = tileCounts[mod.TileType("VeridianDirt")] + tileCounts[mod.TileType("VeridianStone")];
        }

        public override void Initialize()
        {
            downedScarabeus = false;
        downedAncientFlyer = false;
        downedAtlas = false;
        downedInfernon = false;
        downedDusking = false;
         downedIlluminantMaster = false;
        downedOverseer = false;
			if (NPC.downedBoss1 == true)
            {
                Magicite = true;
            }
            else
            {
                Magicite = false;
            }
            if (NPC.downedMechBoss3 == true || NPC.downedMechBoss2 == true || NPC.downedMechBoss1 == true)
            {
                spiritBiome = true;
            }
            else
            {
                spiritBiome = false;
            }
			if (Main.hardMode == true)
            {
                VerdantBiome = true;
            }
            else
            {
                VerdantBiome = false;
            }
        }
        public override void PostUpdate()
        {
            if (NPC.downedBoss1)
            {
                if (!Magicite)
                {
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY * 13) * 15E-05); k++)
                    {
                        int EEXX = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                            int WHHYY = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 130);
                        if (Main.tile[EEXX, WHHYY] != null)
                        {
                            if (Main.tile[EEXX, WHHYY].active() )
                            {
                                if (Main.tile[EEXX, WHHYY].type == 60)
                                {
                                    WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), (ushort)mod.TileType("FloranOreTile"));
                                }
                            }
                        }
                    }
                    Main.NewText("The Underground Jungle seems to be glowing...", 100, 220, 100);
                    Main.NewText("New enemies have spawned forth underground", 204, 153, 0);
                    Magicite = true;
                }
            }

            if (NPC.downedQueenBee)
            {
                if (!flierMessage)
                {
                    Main.NewText("Scattered bones rise into the sky...", 204, 153, 0);
                    flierMessage = true;
                }
            }
            {
                if (InvasionHandler.currentInvasion != null)
                    Main.invasionWarn = 3600;
            }

            if (NPC.downedMechBoss3 == true || NPC.downedMechBoss2 == true || NPC.downedMechBoss1 == true)
            {
                if (!spiritBiome)
                {
                    spiritBiome = true;
                    Main.NewText("The Spirits spread through the Land...", Color.Orange.R, Color.Orange.G, Color.Orange.B);
                    Random rand = new Random();
                    int XTILE;
                    if (Terraria.Main.dungeonX > Main.maxTilesX / 2) //rightside dungeon
                    {
                        XTILE = WorldGen.genRand.Next(Main.maxTilesX / 2, Main.maxTilesX - 500);
                    }
                    else //leftside dungeon
                    {
                        XTILE = WorldGen.genRand.Next(75, Main.maxTilesX / 2);
                    }
                    int xAxis = XTILE;
                    int xAxisMid = xAxis + 70;
                    int xAxisEdge = xAxis + 380;
                    int yAxis = 0;
                    for (int y = 0; y < Main.maxTilesY; y++)
                    {
                        yAxis++;
                        xAxis = XTILE;

                        for (int i = 0; i < 450; i++)
                        {
                            xAxis++;

                            
                            if (Main.tile[xAxis, yAxis] != null)
                            {
                                if (Main.tile[xAxis, yAxis].active())
                                {
                                    int[] TileArray = { 0 };
                                    if (TileArray.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (Main.rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {
                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 10)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritDirt");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 10)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritDirt");
                                            }
                                        }
                                    }

                                    int[] TileArray1 = { 2, 23, 109, 199 };
                                    if (TileArray1.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {
                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
                                            }
                                        }
                                    }

                                    int[] TileArray2 = { 1, 25, 117, 203 };
                                    if (TileArray2.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {

                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
                                            }
                                        }
                                    }

                                    int[] TileArray3 = { 53, 116, 112, 234 };
                                    if (TileArray3.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {

                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("Spiritsand");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("Spiritsand");
                                            }
                                        }
                                    }

                                    int[] TileArray4 = { 161, 163, 200, 164 };
                                    if (TileArray4.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {

                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritIce");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritIce");
                                            }
                                        }
                                    }
                                }
                                if (Main.tile[xAxis, yAxis].type == mod.TileType("SpiritStone") && yAxis > WorldGen.rockLayer + 100 && Main.rand.Next(1500) == 6)
                                {
                                    WorldGen.TileRunner(xAxis, yAxis, (double)WorldGen.genRand.Next(5, 7), 1, mod.TileType("SpiritOreTile"), false, 0f, 0f, true, true);
                                }
                            }
                            
                        }
                    }
                }
            }

           /* if (Main.hardMode)
            {
                if (!VerdantBiome)
                {
                    Main.NewText("The World's Primal Life begins anew", Color.Orange.R, Color.Orange.G, Color.Orange.B);
                    VerdantBiome = true;
                    for (int i = 0; i < ((int)Main.maxTilesX / 250) * 3; i++)
                    {
                        int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
                        int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 300);
                        int XvalueHigh = Xvalue + 240;
                        int YvalueHigh = Yvalue + 160;
                        int XvalueMid = Xvalue + 120;
                        int YvalueMid = Yvalue + 80;
                        if (Main.tile[XvalueMid, YvalueMid] != null)
                        {
                            if (Main.tile[XvalueMid, YvalueMid].type == 1) // A = x, B = y.
                            {
                                WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true); //c = x, d = y
                                WorldGen.TileRunner(XvalueMid + 20, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true); //c = x, d = y
                                WorldGen.TileRunner(XvalueMid + 40, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true); //c = x, d = y
                                WorldGen.TileRunner(XvalueMid + 60, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true);
                                WorldGen.TileRunner(XvalueMid + 80, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true);//c = x, d = y
                                                                                                                                                                                  		for (int A = Xvalue; A < XvalueHigh; A++)
                                                                                                                                                                                          {
                                                                                                                                                                                              for (int B = Yvalue; B < YvalueHigh; B++)
                                                                                                                                                                                              {
                                                                                                                                                                                                  if (Main.tile[A,B] != null)
                                                                                                                                                                                                  {
                                                                                                                                                                                                      if (Main.tile[A,B].type ==  mod.TileType("CrystalBlock")) // A = x, B = y.
                                                                                                                                                                                                      { 
                                                                                                                                                                                                          WorldGen.KillWall(A, B);
                                                                                                                                                                                                          WorldGen.PlaceWall(A, B, mod.WallType("CrystalWall"));
                                                                                                                                                                                                      }
                                                                                                                                                                                                  }
                                                                                                                                                                                              }
                                                                                                                                                                                          }

                                WorldGen.digTunnel(XvalueMid, YvalueMid, WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(8, 10), false);
                                WorldGen.digTunnel(XvalueMid + 50, YvalueMid, WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(8, 10), false);
                                for (int Ore = 0; Ore < 75; Ore++)
                                {
                                    int Xore = XvalueMid + Main.rand.Next(100);
                                    int Yore = YvalueMid + Main.rand.Next(-70, 70);
                                    if (Main.tile[Xore, Yore].type == mod.TileType("VeridianDirt")) // A = x, B = y.
                                    {
                                        WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(3, 6), mod.TileType("VeridianStone"), false, 0f, 0f, false, true);
                                    }
                                }
                            }
                        }
                    }
                }
            } */
        }
    }
}
