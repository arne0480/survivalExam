using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Idle : IStrategy
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
