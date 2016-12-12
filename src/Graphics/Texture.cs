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
    }
}
