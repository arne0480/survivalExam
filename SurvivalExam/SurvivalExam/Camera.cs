﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SurvivalExam
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(SpriteRenderer target)
        {
            Transform = Matrix.CreateTranslation(-target.Position.X - (target.Rectangle.Width / 2), -target.Position.Y - (target.Rectangle.Height / 2),0);
        }
    }
}
