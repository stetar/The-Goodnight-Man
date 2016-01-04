using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class LMG : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 14;

        public LMG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 10;
            this.AttackSpeed = 0.8f;
        }
    }
}
