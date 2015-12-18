using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Props
{
    class CratePhys : RigidBodyBox
    {
        
        private static string imagePath = "Props/Crate/Crate.png";
        public CratePhys(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                Player.isGrounded = false;
                if (Player.velocity.Y > 0) // Don't pull player down
                {
                    Player.velocity.Y = 0;
                }
            }
            base.OnCollision(other);
        }
    }
}
