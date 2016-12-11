using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class DrawingContext : IDisposable
    {
        public int CanvasWidth { get; }
        public int CanvasHeight { get; }

        public DrawingContext(GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
            CanvasWidth = gameWindow.Bounds.Width;
            CanvasHeight = gameWindow.Bounds.Height;
        }

        public void Dispose()
        {
            _gameWindow.SwapBuffers();
        }

        private GameWindow _gameWindow;
    }
}