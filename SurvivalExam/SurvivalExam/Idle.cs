using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Idle : Interfaces.IStrategy
    {
        Animator animator;
        public Idle(Animator animator)
        {
            this.animator = animator;
        }

        public void Execute(ref DIRECTION currentDirection)
        {
            animator.PlayAnimations("Idle" + currentDirection);
        }
    }
}
