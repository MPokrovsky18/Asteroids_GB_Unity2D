using UnityEngine;


namespace Asteroids
{

    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        private IMove _moveTransform;

        private void Start()
        {
            _moveTransform = new AccelerationMove(transform, _speed, _acceleration);
        }
        private void Update()
        {
            _moveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {

                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmution = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmution.AddForce(_barrel.up * _force);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}
