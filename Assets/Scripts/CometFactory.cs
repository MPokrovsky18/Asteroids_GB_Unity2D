using UnityEngine;


namespace Asteroids
{

    internal sealed class CometFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Comet>("Enemy/Comet"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
