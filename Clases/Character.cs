using Godot;
using System;

namespace Taller2.Clases
{
    public partial class Character : CharacterBody2D
    {
        public float Speed = 100f;
        protected int _health = 3;
        protected int _maxHealth = 3;
        public int Damage = 1;
        protected AnimatedSprite2D _animator;
        protected Sprite2D _barFill;
        private Vector2 _barOriginalScale;
        private Vector2 _barOriginalPosition;

        public override void _Ready()
        {
            _animator = GetNode<AnimatedSprite2D>("Animator");
            _animator.Play("default");

            if (HasNode("HealthBar/BarFill"))
            {
                _barFill = GetNode<Sprite2D>("HealthBar/BarFill");
                _barOriginalScale = _barFill.Scale;
                _barOriginalPosition = _barFill.Position;
            }
        }

        public override void _Process(double delta) { }

        public virtual void _ReceiveDamage(int damage)
        {
            _health -= damage;
            GD.Print("Vida restante: " + _health);

            if (_barFill != null)
            {
                float percent = (float)_health / _maxHealth;
                _barFill.Scale = new Vector2(_barOriginalScale.X * percent, _barOriginalScale.Y);
                _barFill.Position = new Vector2(
                    _barOriginalPosition.X - (_barOriginalScale.X * (1 - percent) / 2),
                    _barOriginalPosition.Y
                );
            }
        }
    }
}