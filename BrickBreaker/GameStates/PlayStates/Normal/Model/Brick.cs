﻿using BrickBreaker.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SDSMTGDT.GWorks.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.GameStates.PlayStates.Normal.Model
{
    class Brick : CollidableGameObject
    {
        internal bool destroyed { get; set; }
        internal Color color { get; private set; }
        internal float upperRightAngle {get; private set;}

        internal Brick(GraphicsDevice device, Color color, Rectangle bounds, CollisionManager collisions) : 
            base(bounds, setUpTexture(device, bounds), collisions)
        {
            destroyed = false;
            this.color = color;
            this.upperRightAngle = (float)Math.Atan2(-bounds.Height, bounds.Width);
        }

        private static Texture2D setUpTexture(GraphicsDevice device, Rectangle rectangle)
        {
            Texture2D tex = new Texture2D(device, rectangle.Width, rectangle.Height);
            tex.SetData(Enumerable.Repeat(Color.White, rectangle.Width * rectangle.Height).ToArray());
            return tex;
        }
   }
}
