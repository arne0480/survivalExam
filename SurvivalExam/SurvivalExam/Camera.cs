using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SurvivalExam
{
    class Camera
    {
        public Matrix viewMatrix;
        private Vector2 m_position;
        private Vector2 m_halfViewSize;

        public Camera(Rectangle clientRect)
        {
            m_halfViewSize = new Vector2(clientRect.Width * 0.5f, clientRect.Height * 0.5f);
        }

        public Vector2 Pos
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
                UpdateViewMatrix();
            }
        }

        private void UpdateViewMatrix()
        {
            throw new NotImplementedException();
        }

        private void UpdateViewMatix()
        {
            viewMatrix = Matrix.CreateTranslation(m_halfViewSize.X - m_position.X, m_halfViewSize.Y - m_position.Y, 0.0f);
        }
    }
}
