using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApplication
{
    class Game : GameWindow
    {
        public Game(int width, int height) : base(width, height)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(0, 0.5f);
            GL.Color3(Color.Blue);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Color3(Color.Green);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();

            this.SwapBuffers();
        }
    }
}
