using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.EnemyOnly
{
    class EnemyLMG : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex;

        EnemyLMG(Vector2D startPos, float scalefactor) : base(imagePath, startPos, scalefactor, weaponIndex)
        {
            damage = 10;
            this.AttackSpeed = 0.8f;
        }
    }
}
