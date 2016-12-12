using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class TextureBrush : IBrushInternal
    {
        public Texture Texture { get; }
        public System.Drawing.RectangleF SourceRect { get; }

        public TextureBrush(Texture texture)
        {
            Texture = texture;
            SourceRect = new System.Drawing.Rectangle(0, 0, texture.Width, texture.Height);
        }

        public TextureBrush(Texture texture, System.Drawing.RectangleF sourceRect)
        {
            Texture = texture;
            SourceRect = sourceRect;
        }

        public IEnumerable<VertexInfo> GetVertexInfo(IEnumerable<Vector2> verticies)
        {
            var list = new List<VertexInfo>();

            float left = (float)SourceRect.Left;
            float top = (float)Texture.Height - SourceRect.Top;
            float right = (float)SourceRect.Right;
            float bottom = (float)Texture.Height - SourceRect.Bottom;

            float sampleWidth = SourceRect.Width;
            float sampleHeight = SourceRect.Height;
            float textureWidth = Texture.Width;
            float textureHeight = Texture.Height;

            float maxX = float.MinValue;
            float minX = float.MaxValue;
            float maxY = float.MinValue;
            float minY = float.MaxValue;

            var tempVerticies = new List<Vector2>();

            foreach (var vertex in verticies)
            {
                var tempVertex = new Vector2((vertex.X + 1) / 2, (vertex.Y + 1) / 2);
                tempVerticies.Add(tempVertex);

                if (tempVertex.X < minX)
                {
                    minX = tempVertex.X;
                }
                if (tempVertex.X > maxX)
                {
                    maxX = tempVertex.X;
                }

                if (tempVertex.Y < minY)
                {
                    minY = tempVertex.Y;
                }
                if (tempVertex.Y > maxY)
                {
                    maxY = tempVertex.Y;
                }
            }

            foreach (var vertex in tempVerticies)
            {
                var tempVertex = new Vector2((vertex.X - minX) / (maxX - minX), (vertex.Y - minY) / (maxY - minY));

                float x = ((tempVertex.X * sampleWidth) + left) / textureWidth;
                float y = ((tempVertex.Y * sampleHeight) + bottom) / textureHeight;

                y = 1 - y;

                list.Add(new VertexInfo(System.Drawing.Color.Transparent, new Vector2(x, y)));
            }

            return list;
        }
    }
}