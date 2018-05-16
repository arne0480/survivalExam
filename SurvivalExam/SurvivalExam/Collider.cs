
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
    class Collider : Component, ILoad, IDraw
    {
        private SpriteRenderer spriteRenderer;
        private Animation animation;
        private Texture2D texture;

        public Collider(GameObject gameObject) : base(gameObject)
        {

        }


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
        public void LoadContent(ContentManager content)
        {
            spriteRenderer = (SpriteRenderer)gameObject.GetComponets("SpriteRenderer");
            texture = content.Load<Texture2D>("Rectangle");
        }


        public void Draw(SpriteBatch spriteBatch)
        {
           
            //Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            //Rectangle bottomLine = new Rectangle(CollisionBox.X, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width, 1);
            //Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y, 1, CollisionBox.Height);
            //Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y, 1, CollisionBox.Height);


            spriteBatch.Draw(texture, CollisionBox, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            //spriteBatch.Draw(texture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            //spriteBatch.Draw(texture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            //spriteBatch.Draw(texture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);


        }

    }
}


