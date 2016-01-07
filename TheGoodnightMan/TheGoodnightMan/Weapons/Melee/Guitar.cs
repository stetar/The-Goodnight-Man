using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Guitar : Weapon
    {
        private static string imagePath = "weapons/sprites/Guitar1.png;weapons/sprites/Guitar2.png;weapons/sprites/Guitar3.png;weapons/sprites/Guitar4.png";

        private static int weaponIndex = 3;

        public Guitar(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 29;
            this.AttackSpeed = 0.7f;
            this.animationSpeed = 30;
            meleeRangeX = 75f;
            meleeRangeY = 100f;

            this.moveWeaponRight = 20;
            moveWeaponUp = -30;
        }
    }
}
