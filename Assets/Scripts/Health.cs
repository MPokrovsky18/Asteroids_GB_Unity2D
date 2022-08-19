using UnityEngine;


namespace Asteroids
{

    internal sealed class Health
    {
        private float _hp;

        public Health(float hp)
        {
            _hp = hp;
        }

        public bool CheckIsDied(float damage)
        {
            _hp -= damage;

            return _hp <= 0;
        }
    }
}
