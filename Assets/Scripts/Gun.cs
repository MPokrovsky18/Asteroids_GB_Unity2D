using UnityEngine;


namespace Asteroids
{

    internal sealed class Gun : Weapon
    {
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _burrel;

        [SerializeField] private float _force;

        public override void Attack()
        {
            Fire();
        }

        private void Fire()
        {
            var temAmmunition = Instantiate(_bullet, _burrel.position, _burrel.rotation);
            temAmmunition.AddForce(_burrel.up * _force);
        }
    }
}
