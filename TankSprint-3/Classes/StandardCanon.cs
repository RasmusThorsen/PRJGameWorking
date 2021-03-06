﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class StandardCanon : ICanon
    {
        public float ShootDelay { get; set; } = 0.75f;
        public float CurrentTime { get; set; } = 1;

        public Bullet Shoot(Vector2 direction, Vector2 position)
        {
            if (CurrentTime > ShootDelay)
            {
                CurrentTime = 0f;
                return new Bullet(direction, position);
            }
            return null; 
        }
    }
}
