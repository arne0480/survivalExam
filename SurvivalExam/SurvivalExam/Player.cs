using Microsoft.Xna.Framework;
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
    enum DIRECTION { Left, Right, Down, Up };

    class Player : Component, IAnimateable, IUpdate, ILoad, ICollisionStay, ICollisionEnter, ICollisionExit
    {
        private float speed = 100;
        IStrategy strategy;
        bool canPlayerMove = true;
        Animator animator;
        DIRECTION currentDirection;
        Vector2 translation = Vector2.Zero;


        Collider mycolider;

        public Player(GameObject gameObject) : base(gameObject)
        {


        }
        public void Update()
        {
            mycolider = gameObject.GetComponets("Collider") as Collider;
            //mycolider.SetDoCollisionCheck(true);
            Vector2 translation = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (canPlayerMove)
            {
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.D))
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
                if (keyState.IsKeyDown(Keys.Space))
                {
                    strategy = new Attack(animator);

                    canPlayerMove = false;
                }
            }
            strategy.Execute(ref currentDirection);
        }
        public void OnAnimationDone(string animationName)
        {
            if (animationName.Contains("Walk") || animationName.Contains("Attack"))
            {
                canPlayerMove = true;
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

        public void OnCollisionStay(Collider other)
        {
            //   (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.White;
        }

        public void OnCollisionEnter(Collider other)
        {
            (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.DarkRed;


            //switch (switch_on)
            //{
            //    case LeftCollision:

            //break;

            //}

            //gameObject.transform.Translate(new Vector2((mycolider.CollisionBox.Width - other.gameObject.transform.position.X), 0)); //Venstre Collision
            gameObject.transform.Translate(new Vector2((mycolider.CollisionBox.Height - other.gameObject.transform.position.Y), 0)); //burde være bund collision - Men er venstre collision



            //gameObject.transform.Translate(new Vector2((other.gameObject.transform.position.X - mycolider.CollisionBox.Width), 0)); //Højre collision
            // gameObject.transform.Translate(new Vector2((other.gameObject.transform.position.Y - mycolider.CollisionBox.Height), 0)); //burde være Top collision - Men er højre collision



        }

        public void OnCollisionExit(Collider other)
        {
            (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.White;


        }
    }
}
