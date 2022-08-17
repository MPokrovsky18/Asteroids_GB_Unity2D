using UnityEngine;


namespace Asteroids
{

    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        private MoveTransform _moveTransform;

        private void Start()
        {
            _moveTransform = new MoveTransform(transform, _speed);
        }
        private void Update()
        {
            _moveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

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
