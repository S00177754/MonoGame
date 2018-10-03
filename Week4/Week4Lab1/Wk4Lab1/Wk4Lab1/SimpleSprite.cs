﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprites
{
    public class SimpleSprite
    {
        public Texture2D Image;
        public Vector2 Position;
        public Rectangle BoundingRect;
        public bool Visible = true;

        public SimpleSprite(Texture2D spriteImage,
                            Vector2 startPosition)
        {
            Image = spriteImage;
            Position = startPosition;
            BoundingRect = new Rectangle((int)startPosition.X, (int)startPosition.Y, Image.Width, Image.Height);

        }

        public void draw(SpriteBatch sp)
        {
            if(Visible)
                sp.Draw(Image, Position, Color.White);
        }

        public void Move(Vector2 delta)
        {
            Position += delta;
            BoundingRect = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            BoundingRect.X = (int)Position.X;
            BoundingRect.Y = (int)Position.Y;
        }

        public bool IsIntersecting(SimpleSprite other)
        {
            return BoundingRect.Intersects(other.BoundingRect);
        }

        public void drawString(SpriteBatch sp, SpriteFont sf, string Message)
        {
            if (Visible)
                sp.DrawString(sf, Message, this.Position + new Vector2(0, -50), Color.White);
        }
    }
}
