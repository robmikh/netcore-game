using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class DrawingContext : IDisposable
    {
        public int CanvasWidth { get; }
        public int CanvasHeight { get; }

        public DrawingContext(int width, int height)
        {
            CanvasWidth = width;
            CanvasHeight = height;
        }

        public SpriteBatch CreateSpriteBatch(Texture texture)
        {
            return new SpriteBatch(this, texture);
        }

        public void FillRectangle(System.Drawing.RectangleF rectangle, IBrush brush)
        {
            var brushInternal = brush as IBrushInternal;

            if (brushInternal == null)
            {
                throw new ArgumentException("Brush is invalid.");
            }

            var vertices = BuildVertices(rectangle);
            var vertexInfo = brushInternal.GetVertexInfo(vertices);

            Texture texture = null;
            if (brush is TextureBrush)
            {
                texture = (brush as TextureBrush).Texture;
            }

            using (var session = new DrawingSession(this, PrimitiveType.Quads, texture))
            {
                if (brush is SolidColorBrush)
                {
                    session.PushColor(vertexInfo.First().Color);
                }

                for (int i = 0; i < vertices.Count<Vector2>(); i++)
                {
                    var vertex = vertices.ElementAt(i);
                    if (brush is TextureBrush)
                    {
                        var info = vertexInfo.ElementAt(i);
                        GL.TexCoord2(info.TexCoordinate.X, info.TexCoordinate.Y);
                    }
                    GL.Vertex2(vertex.X, vertex.Y);
                }
            }
        }

        public void DrawTexture(Texture texture, System.Drawing.RectangleF sourceRect, System.Drawing.RectangleF destRect)
        {
            var vertices = BuildVertices(destRect);
            var texCoords = BuildTexCoordinates(texture.Width, texture.Height, sourceRect);

            using (var session = new DrawingSession(this, PrimitiveType.Quads, texture))
            {
                DrawTexture(vertices, texCoords);
            }
        }

        internal IEnumerable<Vector2> BuildTexCoordinates(int textureWidth, int textureHeight, System.Drawing.RectangleF sourceRect)
        {
            float left = (float)sourceRect.Left;
            float top = (float)textureHeight - sourceRect.Top;
            float right = (float)sourceRect.Right;
            float bottom = (float)textureHeight - sourceRect.Bottom;

            left /= (float)textureWidth;
            top /= (float)textureHeight;
            right /= (float)textureWidth;
            bottom /= (float)textureHeight;

            var texCoords = new List<OpenTK.Vector2>();
            texCoords.Add(new Vector2(left, 1 - bottom));
            texCoords.Add(new Vector2(left, 1 - top));
            texCoords.Add(new Vector2(right, 1 - top));
            texCoords.Add(new Vector2(right, 1 - bottom));

            return texCoords;
        }

        internal void DrawTexture(IEnumerable<Vector2> vertices, IEnumerable<Vector2> texCoords)
        {
            for (int i = 0; i < vertices.Count<Vector2>(); i++)
            {
                var vertex = vertices.ElementAt(i);
                var textCoord = texCoords.ElementAt(i);
                GL.TexCoord2(textCoord.X, textCoord.Y);
                GL.Vertex2(vertex.X, vertex.Y);
            }
        }

        internal IEnumerable<Vector2> BuildVertices(System.Drawing.RectangleF rectangle)
        {
            var vertices = new List<Vector2>();

            // When we receive the Rectangle, it will have its origin in the top left
            // like in Direct3D\Direct2D. Translate it to the bottom left for use with OpenGL.
            float left = rectangle.Left;
            float top = CanvasHeight - rectangle.Top;
            float right = rectangle.Right;
            float bottom = CanvasHeight - rectangle.Bottom;

            // Vertices:
            //  1 --> 2
            //  ^     ^
            //  |     |
            //  |     V
            //  0 <-- 3

            // 0
            vertices.Add(new Vector2(((left / CanvasWidth) * 2) - 1, ((bottom / CanvasHeight) * 2) - 1));
            // 1
            vertices.Add(new Vector2(((left / CanvasWidth) * 2) - 1, ((top / CanvasHeight) * 2) - 1));
            // 2
            vertices.Add(new Vector2(((right / CanvasWidth) * 2) - 1, ((top / CanvasHeight) * 2) - 1));
            // 3
            vertices.Add(new Vector2(((right / CanvasWidth) * 2) - 1, ((bottom / CanvasHeight) * 2) - 1));

            return vertices;
        }

        public void Dispose()
        {
           
        }
    }
}