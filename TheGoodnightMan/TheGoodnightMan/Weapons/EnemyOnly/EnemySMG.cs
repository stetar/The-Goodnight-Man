using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.EnemyOnly
{
    class EnemySMG : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex;

        EnemySMG(Vector2D startPos, float scalefactor) : base(imagePath, startPos, scalefactor, weaponIndex)
        {
            damage = 3;
            this.AttackSpeed = .4f;
        }
    }
}
