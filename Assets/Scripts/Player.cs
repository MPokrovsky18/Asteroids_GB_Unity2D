using UnityEngine;


namespace Asteroids
{

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

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _health = new Health(_hp);
            _inputManager = new InputManager(_camera, _ship, _weapon, transform);

        }
        private void Update()
        {
            _inputManager.GetInput();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_health.CheckIsDied(damage: 1))
            {
                Destroy(gameObject);
            }
        }
    }
}
