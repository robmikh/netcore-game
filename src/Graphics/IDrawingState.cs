using System;
using System.Drawing;

namespace Robmikh.Graphics
{
    interface IDrawingState
    {
        void Apply();
        void Undo();
    }
}