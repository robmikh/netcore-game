using OpenTK;
using OpenTK.Graphics.OpenGL;
using Robmikh.Graphics;
using System;

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
            GL.Enable(EnableCap.Blend);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Black);
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(0, 0.5f);
            GL.Color3(Color.Blue);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Color3(Color.Green);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();
            GL.Color3(Color.Transparent);
            
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            using (var context = new DrawingContext(ClientSize.Width, ClientSize.Height))
            {
                context.FillRectangle(new System.Drawing.Rectangle(0, ClientSize.Height - 64, 64, 64), new TextureBrush(_texture, new System.Drawing.Rectangle(368, 176, 16, 16)));

                context.FillRectangle(new System.Drawing.Rectangle(0, 0, 384 * 2, 192 * 2), new TextureBrush(_texture));

                context.FillRectangle(new System.Drawing.Rectangle(100, 100, 30, 30), new SolidColorBrush(System.Drawing.Color.Red));
            }

            this.SwapBuffers();
        }

        private Texture _texture;
    }
}
