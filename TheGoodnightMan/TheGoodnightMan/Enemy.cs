﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GameLoopOne.Weapons;

namespace GameLoopOne
{
    class Enemy : GameObject
    {
        
        private float timer = 0;
        public static Weapon currentEnemyWeapon;
        public int health;
        public Enemy(string imagePath, Vector2D startPos, float scaleFactor, Weapon enemyWeapon) : base(imagePath, startPos, scaleFactor)
        {
            currentEnemyWeapon = enemyWeapon;
            GameWorld.objects.Add(currentEnemyWeapon);//Weapon should also be added 
            
            Random hp = new Random();
            health = hp.Next(40, 81);
        }

        

        public override void Update(float fps)
        {
            fps = 1f/fps;
            if (timer > currentEnemyWeapon.AttackSpeed)
            {
                currentEnemyWeapon.AttackRanged();
                timer = 0;
            }
            timer += fps;
            if (health <= 0)
            {
                //GameWorld.GameWeapons.Add(currentEnemyWeapon);//Weapon should also be added
                float x = (position.X - sprite.Width / 2) - 75;
                float y = position.Y - sprite.Height / 2;
                GameWorld.objects.Add(new Impact(new Vector2D(x,y), .5f));
                GameWorld.removeList.Add(currentEnemyWeapon);
                GameWorld.removeList.Add(this);
            }
        }
    }
}
