using UnityEngine;
using UnityEngine.Events;

namespace Asteroids
{

    internal sealed class InputManager
    {
        private Camera _camera;
        private Player _player;
        private Ship _ship;
        private Weapon _weapon;

        public InputManager(Camera camera, Player player, Ship ship, Weapon weapon)
        {
            _camera = camera;
            _player = player;
            _ship = ship;
            _weapon = weapon;
        }

        public void GetInput()
        {
            _player.MoveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            var rotateDirection = Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position);
            _player.RotateDirection = new Vector3(rotateDirection.x, rotateDirection.y, rotateDirection.z);

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
