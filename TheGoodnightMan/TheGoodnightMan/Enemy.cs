using System;
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
            
            health = 5; //TODO fix this, this should be overridden in the enemy types

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
                //currentWeapon.Position = this.position;
                //Weapon.gameWeapons.Add(currentWeapon);//Add the enemy weapon to the list of weapons'
                GameWorld.GameWeapons.Add(currentEnemyWeapon);//Weapon should also be added 
                //GameWorld.removeList.Add(currentEnemyWeapon);//remove the weapon from the objects list
                GameWorld.removeList.Add(this);

                //currentEnemyWeapon.DropWeapon(currentEnemyWeapon);
                //Weapon.removeWeapons.Add(currentEnemyWeapon);
                //GameWorld.removeList.Add(Player.currentWeapon);
                //Player.currentWeapon = currentWeapon;

                //GameWorld.objects.Add(new Pistol(this.position, 1));
                // GameWorld.ownedWeapons.Add(new Pistol(this.position, 1));

            }
        }
    }
}
