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
        private Vector3 _move;

        private void Update()
        {
            var deltatime = Time.deltaTime;
            var speed = _speed * deltatime;
            _move.Set(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
            transform.localPosition += _move;

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmution = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmution.AddForce(_barrel.up * _force);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_hp <= 0)
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
