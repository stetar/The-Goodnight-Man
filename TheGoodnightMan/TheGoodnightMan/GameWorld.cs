﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using GameLoopOne.Props;
using GameLoopOne.Weapons;

namespace GameLoopOne
{

    class GameWorld
    {
        private Graphics dc;
        public static List<GameObject> objects;
        public static List<GameObject> removeList;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
        static Image level0Image = Image.FromFile("Levels/level0.png");
        static Image level1Image = Image.FromFile("Levels/level0.png");
        static Rectangle displayRectangle;
        public static int iLevel = 0;
        public static int iIncorrectness = 0;
        public static List<Weapon> GameWeapons = new List<Weapon>();


        public static Rectangle WindowRectangle
        {
            get
            {
                return displayRectangle;
            }
            set
            {
                displayRectangle = value;
            }
        }

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            WindowRectangle = displayRectangle;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            objects = new List<GameObject>();
            removeList = new List<GameObject>();
            SetupDifferentWorlds();
            SetupWorld();
        }

        public static List<GameObject> GameObjects
        {
            get { return objects; }
            set { objects = value; }
        }
        public void SetupWorld()
        {
            endTime = DateTime.Now;
            //Random rand = new Random();
            //string imageString = "weapons/sprites/weaponSprite1.png;weapons/sprites/weaponSprite2.png;weapons/sprites/weaponSprite3.png;weapons/sprites/weaponSprite4.png";

            string imageString = "Player/Sprites/Playersprite1.png;Player/Sprites/Playersprite2.png;Player/Sprites/Playersprite3.png;Player/Sprites/Playersprite4.png;Player/Sprites/Playersprite5.png;Player/Sprites/Playersprite6.png;Player/Sprites/Playersprite7.png;Player/Sprites/Playersprite8.png";
            objects.Add(new Player(imageString, new Vector2D(100, 550), .75f));
            objects.Add(new Sky(new Vector2D(10, 100), 1));
            objects.Add(new Sky(new Vector2D(850, 50), 1));
            objects.Add(new Sky(new Vector2D(440, 75), 1));
            string text = File.ReadAllText("test.txt");
           
            //string[] lines = System.IO.File.ReadAllLines("test.txt");
            ////if (lines[0] != null)
            ////{
            ////    //GameWorld.iIncorrectness = Convert.ToInt32(lines[0]);
            ////}
            ////for (int i = 0; i < GameWorld.objects.Count; i++)
            ////{
            ////    lines[0] = Player.currentPlayerWeapon.ToString(); // the current player weapon.
            ////    //lines[1] = GameWorld.iIncorrectness.ToString();
            ////    //lines[2] = GameWorld.iLevel.ToString();
            ////}
            //string[] savedLines = new string[] { };

            //for (int i = 0; i < lines.Count(); i++)
            //{
            //    savedLines[lines.Count()];
            //}
              


            //foreach (string line in lines)
            //{
            //    //lines[0] = Player.currentPlayerWeapon.ToString(); // the current player weapon.
            //    //lines[1] = GameWorld.iIncorrectness.ToString();
            //    //lines[2] = GameWorld.iLevel.ToString();
            //    lines[0] = "Hej";
            //    lines[1] = "line2";
            //    lines[2] = "line 43";
            //    File.WriteAllLines("test.txt", lines);
            //}
           
            //text = text.Replace("weapon", "new value");
            //string penis = Player.currentPlayerWeapon.ToString();
            //File.WriteAllText("test.txt", penis);
            

        }


