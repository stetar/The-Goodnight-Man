using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    internal class RPG : Weapon
    {
        //public override float AttackSpeed { get; set; }
        private static string imagePath = "weapons/sprites/rpg1.png;weapons/sprites/rpg2.png;weapons/sprites/rpg3.png;weapons/sprites/rpg4.png";

        private static int weaponIndex = 10;

        public RPG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 48;
            this.AttackSpeed = 1;
            this.animationSpeed = 30;
            meleeRangeX = 100;
            meleeRangeY = 100;
            moveWeaponUp = -60;
            moveWeaponRight = 15;
            
        }
    }
}
