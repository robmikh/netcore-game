using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace netcoregame
{
    class DrawingContext : IDisposable
    {
        public int CanvasWidth { get; }
        public int CanvasHeight { get; }

        public DrawingContext(GameWindow gameWindow)
        {
            CanvasWidth = gameWindow.Bounds.Width;
            CanvasHeight = gameWindow.Bounds.Height;
        }

        public void Dispose()
        {

        }
    }
}