using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class CricketPlayer : Weapon
    {
        private static string imagePath = "weapons/sprites/CricketPlayer1.png;weapons/sprites/CricketPlayer2.png;weapons/sprites/CricketPlayer3.png;weapons/sprites/CricketPlayer4.png";

        private static int weaponIndex = 1;

        public CricketPlayer(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 51;
            this.AttackSpeed = 1;
            this.animationSpeed = 30;
            meleeRangeX = 100;
            meleeRangeY = 100;
            moveWeaponUp = -80;
            moveWeaponRight = 10;
        }
    }
}
