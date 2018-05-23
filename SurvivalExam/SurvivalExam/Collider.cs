using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SurvivalExam
{
    class Collider : Component, ILoad, IDraw, IUpdate
    {
        private SpriteRenderer spriteRenderer;
        private Texture2D texture;

        private HashSet<Collider> otherCollider = new HashSet<Collider>();



        public bool CheckCollisions { get; set; }


        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle
                    (
                        (int)(gameObject.transform.Position.X + spriteRenderer.Offset.X),
                        (int)(gameObject.transform.Position.Y + spriteRenderer.Offset.Y),
                        spriteRenderer.Rectangle.Width,
                        spriteRenderer.Rectangle.Height
                    );
            }
        }
        public Collider(GameObject gameObject) : base(gameObject)
        {
            CheckCollisions = true;


            GameWorld.Instance.getColliders.Add(this);

        }

        public void LoadContent(ContentManager content)
        {
            spriteRenderer = (SpriteRenderer)gameObject.GetComponets("SpriteRenderer");

            texture = content.Load<Texture2D>("CollisionTexture");
        }


        public void Draw(SpriteBatch spriteBatch)
        {


            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y, 1, CollisionBox.Height);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y, 1, CollisionBox.Height);

            spriteBatch.Draw(texture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public void Update()
        {
            CheckCollision();
        }
        private void CheckCollision()
        {
            if (CheckCollisions)
            {
                foreach (Collider other in GameWorld.Instance.getColliders)
                {
                    if (other != this)
                    {
                        if (CollisionBox.Intersects(other.CollisionBox))
                        {
                            gameObject.OnCollisionStay(other);

                            if (!otherCollider.Contains(other))
                            {
                                otherCollider.Add(other);
                                gameObject.OnCollissionEnter(other);
                            }

                        }
                        else if (otherCollider.Contains(other))
                        {
                            otherCollider.Remove(other);
                            gameObject.OnCollisionExit(other);
                        }
                    }
                }
            }
        }
    }
}
