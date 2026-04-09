using Godot;
using System;

namespace Taller2.Clases
{
    public partial class Hero : Character
    {
        protected Timer _attackTimer;
        protected Area2D _hitbox;
        protected Character _target;
        protected Timer _killTimer;

        public override void _Ready()
        {
            base._Ready();
            _attackTimer = GetNode<Timer>("AttackTimer");
            _killTimer = GetNode<Timer>("KillTimer");
            _hitbox = GetNode<Area2D>("HitBox");
        }

        public override void _Process(double delta)
        {
            Vector2 moveVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            Velocity = moveVector * Speed;
            MoveAndSlide();

            if (moveVector.X > 0)
                PlayAnimation("moveright");
            else if (moveVector.X < 0)
                PlayAnimation("moveleft");

            if (Input.IsActionPressed("ui_attack"))
            {
                PlayAnimation("attack");
                _hitbox.Monitoring = true;
                _attackTimer.Start();
                _killTimer.Start();
            }
        }

        private void PlayAnimation(string animation)
        {
            if (!(_animator.Animation == animation))
                _animator.Play(animation);
        }

        private void _OnHitBoxAttack(Node2D body)
        {
            if (body == this) return;
            GD.Print("Atacando");
            _target = body as Character;
        }

        private void _ResetAttack()
        {
            PlayAnimation("default");
            _hitbox.Monitoring = false;
            _attackTimer.Stop();
        }

        private void _OnKillEnemy()
        {
            if (_target != null)
                _target._ReceiveDamage(Damage);
            _killTimer.Stop();
        }
    }
}