using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using OpenTK;

namespace Robmikh.Graphics
{
    class SolidColorBrush : IBrushInternal
    {
        public System.Drawing.Color Color { get; }

        public SolidColorBrush(System.Drawing.Color color)
        {
            Color = color;
        }

        public IEnumerable<VertexInfo> GetVertexInfo(IEnumerable<OpenTK.Vector2> verticies)
        {
            return new VertexInfo[] { new VertexInfo(Color, OpenTK.Vector2.Zero) };
        }
    }
}