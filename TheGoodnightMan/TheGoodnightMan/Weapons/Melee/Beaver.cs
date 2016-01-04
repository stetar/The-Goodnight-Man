using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Beaver : Weapon
    {
        private static string imagePath = "weapons/sprites/Beaver1.png;weapons/sprites/Beaver2.png;weapons/sprites/Beaver3.png;weapons/sprites/Beaver4.png";
        
        private static int weaponIndex = 9;

        public Beaver(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 2;
            this.AttackSpeed = 0.7f;
            this.animationSpeed = 30;
            meleeRangeX = 50f;
            meleeRangeY = 100f;

            this.moveWeaponRight = 20;
            moveWeaponUp = -30;
        }
    }
}
