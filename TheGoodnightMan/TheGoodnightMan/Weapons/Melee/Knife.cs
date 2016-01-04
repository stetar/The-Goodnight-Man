namespace GameLoopOne.Weapons.Melee
{
    internal class Knife : Weapon
    {
        //public override float AttackSpeed { get; set; }
        private static string imagePath ="weapons/sprites/KnifeSprite1.png;weapons/sprites/KnifeSprite2.png;weapons/sprites/KnifeSprite3.png;weapons/sprites/KnifeSprite4.png";
        private static int weaponIndex = 3;

        public Knife(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
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