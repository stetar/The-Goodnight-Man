using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class DildoSword : Weapon
    {
        private static string imagePath  = "";
        private static int weaponIndex = 7;

        public DildoSword(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 1;
            this.AttackSpeed = 0.5f;
            this.animationSpeed = 30;
            meleeRange = 1.5f;
        }
    }
}
