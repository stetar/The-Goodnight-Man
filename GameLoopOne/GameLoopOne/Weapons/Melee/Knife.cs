using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Knife : Weapon
    {
        private static string imagePath = "";

        public Knife(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 2;
            this.AttackSpeed = 0.4f;
            this.animationSpeed = 30;
            meleeRange = 0.5f;
        }
    }
}
