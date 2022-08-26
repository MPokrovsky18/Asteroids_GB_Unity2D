using UnityEngine;


namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;

        private Camera _camera;
        private Ship _ship;
        private InputManager _inputManager;
        private Health _health;


        private Vector3 _moveDirection;
        private Vector3 _rotateDirection;
        public Vector3 MoveDirection { set => _moveDirection = value; }
        public Vector3 RotateDirection { set => _rotateDirection = value; }


        private void Start()
        {
            _camera = Camera.main;
            var rb = GetComponent<Rigidbody2D>();
            var moveTransform = new AccelerationMove(rb, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _health = new Health(_hp, _hp);
            _inputManager = new InputManager(_camera, this, _ship, _weapon);
        }

        private void Update()
        {
            _inputManager.GetInput();
        }

        private void FixedUpdate()
        {
            _ship.Move(_moveDirection.x, _moveDirection.y);
            _ship.Rotation(_rotateDirection);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _health.ChangeCurrentHealth(_health.Current - 1);

            if(_health.Current <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