        private void UpdateAnimations(float fps)
        {
            foreach (GameObject go in objects)
            {
                go.UpdateAnimation(fps);
            }
            foreach (Weapon wep in GameWeapons)
            {
                wep.UpdateAnimation(fps);
            }

        }
        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;
            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFps = 1000f / milliSeconds;
            endTime = DateTime.Now;
            Update(currentFps);
            Draw();
        }

        private void Update(float fps)
        {
            
            foreach (GameObject go in objects.ToList()) //To list as you can't modify it in runtime elsewise.
            {
                go.Update(fps);
                go.UpdateAnimation(fps);
            }
            foreach (Weapon go in GameWeapons.ToList()) //To list as you can't modify it in runtime elsewise.
            {
                go.Update(fps);
                go.UpdateAnimation(fps);
            }
            ResolveRigidbodyCollisions();

            //remove list
            foreach (GameObject go in removeList.ToList())
            {
                if (objects.Contains(go))
                {
                    if (go is Enemy)
                    {
                        //Add score
                    }
                    objects.Remove(go);
                }
            }
           
            // Clear toremove
            removeList.Clear();


        }

        private void ResolveRigidbodyCollisions()
        {
            foreach (var a in objects)
            {
                if (a is RigidBodyBox)
                {
                    foreach (var b in objects.ToList())
                    {
                        if (a != b)
                        {
                            if (!(b is Bullet || b is Impact || b is Enemy || b is Sky || b is Weapon)) //Don't calculate solid collisions for these classes
                            {
                                this.ResolveAABBCollision(a, b);
                            }
                            else
                            {
                                //Dont do anything
                            }
                        }
                    }

                }
            }
        }

        private void ResolveAABBCollision(GameObject rigidbody, GameObject b)
        {
            RectangleF result = RectangleF.Intersect(rigidbody.CollisionBox, b.CollisionBox);
            if (result.Width > 0 || result.Height > 0)
            {
                Vector2D rigidbodyCenter = new Vector2D(
                    rigidbody.CollisionBox.Left + rigidbody.CollisionBox.Width * 0.5f,
                    rigidbody.CollisionBox.Top + rigidbody.CollisionBox.Height * 0.5f
                );
                if (result.Height > result.Width)
                //resolve horisontally
                {
                    float distanceFromRight = Math.Abs(rigidbodyCenter.X - b.CollisionBox.Right);
                    float distanceFromLeft = Math.Abs(rigidbodyCenter.X - b.CollisionBox.Left);
                    if (distanceFromRight > distanceFromLeft)
                    {
                        // Go left
                        rigidbody.Position.X -= result.Width;
                    }
                    else
                    {
                        // Go right
                        rigidbody.Position.X += result.Width;
                    }
                }
                else
                {
                    float distanceFromTop = Math.Abs(rigidbodyCenter.Y - b.CollisionBox.Top);
                    float distanceFromBottom = Math.Abs(rigidbodyCenter.Y - b.CollisionBox.Bottom);
                    if (distanceFromTop < distanceFromBottom)
                    {
                        // Go up
                        rigidbody.Position.Y -= result.Height;
                        Player.isGrounded = true;
                        if (Player.velocity.Y > 0) // Don't pull player down
                        {
                            Player.velocity.Y = 0;
                        }
                    }
                    else
                    {
                        // Go down
                        //Player.isGrounded = false;
                        //Don't make the position go down as we go below the map
                        rigidbody.Position.Y += result.Height;
                    }
                }
            }
        }


        private void Draw()
        {
            // Top background image

            switch (iLevel)
            {
                default:
                    dc.DrawImage(level0Image, 0, 0, level0Image.Width, level0Image.Height);
                    break;
                case 1:
                    dc.DrawImage(level1Image, 0, 0, level1Image.Width, level1Image.Height);
                    break;
                case 2:
                    dc.DrawImage(level1Image, 0, 0, level1Image.Width, level1Image.Height);
                    break;

            }

            foreach (GameObject go in objects.ToList())
            {
                go.Draw(dc);

            }
            foreach (Weapon wep in GameWorld.GameWeapons.ToList())
            {
                wep.Draw(dc);
            }

            Font f = new Font("IMPACT", 16);

#if DEBUG
            dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 0, 0);
#endif

            //Incorrectness meter
            //dc.DrawString(string.Format("INCORRECTNESS:{0}", iIncorrectness), f1, Brushes.Black, displayRectangle.Width / 2, 0);
            dc.DrawString(string.Format("INCORRECTNESS: {0}", iIncorrectness), f, Brushes.DarkRed, 0, 30);
            dc.DrawString(string.Format("LEVEL: {0}", iLevel), f, Brushes.Black, 0, 60);

            backBuffer.Render();
        }


        public static void SetupDifferentWorlds()
        {
            foreach (GameObject go in objects.ToList())
            {
                if (!(go is Player || go is Sky))//dont remove the player or the sky
                {
                    removeList.Add(go);

                    
                }
            }

            switch (iLevel)
            {
                case 0:
                    objects.Add(new Crate(new Vector2D(400, 590), .5f));
                    objects.Add(new Crate(new Vector2D(540, 590), .5f));
                    objects.Add(new Crate(new Vector2D(470, 508), .5f));
                    objects.Add(new Wrench(new Vector2D(470, 508), .5f));


                    //objects.Add(new Wrench(new Vector2D(470, 508), .5f));

                    objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(770, 590), .75f, (new Wrench(new Vector2D(770, 590), .3f))));

                    break;
                case 1:

                    objects.Add(new Crate(new Vector2D(540, 590), .5f));
                    //objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(770, 420),.75f));
                    //objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(300, 590), .75f));
                    objects.Add(new Bridge(new Vector2D(770, 500), .75f));

                    break;
                case 2:

                    objects.Add(new Crate(new Vector2D(570, 590), .5f));
                    objects.Add(new Crate(new Vector2D(670, 590), .5f));
                    //objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(770, 420), .75f));
                    //objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(300, 590), .75f));
                    objects.Add(new Bridge(new Vector2D(590, 435), .75f));
                    objects.Add(new CratePhys(new Vector2D(300, 590), .5f));
                    break;
            }

        }

        public static void SaveGameState()
        {
            List<string> lineList = new List<string>();
            lineList.Clear();
            lineList.Add(GameWorld.iIncorrectness.ToString());
            lineList.Add(GameWorld.iLevel.ToString());
            lineList.Add(Player.currentPlayerWeapon.ToString());
            //if (Weapon.gameWeapons != null)
            //{
            //    Weapon.gameWeapons.Clear();
            //    foreach (Weapon go in Weapon.gameWeapons)
            //    {
            //        lineList.Add(go.ToString());//not working with other weapos
            //    }
            //}
            string[] lines = new string[] { GameWorld.iIncorrectness.ToString(), GameWorld.iLevel.ToString(), Player.currentPlayerWeapon.ToString() };
           // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            System.IO.File.WriteAllLines("test.txt", lineList);
        }
        public static void LoadGameState()
        {
            string[] lines = File.ReadAllLines("test.txt");
            GameWorld.iIncorrectness = Convert.ToInt32(lines[0]);
            GameWorld.iLevel = Convert.ToInt32(lines[1]);


        }

    }

}
