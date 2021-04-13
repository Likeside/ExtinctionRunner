using System.Collections.Generic;
using System.Linq;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class AsteroidsController: IExecutable, IStartable, IFixedExecutable
    {
       
        private AsteroidsSpawner _asteroidsSpawner;
        private Transform _spawnerGO;
        private List<AsteroidModelSO> _listOfAsteroidTypes;
        private List<GameObject> _listOfAsteroids;
        private List<Rigidbody2D> _listOfAsteroidsRB;
        private Transform _meteoritesTarget;
        private float _spawnRadius;


        public AsteroidsController(Transform meteoritesTarget, float spawnRadius)
        {

            _listOfAsteroidTypes = Resources.LoadAll<AsteroidModelSO>("").ToList();
            _meteoritesTarget = meteoritesTarget;
            _spawnRadius = spawnRadius;
            _asteroidsSpawner = new AsteroidsSpawner();
            _spawnerGO = GameObject.FindObjectOfType<SpawnerGO>().GetComponent<Transform>();
            _listOfAsteroids = new List<GameObject>();
            _listOfAsteroidsRB = new List<Rigidbody2D>();
         

        }
        
        
        public void Execute()
        {

            foreach (var asteroidModelSo in _listOfAsteroidTypes)
            {
                asteroidModelSo._spawnRate -= 1 * Time.deltaTime;
                if (asteroidModelSo._spawnRate < 0)
                {
                    asteroidModelSo._spawnRate = asteroidModelSo._defaultSpawnRate;
                    var asteroid = _asteroidsSpawner.SpawnSingleAsteroid(asteroidModelSo, _spawnerGO, _spawnRadius);
                    _listOfAsteroids.Add(asteroid);
                    _listOfAsteroidsRB.Add(asteroid.GetComponent<Rigidbody2D>());
                }
            }
        }

        public void IFixedExecute()
        {
            //двигает астероиды
            foreach (var asteroidRB in _listOfAsteroidsRB)
            {
                Vector2 direction = (Vector2)_meteoritesTarget.transform.position - (Vector2)asteroidRB.position;
                asteroidRB.MovePosition(asteroidRB.position + direction.normalized*Time.deltaTime); // добавить скорость (получить СО астероида с конкретным РБ, возможно стоит использовать словарь)
            }
        }
        public void OnStart()
        {
            /*
            //спавнит сразу несколько астероидов, добавляет их в список как и при спавне одного
           var asteroids = _asteroidsSpawner.SpawnAllAsteroids(_spawnersGoTransforms);
           foreach (var asteroid in asteroids)
           {
               _listOfAsteroids.Add(asteroid);
           }
           */

        }

       
    }
}