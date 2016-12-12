using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Robmikh.Graphics
{
    class SpriteSheet
    {
        public Texture Texture { get; }
        public Vector2 SpriteSize { get; }

        internal SpriteSheet(Texture texture, Vector2 spriteSize)
        {
            Texture = texture;
            SpriteSize = spriteSize;
            _spritesPerRow = (int)(texture.Width / spriteSize.X);
        }

        public void Draw(SpriteBatch spriteBatch, int sprite, Vector2 position)
        {
            if (spriteBatch.Texture.Id != Texture.Id) throw new ArgumentException($"Texture in sprite batch (id {spriteBatch.Texture.Id}) does not match sprite sheet (id {Texture.Id})!");
            if (sprite < 0) return;
            spriteBatch.DrawSprite(GetSourceRect(sprite), new System.Drawing.RectangleF(position.X, position.Y, SpriteSize.X, SpriteSize.Y));
        }

        private System.Drawing.RectangleF GetSourceRect(int sprite)
        {
            int row = sprite / _spritesPerRow;
            int column = sprite % _spritesPerRow;

            return new System.Drawing.RectangleF(
                (float)(SpriteSize.X * column),
                (float)(SpriteSize.Y * row),
                (float)SpriteSize.X,
                (float)SpriteSize.Y);
        }

        private int _spritesPerRow;
    }
}