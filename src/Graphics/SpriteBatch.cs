using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class SpriteBatch : IDisposable
    {
        public Texture Texture { get; }

        internal SpriteBatch(DrawingContext context, Texture texture)
        {
            Texture = texture;
            _context = context;
            _batches = new List<Tuple<IEnumerable<Vector2>, IEnumerable<Vector2>>>();
        }

        public void DrawSprite(System.Drawing.RectangleF sourceRect, System.Drawing.RectangleF destRect)
        {
            var vertices = _context.BuildVertices(destRect);
            var texCoords = _context.BuildTexCoordinates(Texture.Width, Texture.Height, sourceRect);

            _batches.Add(new Tuple<IEnumerable<Vector2>, IEnumerable<Vector2>>(vertices, texCoords));
        }

        public void Dispose()
        {
            using (var drawingSession = new DrawingSession(_context, PrimitiveType.Quads, Texture))
            {
                foreach (var tuple in _batches)
                {
                    var vertices = tuple.Item1;
                    var texCoords = tuple.Item2;
                    _context.DrawTexture(vertices, texCoords);
                }
            }
        }

        private DrawingContext _context;
        private List<Tuple<IEnumerable<Vector2>, IEnumerable<Vector2>>> _batches;
    }
}