using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Guitar : Weapon
    {
        private static string imagePath = "";

        public Guitar(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 2;
            this.AttackSpeed = 0.7f;
            this.animationSpeed = 30;
            meleeRange = .8f;
        }
    }
}
