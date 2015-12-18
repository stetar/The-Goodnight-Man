﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoopOne.Weapons
{
    internal abstract class Weapon : GameObject
    {
        public int damage = 1;
        protected string imagePath;
        public float AttackSpeed = 0;
        protected GameObject targetPlayer;
        private bool didAttack = false;
        public float meleeRange = 1;
        private Graphics attackRange;
        protected Vector2D bulletStartPos;
        //private Graphics dc;
        public Weapon(string imagePath, Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {

        }
        public RectangleF attackRangeBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, 50 * meleeRange, 50);
            }
        }
        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
#if DEBUG
            dc.DrawRectangle(new Pen(Brushes.Red), position.X, position.Y, attackRangeBox.Width, attackRangeBox.Height);//don't draw the actual range in release
#endif
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            //attackRange = dc.DrawRectangle(blackPen, position.X, position.Y,100*meleeRange, 50);
        }

        public virtual void AttackMelee()
        {
            float x = position.X - 80;
            float y = position.Y - 50;
            didAttack = true;
            foreach (GameObject go in GameWorld.objects.ToList()) //ToList so we can modify it
            {
                if (go is Enemy)
                {

                    Enemy e1 = go as Enemy;
                    if (attackRangeBox.IntersectsWith(go.CollisionBox))
                    {
                        e1.health -= damage;
                        GameWorld.objects.Add(new Impact(new Vector2D(x, y), .5f));

                    }
                }
            }
        }

        public virtual void AttackRanged()
        {
            foreach (GameObject player in GameWorld.objects)
            {
                if (player is Player)
                {
                    targetPlayer = player;
                }
            }
            float x = position.X + 30;
            float y = position.Y - 20;
            bulletStartPos = new Vector2D(x, y);
            GameWorld.objects.Add(new Bullet("bullet.png", bulletStartPos, 1, 150, targetPlayer));
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
            {
                //GameWorld.removeList.Add(other);
            }
            base.OnCollision(other);

            if (other is Player && Keyboard.IsKeyDown(Keys.S))
            {
                Player.currentWeapon = this;
            }
        }

        /// <summary>
        /// override of UpdateAnimation, as the weapon should not loop it's animation
        /// </summary>
        /// <param name="fps"></param>
        public override void UpdateAnimation(float fps)
        {
            if (didAttack)
            {
                float factor = 1 / fps;
                currentFrameIndex += factor * animationSpeed;
                if (currentFrameIndex >= animationFrames.Count)
                {
                    currentFrameIndex = 0;
                    didAttack = false;

                }
                sprite = animationFrames[(int)currentFrameIndex];
            }
        }
    }
}
