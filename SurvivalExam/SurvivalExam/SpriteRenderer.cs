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

        Texture2D Sprite { get; set; }
        string pictureName;
        float layer;
        public Color Color { get; set; } = Color.White;
        private float scale;
        public Vector2 Offset { get; set; }
        private GameObject gameObject;

        public Rectangle Rectangle { get; set; }

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
            Sprite = content.Load<Texture2D>(pictureName);
            this.rectangle = new Rectangle(0, 0, Sprite.Width, Sprite.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(Sprite, gameObject.transform.position + Offset, Rectangle, Color, 0, Vector2.Zero, 1, SpriteEffects.None, layer);

        }
    }
}
