using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class CricketPlayer : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 1;

        public CricketPlayer(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 3;
            this.AttackSpeed = 1;
            this.animationSpeed = 30;
            meleeRangeX = 1.2f;
        }
    }
}
