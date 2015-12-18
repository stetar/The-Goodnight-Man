using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Crowbar : Weapon
    {
        private static string imagePath = "";

        public Crowbar(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 1;
            this.AttackSpeed = 0.3f;
            this.animationSpeed = 30;
            meleeRange = 0.8f;
        }
    }
}
