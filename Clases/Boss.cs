using Godot;
using System;

namespace Taller2.Clases
{
    public partial class Boss : Character
    {
        public Boss()
        {
            _health = 10;
            _maxHealth = 10;
            Damage = 3;
            Speed = 50f;
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