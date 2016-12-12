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

        public IEnumerable<PrepVertex> PrepVertexState(IEnumerable<OpenTK.Vector2> verticies)
        {
            return new PrepVertex[] { (c, s) =>
            {
                s.PushColor(Color);
            } };
        }
    }
}