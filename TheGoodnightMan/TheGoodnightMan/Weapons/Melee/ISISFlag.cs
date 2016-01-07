using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class ISISFlag : Weapon
    {
        private static string imagePath = "weapons/sprites/ISISFlag1.png;weapons/sprites/ISISFlag2.png;weapons/sprites/ISISFlag3.png;weapons/sprites/ISISFlag4.png";

        private static int weaponIndex = 8;

        public ISISFlag(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 5;
            this.AttackSpeed = 0.1f;
            this.animationSpeed = 30;
            meleeRangeX = 80;
            meleeRangeY = 80;
            this.moveWeaponRight = 20;
            moveWeaponUp = -28;
        }
    }
}
