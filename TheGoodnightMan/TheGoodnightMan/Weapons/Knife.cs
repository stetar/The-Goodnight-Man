using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons
{
    internal class Knife : Weapon
    {
        //public override float AttackSpeed { get; set; }
        private static string imagePath ="weapons/sprites/KnifeSprite1.png;weapons/sprites/KnifeSprite2.png;weapons/sprites/KnifeSprite3.png;weapons/sprites/KnifeSprite4.png";

        public Knife(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 1;
            this.AttackSpeed = 0.5f;
            this.animationSpeed = 30;
            meleeRange = 1;
            moveWeaponUp = 2;
            moveWeaponRight = 20;
            
        }
    }
}