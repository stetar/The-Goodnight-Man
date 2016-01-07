using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class DildoSword : Weapon
    {
        private static string imagePath = "weapons/sprites/DildoSword1.png;weapons/sprites/DildoSword2.png;weapons/sprites/DildoSword3.png;weapons/sprites/DildoSword4.png";

        private static int weaponIndex = 5;

        public DildoSword(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 5;
            this.AttackSpeed = 0.5f;
            this.animationSpeed = 30;
            meleeRangeX = 40;
            meleeRangeY = 80;
            moveWeaponRight = 20;
            moveWeaponUp = -35;
        }
    }
}
