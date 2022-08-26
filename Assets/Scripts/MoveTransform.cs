using UnityEngine;


namespace Asteroids
{

    internal class MoveTransform : IMove
    {
        private readonly Rigidbody2D _rb;
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MoveTransform(Rigidbody2D rb, float speed)
        {
            _rb = rb;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical)
        {
            _move.Set(horizontal, vertical, 0.0f);
            _move.Normalize();
            _rb.AddForce(_move * Speed, ForceMode2D.Force);
        }
    }
}
