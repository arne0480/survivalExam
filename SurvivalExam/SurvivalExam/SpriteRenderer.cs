using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SurvivalExam
{
    class SpriteRenderer : Component, IDraw, ILoad
    {
        private Rectangle rectangle;

        Texture2D sprite;
        string pictureName;
        float layer;
        private float scale;
        public Vector2 offset;
        private GameObject gameObject;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
        public SpriteRenderer(GameObject gameObject, string pictureName, float layer, float scale) : base(gameObject)
        {
            this.pictureName = pictureName;
            this.layer = layer;
            this.scale = scale;
            this.gameObject = gameObject;
        }
        public void Update()
        {

        }
        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(pictureName);
            this.rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, gameObject.GetTransform.Position, rectangle, Color.White, 0, -offset, scale, SpriteEffects.None, layer);
        }
    }
}
