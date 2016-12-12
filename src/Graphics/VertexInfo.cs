using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;

namespace Robmikh.Graphics
{
    class VertexInfo
    {
        public System.Drawing.Color Color { get; }
        public OpenTK.Vector2 TexCoordinate { get; }

        public VertexInfo(System.Drawing.Color color, OpenTK.Vector2 texCoordinate)
        {
            Color = color;
            TexCoordinate = texCoordinate;
        }
    }
}