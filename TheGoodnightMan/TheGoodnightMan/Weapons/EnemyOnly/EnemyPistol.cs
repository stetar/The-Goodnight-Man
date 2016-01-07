using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.EnemyOnly
{
    class EnemyPistol : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex;

        EnemyPistol(Vector2D startPos, float scalefactor) : base(imagePath, startPos, scalefactor, weaponIndex)
        {
            damage = 3;
            this.AttackSpeed = 1;
        }
    }
}
