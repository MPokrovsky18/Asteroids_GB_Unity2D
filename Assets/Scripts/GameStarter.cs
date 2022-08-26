using UnityEngine;


namespace Asteroids
{

    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            IEnemyFactory enemyFactory = new AsteroidFactory();
            enemyFactory.Create(new Health(100.0f, 100.0f));
            Enemy.Factory = enemyFactory;
            Enemy.Factory.Create(new Health(100.0f, 100.0f));
        }
    }
}
