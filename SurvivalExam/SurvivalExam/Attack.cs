using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Attack : IStrategy
    {
        Animator animator;
        public Attack(Animator animator)
        {
            this.animator = animator;
        }

        public void Execute(ref DIRECTION currentDirection)
        {
            Vector2 translation = Vector2.Zero;
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.A))
            {
                currentDirection = DIRECTION.Left;
                animator.PlayAnimations("Attack" + currentDirection);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                currentDirection = DIRECTION.Right;
                animator.PlayAnimations("Attack" + currentDirection);
            }
            animator.PlayAnimations("Attack" + currentDirection);
        }
    }
}
