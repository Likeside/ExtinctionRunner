using System.Collections.Generic;
using System.Linq;
using ExtinctionRunner;
using UnityEngine;

namespace Controllers
{
    public class AsteroidsSpawner
    {
        
       public GameObject SpawnSingleAsteroid(AsteroidModelSO asteroidModelSo, Transform spawnerGO, float spawnRadius)
       {
           Vector3 randomPositionOnCircle = Random.insideUnitCircle.normalized * spawnRadius;
           var asteroid = GameObject.Instantiate(asteroidModelSo._asteroid, spawnerGO.transform.position + randomPositionOnCircle, Quaternion.identity);
           asteroid.transform.SetParent(spawnerGO);
           return asteroid;
       }

       public List<GameObject> SpawnSeveralAsteroids(AsteroidModelSO asteroidModelSo, Transform spawnersGo, float spawnRadius, int amountOfAsteroids)
       {
           List<GameObject> asteroidsList = new List<GameObject>();
            for (int i = 0; i < amountOfAsteroids; i++)
            {
                var asteroid = SpawnSingleAsteroid(asteroidModelSo, spawnersGo, spawnRadius); 
               asteroidsList.Add(asteroid);//использовать другой рандом
            }

            return asteroidsList;
       }
    }
}