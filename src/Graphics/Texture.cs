using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Robmikh.Graphics
{
    class Texture
    {
        public int Id { get; }
        public int Width { get; }
        public int Height { get; }

        public Texture(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }

        public void Draw(DrawingContext context, System.Drawing.Rectangle sourceRect, System.Drawing.Rectangle destRect)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Id);
            GL.Begin(PrimitiveType.Quads);

            // Texture Coordnates:
            //  0 --> 1
            //  ^     |
            //  |     |
            //  |     V
            //  3 <-- 2

            // Vertices:
            //  3 <-- 2
            //  |     ^
            //  |     |
            //  V     |
            //  0 --> 1

            // 0
            GL.TexCoord2((float)sourceRect.Left / Width, (float)sourceRect.Top / Height);
            GL.Vertex2((((float)destRect.Left / context.CanvasWidth) * 2) - 1, (((float)destRect.Bottom / context.CanvasHeight) * 2) - 1);
            // 1
            GL.TexCoord2((float)sourceRect.Right / (float)Width, (float)sourceRect.Top / Height);
            GL.Vertex2((((float)destRect.Right / context.CanvasWidth) * 2) - 1, (((float)destRect.Bottom / context.CanvasHeight) * 2) - 1);
            // 2
            GL.TexCoord2((float)sourceRect.Right / Width, (float)sourceRect.Bottom / Height);
            GL.Vertex2((((float)destRect.Right / context.CanvasWidth) * 2) - 1, (((float)destRect.Top / context.CanvasHeight) * 2) - 1);
            // 3
            GL.TexCoord2((float)sourceRect.Left / Width, (float)sourceRect.Bottom / Height);
            GL.Vertex2((((float)destRect.Left / context.CanvasWidth) * 2) - 1, (((float)destRect.Top / context.CanvasHeight) * 2) - 1);

            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }
    }
}
