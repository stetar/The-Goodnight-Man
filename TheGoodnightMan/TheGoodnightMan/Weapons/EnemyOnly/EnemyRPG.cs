using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.EnemyOnly
{
    class EnemyRPG : Weapon
    {
        private static string imagePath = "Weapons/Sprites/EnemySprites/RPG1.png";
        private static int weaponIndex;

        public EnemyRPG(Vector2D startPos, float scalefactor) : base(imagePath, startPos, scalefactor, weaponIndex)
        {
            damage = 10;
            this.AttackSpeed = 2;
        }
    }
}
