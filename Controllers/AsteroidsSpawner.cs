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

       public (AsteroidModelSO, GameObject) SpawnSingleAsteroid(Transform spawnerGO)
       {
           AsteroidModelSO asteroidModelSo = _listOfAsteroidTypes[Random.Range(0, _listOfAsteroidTypes.Count)];
           
            var a = GameObject.Instantiate(asteroidModelSo._asteroid, spawnerGO);
            (AsteroidModelSO, GameObject) tuple = (asteroidModelSo, a);
            return tuple;
       }

       public List<(AsteroidModelSO, GameObject)> SpawnAllAsteroids(Transform[] spawnersGo)
       {
           List<(AsteroidModelSO, GameObject)> asteroidsList = new List<(AsteroidModelSO, GameObject)>();
            for (int i = 0; i < _totalAsteroids; i++)
            {
               var asteroidTuple = SpawnSingleAsteroid(spawnersGo[Random.Range(0, spawnersGo.Length)]); 
               asteroidsList.Add(asteroidTuple);//использовать другой рандом
            }

            return asteroidsList;
       }
    }
}