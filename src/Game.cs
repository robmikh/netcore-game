using OpenTK;
using OpenTK.Graphics.OpenGL;
using Robmikh.Graphics;
using System;
using System.Collections.Generic;

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
            _tiles = new int[, ]
            {
                {  0,   1,   2,   3,   4,   1,   2,   3,   4,   5},
                { 24, 100, 100, 100, 100, 100, 100, 100, 100,  29},
                { 48, 100, 100, 100, 100, 100, 100, 100, 100,  53},
                { 72, 100, 100, 100, 100, 100, 100, 100, 100,  77},
                { 96, 100, 100, 100, 100, 100, 100, 100, 100, 101},
                { 24, 100, 100, 100, 100, 100, 100, 100, 100,  29},
                { 48, 100, 100, 100, 100, 100, 100, 100, 100,  53},
                { 72, 100, 100, 100, 100, 100, 100, 100, 100,  77},
                { 96, 100, 100, 100, 100, 100, 100, 100, 100, 101},
                {120, 121, 122, 123, 124, 121, 122, 123, 124, 125}
            };
            _spriteSheet = new SpriteSheet(_texture, new OpenTK.Vector2(16, 16));
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
            
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            using (var context = new DrawingContext(ClientSize.Width, ClientSize.Height))
            {
                //context.FillRectangle(new System.Drawing.RectangleF(0, ClientSize.Height - 64, 64, 64), new TextureBrush(_texture, new System.Drawing.RectangleF(16, 16, 16, 16)));

                //context.FillRectangle(new System.Drawing.RectangleF(0, 0, 384 * 2, 192 * 2), new TextureBrush(_texture));

                context.FillRectangle(new System.Drawing.RectangleF(100, 100, 30, 30), new SolidColorBrush(System.Drawing.Color.Red));

                //context.DrawTexture(_texture, new System.Drawing.RectangleF(16, 16, 16, 16),  new System.Drawing.RectangleF(ClientSize.Width - 64, ClientSize.Height - 64, 64, 64));

                using (var spriteBatch = context.CreateSpriteBatch(_texture))
                {
                    for (int x = 0; x < _tiles.GetLength(1); x++)
                    {
                        for (int y = 0; y < _tiles.GetLength(0); y++)
                        {
                            _spriteSheet.Draw(spriteBatch, _tiles[y, x], new Vector2(x * _spriteSheet.SpriteSize.X, y * _spriteSheet.SpriteSize.Y));
                        }
                    }
                }
            }

            this.SwapBuffers();
        }

        private Texture _texture;
        private SpriteSheet _spriteSheet;
        private int[,] _tiles;
    }
}
