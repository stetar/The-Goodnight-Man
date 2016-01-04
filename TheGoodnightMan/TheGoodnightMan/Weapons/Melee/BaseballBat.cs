using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class BaseballBat : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 6;

        public BaseballBat(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 3;
            this.AttackSpeed = 0.5f;
            this.animationSpeed = 30;
            meleeRange = 1;
        }
    }
}
