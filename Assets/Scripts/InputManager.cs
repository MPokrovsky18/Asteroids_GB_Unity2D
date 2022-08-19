using UnityEngine;


namespace Asteroids
{

    internal sealed class InputManager
    {
        private Ship _ship;
        private Weapon _weapon;
        private Camera _camera;
        private Transform _playerTransform;

        public InputManager(Camera camera, Ship ship, Weapon weapon, Transform playerTransform)
        {
            _camera = camera;
            _ship = ship;
            _weapon = weapon;
            _playerTransform = playerTransform;
        }

        public void GetInput()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerTransform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _weapon.Attack();
            }
        }
    }
}
