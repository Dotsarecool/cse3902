﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class MazeFinish : IBlock
    {
        public IAnimatedSprite Sprite { get; set; }
        public ITangibleState State { get; set; }
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        public List<MazeCheckpoint> checkpoints;

        public MazeFinish(int x = 0, int setback = 0)
        {
            this.Position = new Vector2(x, 0);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(0, 0);
            this.State = new SMazeFinishIdle(this);
            this.Sprite = new Animation(Textures.princess);
            this.IsActive = true;
            this.CollisionHandler = new MazeFinishCollisionHandler(this, setback);
            this.checkpoints = new List<MazeCheckpoint>();
        }
        public void Update()
        {
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            //Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }

        public void AddCheckpoint(MazeCheckpoint c)
        {
            checkpoints.Add(c);
        }
    }
}
