using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Beaver : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 9;

        public Beaver(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 1;
            this.AttackSpeed = 0.2f;
            this.animationSpeed = 30;
            meleeRange = 0.4f;
        }
    }
}
