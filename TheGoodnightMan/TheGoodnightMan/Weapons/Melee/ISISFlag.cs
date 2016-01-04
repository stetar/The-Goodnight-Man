using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class ISISFlag : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 10;

        public ISISFlag(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 2;
            this.AttackSpeed = 0.1f;
            this.animationSpeed = 30;
            meleeRange = 0.6f;
        }
    }
}
