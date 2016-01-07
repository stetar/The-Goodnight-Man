using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class LMG : Weapon
    {
        private static string imagePath = "weapons/sprites/LMG1.png;weapons/sprites/LMG2.png;weapons/sprites/LMG3.png;weapons/sprites/LMG4.png";

        private static int weaponIndex = 12;

        public LMG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 42;
            this.AttackSpeed = 1;
            this.animationSpeed = 30;
            meleeRangeX = 100;
            meleeRangeY = 100;
            moveWeaponUp = -40;
            moveWeaponRight = 0;
        }
    }
}
