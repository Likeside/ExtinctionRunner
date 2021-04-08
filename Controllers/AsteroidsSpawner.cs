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

       public void SpawnSingleAsteroid(Transform spawnerGO)
        {
            GameObject.Instantiate(_listOfAsteroidTypes[Random.Range(0, _listOfAsteroidTypes.Count)]._asteroid, spawnerGO);
        }

       public void SpawnAllAsteroids(Transform[] spawnersGo)
        {
            for (int i = 0; i < _totalAsteroids; i++)
            {
                SpawnSingleAsteroid(spawnersGo[Random.Range(0, spawnersGo.Length)]); //использовать другой рандом
            }
        }
    }
}