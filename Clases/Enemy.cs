using Godot;
using System;

namespace Taller2.Clases
{
    public partial class Enemy : Character
    {
        public Enemy()
        {
            _health = 3;
            _maxHealth = 3;
        }

        public override void _Ready()
        {
            base._Ready();
        }

        public override void _Process(double delta) { }

        public override void _ReceiveDamage(int damage)
        {
            base._ReceiveDamage(damage);
            if (_health <= 0)
            {
                QueueFree();
            }
        }
    }
}
