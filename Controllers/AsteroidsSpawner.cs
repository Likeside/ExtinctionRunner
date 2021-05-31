using System.Collections.Generic;
using ExtinctionRunner.Models;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class AsteroidsSpawner
    {
        
       public GameObject SpawnSingleAsteroid(AsteroidModelSO asteroidModelSo, Transform spawnerGO, float spawnRadius, Transform meteoritesTarget)
       {
           Vector3 randomPositionOnCircle = Random.insideUnitCircle.normalized * spawnRadius;
           Vector3 targetPos = meteoritesTarget.position;
           Vector3 spawningPos = spawnerGO.transform.position + randomPositionOnCircle;
           Vector3 direction = targetPos - spawningPos;
           direction.Normalize();
           float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           Quaternion rotation = Quaternion.Euler(0, 0, angle);
           var asteroid = GameObject.Instantiate(asteroidModelSo._asteroid, spawningPos, rotation);
           asteroid.transform.SetParent(spawnerGO);
           return asteroid;
       }

       public List<GameObject> SpawnSeveralAsteroids(AsteroidModelSO asteroidModelSo, Transform spawnersGo, float spawnRadius, Transform meteoritesTarget, int amountOfAsteroids)
       {
           List<GameObject> asteroidsList = new List<GameObject>();
            for (int i = 0; i < amountOfAsteroids; i++)
            {
                var asteroid = SpawnSingleAsteroid(asteroidModelSo, spawnersGo, spawnRadius, meteoritesTarget); 
               asteroidsList.Add(asteroid);
            }

            return asteroidsList;
       }
    }
}