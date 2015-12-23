using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoopOne.Weapons
{
    internal abstract class Weapon : GameObject
    {
        public int damage = 1;
        protected string imagePath;
        public float AttackSpeed = 0;
        private GameObject targetPlayer;
        private bool didAttack = false;
        public int meleeRange = 1;
        public float moveWeaponUp = 0;
        public float moveWeaponRight = 0;
        private Graphics attackRange;



        public enum Weapons
        {
            Wrench,
            CricketPlayer,
            Crowbar,
            Knife,
            Guitar,
            Katana,
            BaseballBat,
            DildoSword,
            Axe,
            Beaver,
            ISISFlag,
            //rifles - enemy only
            AssualtRifle,
            RPG,
            SMG,
            LMG,
            Shotgun,
            Pistol
        }
        public Weapon(string imagePath, Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            didAttack = false;
        }
        public RectangleF attackRangeBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, 50 * meleeRange, 50);
            }
        }
        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
#if DEBUG
            dc.DrawRectangle(new Pen(Brushes.Red), position.X, position.Y, attackRangeBox.Width, attackRangeBox.Height);//don't draw the actual range in release
#endif
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
        }

        public virtual void AttackMelee()
        {
            float x = position.X - 80;
            float y = position.Y - 50;
            didAttack = true;

            foreach (GameObject go in GameWorld.objects.ToList()) //ToList so we can modify it
            {
                if (go is Enemy)
                {
                    
                    Enemy e1 = go as Enemy;
                    if (attackRangeBox.IntersectsWith(go.CollisionBox))
                    {
                        e1.health -= damage;
                        GameWorld.objects.Add(new Impact(new Vector2D(x, y), .5f));

                    }
                }
            }
        }
        
        //public virtual void DropWeapon(Weapon weapon)
        //{
        //    switch (weapon.ToString())//hack
        //    {
        //        case "GameLoopOne.Weapons.Wrench":
        //            gameWeapons.Add(new Wrench(new Vector2D(weapon.position.X, weapon.position.Y), .3f));
        //            break;
        //        case "GameLoopOne.Weapons.Knife":
        //            gameWeapons.Add(new Knife(new Vector2D(weapon.position.X, weapon.position.Y), .3f));
        //            break;
        //        case "GameLoopOne.Weapons.Pistol":
        //            gameWeapons.Add(new Pistol(new Vector2D(weapon.position.X, weapon.position.Y), .3f));
        //            break;
        //    }
        //}



        public virtual void AttackRanged()
        {
            foreach (GameObject player in GameWorld.objects)
            {
                if (player is Player)
                {
                    targetPlayer = player;
                }
            }
            float x = position.X + 30;
            float y = position.Y - 20;
            Vector2D bulletStartPos = new Vector2D(x, y);
            GameWorld.objects.Add(new Bullet("bullet.png", bulletStartPos, 1, 150, targetPlayer));
        }

     
        /// <summary>
        /// override of UpdateAnimation, as the weapon should not loop it's animation
        /// </summary>
        /// <param name="fps"></param>
        public override void UpdateAnimation(float fps)
        {
            float factor = 1 / fps;

            if (didAttack)
            {
                currentFrameIndex += factor * animationSpeed;
                if (currentFrameIndex >= animationFrames.Count)
                {
                    currentFrameIndex = 0;
                    didAttack = false;
                }
                sprite = animationFrames[(int)currentFrameIndex];
            }
            //base.Update(fps);
        }

        public static implicit operator Weapon(string v)
        {
            throw new NotImplementedException();
        }
    }
}
