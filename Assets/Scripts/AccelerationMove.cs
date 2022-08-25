using UnityEngine;


namespace Asteroids
{

    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        public AccelerationMove(Rigidbody2D rb, float speed, float acceleration) : base(rb, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
