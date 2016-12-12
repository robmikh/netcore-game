using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class ColorState : IDrawingState
    {
        public System.Drawing.Color TargetColor { get; }
        public System.Drawing.Color PreviousColor { get; }

        public ColorState(System.Drawing.Color targetColor, System.Drawing.Color previousColor)
        {
            TargetColor = targetColor;
            PreviousColor = previousColor;
        }

        private OpenTK.Color ConvertColor(System.Drawing.Color color)
        {
            var newColor = new OpenTK.Color();
            newColor.A = color.A;
            newColor.R = color.R;
            newColor.B = color.B;
            newColor.G = color.G;

            return newColor;
        }

        public void Apply()
        {
            GL.Color3(ConvertColor(TargetColor));
        }

        public void Undo()
        {
            GL.Color3(ConvertColor(PreviousColor));
        }
    }

    class TextureCapState : IDrawingState
    {
        public TextureCapState(bool desiredState, bool previousState)
        {
            _desiredState = desiredState;
            _previousState = previousState;
        }

        public void Apply()
        {
            ApplyState(_desiredState);
        }

        public void Undo()
        {
            ApplyState(_previousState);
        }

        private void ApplyState(bool value)
        {
            if (value)
            {
                GL.Enable(EnableCap.Texture2D);
            }
            else
            {
                GL.Disable(EnableCap.Texture2D);
            }
        }

        private bool _desiredState;
        private bool _previousState;
    }
}