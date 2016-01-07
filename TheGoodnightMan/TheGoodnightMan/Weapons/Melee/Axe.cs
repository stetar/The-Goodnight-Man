using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Axe : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 6;

        public Axe(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 4;
            this.AttackSpeed = 0.6f;
            this.animationSpeed = 30;
            meleeRangeX = 40;
            meleeRangeY = 80;
        }
    }
}
