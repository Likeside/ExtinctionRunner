using System.Collections.Generic;
using System.Linq;
using ExtinctionRunner;
using UnityEngine;

namespace Controllers
{
    public class AsteroidsSpawner
    {
        private int _totalAsteroids;
        private List<AsteroidModelSO> _listOfAsteroidTypes;
        
        public AsteroidsSpawner(int totalAsteroids)
        {
            _totalAsteroids = totalAsteroids;
            _listOfAsteroidTypes = Resources.LoadAll<AsteroidModelSO>("").ToList();
        }

        void SpawnSingleAsteroid()
        {
            GameObject.Instantiate(_listOfAsteroidTypes[Random.Range(0, _listOfAsteroidTypes.Count-1)]._asteroid);
        }

        void SawnAllAsteroids()
        {
            for (int i = _totalAsteroids; i == 0; i--)
            {
                SpawnSingleAsteroid();
            }
        }
    }
}