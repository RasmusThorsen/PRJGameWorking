﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    public class FriendlySpeedUp : Sprite, IPowerUp
    {
        public bool isUsed { get; set; }
        public bool isRemoved { get; set; }

        private Random _rand = new Random();
        private double _currentTime = 0;
        private double _lifeSpan = 5;
        private float _defaultSpeed = 3f;
        private Tank _tank;
        private List<Tank> _tankList;

        public void PowerUp(Tank poweredTank, List<Tank> otherTanks)
        {
            _tankList = otherTanks;
            _tank = otherTanks.Find(e => e.Name == poweredTank.Name);
            _tank.Vehicle.Speed = 6f;
        }

        public override void Update()
        {
            _currentTime += TankGame.GameTime.ElapsedGameTime.TotalSeconds;
            if (_currentTime > _lifeSpan)
            {
                _tankList.Find(e => e.Name == _tank.Name).Vehicle.Speed = _defaultSpeed;
                isRemoved = true;
            }
        }


        public override void LoadContent()
        {
            Texture = TankGame.GlobalContent.Load<Texture2D>("FriendlySpeedUp");
            Origin = new Vector2(Texture.Width/2, Texture.Height/2);
            Position = new Vector2(_rand.Next(TankGame.Graphics.PreferredBackBufferWidth),
                _rand.Next(TankGame.Graphics.PreferredBackBufferHeight));
            Collider = new CircleCollider(this);
            Collider.Center = Position;
        }
    }
}
