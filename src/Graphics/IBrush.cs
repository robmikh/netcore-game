using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;

namespace Robmikh.Graphics
{
    public interface IBrush
    {
        
    }

    internal delegate void PrepVertex(DrawingContext context, DrawingSession session);

    internal interface IBrushInternal : IBrush
    {
        IEnumerable<VertexInfo> GetVertexInfo(IEnumerable<Vector2> verticies);
    }
}