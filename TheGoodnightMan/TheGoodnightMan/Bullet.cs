﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameLoopOne.Props;
using GameLoopOne.Weapons;
using GameLoopOne.Weapons.Ranged;
using GameLoopOne.Weapons.Sprites;

namespace GameLoopOne
{
    class Bullet : GameObject
    {
        private GameObject player;
        private float speed;
        private Vector2D targetPosition;
        private bool hasAttacked;

        private Vector2D velocity; //for storing the value
        public Bullet(string imagePath, Vector2D startPos, float scaleFactor, float speed, GameObject player) : base(imagePath, startPos, scaleFactor)
        {
            this.player = player;
            this.speed = speed;
        }


        public override void Update(float fps)
        {
            //Calculate distance between player and enemy

            if (!hasAttacked)
            {
                velocity = position.Subtract(player.Position); //only do this once
                velocity.Normalize();
                hasAttacked = true;
            }

            position.X += 1 / fps * (velocity.X * speed);
            position.Y += 1 / fps * (velocity.Y * speed);
            if (CollisionBox.Right < 0 || CollisionBox.Left < 0 || CollisionBox.Top < 0) //optimaahzation
            {
                GameWorld.removeList.Add(this);
            }

            base.Update(fps);

        }
        public override void OnCollision(GameObject other)
        {
            if (other is Crate || other is Bridge)
            {
                GameWorld.removeList.Add(this);
            }
            foreach (GameObject pewpew in GameWorld.objects.ToList())
            {
                if (pewpew is RPG)
                {
                    if (hasAttacked)
                    {
                        if (!(other is Enemy || other is Weapon || other is Sky))
                        {
                            GameWorld.removeList.Add(this);
                            GameWorld.objects.Add(new Explosion(new Vector2D(this.position.X - (sprite.Width / 2), this.position.Y - (sprite.Height / 2)), 1));
                            hasAttacked = false;
                        }
                    }
                }
            }
            //not removing bullets here, as they all would be removed when one collided with ANYTHING.
            //GameWorld.removeList.Add(this); 
        }
    }
}
