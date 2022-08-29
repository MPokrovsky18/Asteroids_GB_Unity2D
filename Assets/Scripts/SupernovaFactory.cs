using UnityEngine;


namespace Asteroids
{

    internal sealed class SupernovaFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Supernova>("Enemy/Supernova"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
