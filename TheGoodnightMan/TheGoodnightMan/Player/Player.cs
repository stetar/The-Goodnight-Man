﻿using GameLoopOne.Forms;
using GameLoopOne.Props;
using GameLoopOne.Weapons;
using GameLoopOne.Weapons.Melee;
using GameLoopOne.Weapons.Ranged;
using GameLoopOne.Weapons.Sprites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace GameLoopOne
{
    internal class Player : RigidBodyBox
    {
        //Player Weapon
        public static Weapon currentPlayerWeapon;

        private float weaponTimer = 0;
        private float weaponPickupTimer = 0;

        public static int weaponIndexNumber;

        //Player health
        public static int health;

        //Player animations
        private bool movingLeft;

        private bool movingRight;
        private int speed = 100;

        //Gravity
        private int gravity = 290;//the force the player is taken down with.

        private int jumpVelocity = -300;
        public static Vector2D velocity;
        public static bool isGrounded;
        public bool isAlive;
        private bool test = false;
        /// <summary>
        /// Constructor for the player. Handles the weapon index as well.
        /// </summary>
        /// <param name="imagePath">sprite</param>
        /// <param name="startPos">Starting position</param>
        /// <param name="scaleFactor"></param>
        public Player(string imagePath, Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            velocity = new Vector2D(0, 0);
            health = 100;
            isAlive = true;

            switch (weaponIndexNumber)
            {
                case 0:
                    currentPlayerWeapon = new BaseballBat(new Vector2D(0, 0), .3f);
                    break;

                case 1:
                    currentPlayerWeapon = new CricketPlayer(new Vector2D(0, 0), .8f);
                    break;

                case 2:
                    currentPlayerWeapon = new Knife(new Vector2D(0, 0), .3f);
                    break;

                case 3:
                    currentPlayerWeapon = new Guitar(new Vector2D(0, 0), .5f);
                    break;

                case 4:
                    currentPlayerWeapon = new Katana(new Vector2D(0, 0), .3f);
                    break;

                case 5:
                    currentPlayerWeapon = new DildoSword(new Vector2D(0, 0), .3f);
                    break;

                case 6:
                    currentPlayerWeapon = new Axe(new Vector2D(0, 0), .2f);
                    break;

                case 7:
                    currentPlayerWeapon = new Beaver(new Vector2D(0, 0), .5f);
                    break;

                case 8:
                    currentPlayerWeapon = new ISISFlag(new Vector2D(0, 0), .5f);
                    break;

                case 9:
                    currentPlayerWeapon = new AssaultRifle(new Vector2D(0, 0), .2f);
                    break;

                case 10:
                    currentPlayerWeapon = new RPG(new Vector2D(0, 0), .3f);
                    break;

                case 11:
                    currentPlayerWeapon = new SMG(new Vector2D(0, 0), .3f);
                    break;

                case 12:
                    currentPlayerWeapon = new LMG(new Vector2D(0, 0), .3f);
                    break;

                case 13:
                    currentPlayerWeapon = new Pistol(new Vector2D(0, 0), .1f);
                    break;
            }
            GameWorld.GameWeapons.Add(currentPlayerWeapon); //add it to objects as it should get drawn
        }
        /// <summary>
        /// Update function for the player
        /// </summary>
        /// <param name="fps"></param>
        public override void Update(float fps)
        {
            if (currentPlayerWeapon != null)
            {
                currentPlayerWeapon.Position.X = position.X + currentPlayerWeapon.moveWeaponRight;
                currentPlayerWeapon.Position.Y = position.Y + currentPlayerWeapon.moveWeaponUp;
            }

            //Player animation & Movement
            movingLeft = false;
            movingRight = false;

            if (Keyboard.IsKeyDown(Keys.A))
            {
                position.X -= 1 / fps * speed;
                movingLeft = true;
            }

            if (Keyboard.IsKeyDown(Keys.D))
            {
                position.X += 1 / fps * speed;
                movingRight = true;
            }
            float deltaTime = 1f / fps;
            if (Keyboard.IsKeyDown(Keys.Space) && weaponTimer > currentPlayerWeapon.AttackSpeed)
            {
                currentPlayerWeapon.AttackMelee();
                weaponTimer = 0;
            }
            weaponTimer += deltaTime;

            //Jump
            if (Keyboard.IsKeyDown(Keys.W))
            {
                if (isGrounded)
                {
                    velocity.Y = jumpVelocity;
                    isGrounded = false;
                }
            }

            // Bottom collision

            if (position.Y > GameWorld.WindowRectangle.Bottom - (GameWorld.WindowRectangle.Bottom / 5)) //align it with the backgroundline
            {
                isGrounded = true;

                if (velocity.Y > 0)
                {
                    velocity.Y = 0;
                }
            }
            else
            {
                isGrounded = false;
            }

            // if the player is not grounded, add gravity
            if (!isGrounded)
            {
                velocity.Y += gravity * 1 / fps;
            }
            position.Y += velocity.Y * 1 / fps;

            //position and next level
            if (position.X > GameWorld.WindowRectangle.Right)
            {
                GameWorld.iLevel++;
                //Weapon.GameWeapons.Clear();

                GameWorld.SetupDifferentWorlds();
                position.X = sprite.Width;
            }
            else if (position.X < (GameWorld.WindowRectangle.Left - 50))
            {
                //Weapon.GameWeapons.Clear();
                GameWorld.iLevel--;
                GameWorld.SetupDifferentWorlds();
                position.X = 900;
            }

            if (Keyboard.IsKeyDown(Keys.I) && !SpeechBubble.insultActive)
            {
                SpeechBubble.insultActive = true;
                GameWorld.objects.Add(new SpeechBubble("Speech_bubble.png", new Vector2D(Position.X + 30, Position.Y - 100), .9f, this));
            }
            base.Update(fps);
        }
        /// <summary>
        /// Override of UpdateAnimation so the player gets animated correctly
        /// </summary>
        /// <param name="fps"></param>
        public override void UpdateAnimation(float fps)
        {
            float factor = 1 / fps;

            if (movingLeft)
            {
                // Calculate current frame index
                currentFrameIndex -= factor * animationSpeed * 2;
            }
            else if (movingRight)
            {
                currentFrameIndex += factor * animationSpeed * 2;
            }
            else
            {
                currentFrameIndex = 0;
            }

            // Start animation over if needed
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
            }
            else if (currentFrameIndex < 0)
            {
                currentFrameIndex = animationFrames.Count - 1;
            }

            sprite = animationFrames[(int)currentFrameIndex];
        }

        /// <summary>
        /// Checks the player's collision each tick, only called on actual collision.
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                health -= Enemy.currentEnemyWeapon.damage;
                GameWorld.removeList.Add(other);
            }

            if (other is Explosion)
            {
                if (!Explosion.damageTaken)
                {
                    health -= Enemy.currentEnemyWeapon.damage;
                    Explosion.damageTaken = true;
                }
            }

            if (health <= 0)
            {
                Form1.timer1.Stop();
                GameWorld.eng.StopAllSounds();
                DialogResult dialogResult = MessageBox.Show("You got yourself killed, you idiot! What the hell kinda retarded move is that? Do you even know how to play video games? Just click yes to return to the main menu, scrub. Or you can just quit now. That wouldn't suprise me at all, since you're such a fucking cunt!", "Game fucking over!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GameWorld.objects.Clear();
                    GameWorld.GameWeapons.Clear();
                    GameWorld.removeList.Clear();
                    Form1.ActiveForm.Hide();
                    new MainMenuForm().Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}