using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class DrawingSession : IDisposable
    {
        public DrawingSession(DrawingContext context, PrimitiveType mode, Texture texture = null)
        {
            _context = context;
            _stack = new Stack<IDrawingState>();
            _lastColor = System.Drawing.Color.Transparent;
            _lastTextureCapState = false;

            if (texture != null)
            {
                PushTextureCap(true);
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            }

            GL.Begin(mode);
        }

        public void PushColor(System.Drawing.Color color)
        {
            if (color != _lastColor)
            {
                var state = new ColorState(color, _lastColor);
                state.Apply();
                _stack.Push(state);
                _lastColor = color;
            }
        }

        public void PushTextureCap(bool value)
        {
            if (value != _lastTextureCapState)
            {
                var state = new TextureCapState(value, _lastTextureCapState);
                state.Apply();
                _stack.Push(state);
                _lastTextureCapState = value;
            }
        }

        public void Dispose()
        {
            GL.End();

           while (_stack.Count > 0)
           {
               var state = _stack.Pop();
               state.Undo();
           }
        }

        private DrawingContext _context;
        private Stack<IDrawingState> _stack;
        private System.Drawing.Color _lastColor;
        private bool _lastTextureCapState;
    }
}