using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class SMG : Weapon
    {
        private static string imagePath = "weapons/sprites/UZI1.png;weapons/sprites/UZI2.png;weapons/sprites/UZI3.png;weapons/sprites/UZI4.png";

        private static int weaponIndex = 11;

        public SMG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 38;
            this.AttackSpeed = 1;
            this.animationSpeed = 30;
            meleeRangeX = 100;
            meleeRangeY = 100;
            moveWeaponUp = -40;
            moveWeaponRight = 15;
        }
    }
}
