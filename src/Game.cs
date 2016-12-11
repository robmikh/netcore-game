using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace netcoregame
{
    class Game : GameWindow
    {
        public Game(int width, int height) : base(width, height)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _texture = TextureLoader.LoadTexture("sheet.png");
        }
        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Draw();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Draw();
        }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Black);
            GL.Viewport(0, 0, Bounds.Width, Bounds.Height);
            
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(0, 0.5f);
            GL.Color3(Color.Blue);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Color3(Color.Green);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();
            GL.Color3(Color.Transparent);
            
            using (var context = new DrawingContext(this))
            {
                _texture.Draw(context, new System.Drawing.Rectangle(0, 0, 16, 16), new System.Drawing.Rectangle(0, 0, 16, 16));
            }
        }

        private Texture _texture;
    }
}
