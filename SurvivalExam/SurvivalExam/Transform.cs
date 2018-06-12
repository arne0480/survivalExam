using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Transform : Component
    {
        //  private Vector2 position;
        public Vector2 velocity;

        public Vector2 position { get; set; }

        public Transform(GameObject gameObject, Vector2 position) : base(gameObject)
        {
            this.position = position;
        }

        public void Translate(Vector2 translation)
        {
            position += translation;
        }
        public void CorrectMove(Vector2 Correction)
        {
            position += Correction;
        }
        public void Update()
        {
            position += velocity;
        }
    }
}
