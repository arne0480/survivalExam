﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Enemy : Component, IAnimateable, IUpdate, ILoad
    {
        private float speed = 100;
        IStrategy strategy;
        bool canMove = true;
        Animator animator;
        DIRECTION currentDirection;

        public Enemy(GameObject gameObject) : base(gameObject)
        {


        }
        public void Update()
        {
            Vector2 translation = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (canMove)
            {
                if (keyState.IsKeyDown(Keys.I) || keyState.IsKeyDown(Keys.L) || keyState.IsKeyDown(Keys.K) || keyState.IsKeyDown(Keys.J))
                {
                    if (!(strategy is Walk))
                    {
                        strategy = new Walk(gameObject.transform, animator, gameObject, speed);
                    }
                }

                else
                {
                    strategy = new Idle(animator);
                }
                if (keyState.IsKeyDown(Keys.RightShift))
                {
                    strategy = new Attack(animator);

                    canMove = false;
                }
            }
            strategy.Execute(ref currentDirection);
        }
        public void OnAnimationDone(string animationName)
        {
            if (animationName.Contains("Walk") || animationName.Contains("Attack"))
            {
                canMove = true;
            }
        }
        public void CreatAnimation()
        {
            animator.CreateAnimation("IdleLeft", new Animation(6, 320, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("IdleRight", new Animation(6, 80, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("WalkLeft", new Animation(8, 240, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("WalkRight", new Animation(8, 0, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("WalkUp", new Animation(8, 0, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("WalkDown", new Animation(8, 0, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("IdleUp", new Animation(6, 80, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("IdleDown", new Animation(6, 80, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("AttackRight", new Animation(7, 160, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("AttackLeft", new Animation(7, 400, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("AttackUp", new Animation(7, 160, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("AttackDown", new Animation(7, 160, 0, 80, 80, 7, new Vector2(0, 0)));

            //animator.CreateAnimation("DieLeft", new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero));
            //animator.CreateAnimation("DieRight", new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero));

        }
        public void LoadContent(ContentManager content)
        {

            animator = (Animator)gameObject.GetComponets("Animator");

            CreatAnimation();

            animator.PlayAnimations("IdleRight");
        }
    }
}