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
        private AsteroidsCollisionController _asteroidsCollisionController;
        private Transform _spawnerGO;
        private List<AsteroidModelSO> _listOfAsteroidTypes;
        private List<GameObject> _listOfAsteroids;
        private Dictionary<Rigidbody2D, float> _listOfAsteroidsRbSpeed;
        private Transform _meteoritesTarget;
        private float _spawnRadius;


        public AsteroidsController(Transform meteoritesTarget, float spawnRadius)
        {

            _listOfAsteroidTypes = Resources.LoadAll<AsteroidModelSO>("").ToList();
            _meteoritesTarget = meteoritesTarget;
            _spawnRadius = spawnRadius;
            _asteroidsSpawner = new AsteroidsSpawner();
            _listOfAsteroidsRbSpeed = new Dictionary<Rigidbody2D, float>();
            _spawnerGO = GameObject.FindObjectOfType<SpawnerGO>().GetComponent<Transform>();
            _asteroidsCollisionController = new AsteroidsCollisionController(_listOfAsteroidsRbSpeed, _spawnerGO);
           
            _listOfAsteroids = new List<GameObject>();
            
         

        }
        
        
        public void Execute()
        {
            SpawnAsteroids();
        }

        public void IFixedExecute()
        {
            MoveAsteroids();
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

        private void SpawnAsteroids()
        {
            foreach (var asteroidModelSo in _listOfAsteroidTypes)
            {
                asteroidModelSo._spawnRate -= 1 * Time.deltaTime;
                if (asteroidModelSo._spawnRate < 0)
                {
                    asteroidModelSo._spawnRate = asteroidModelSo._defaultSpawnRate;
                    var asteroid = _asteroidsSpawner.SpawnSingleAsteroid(asteroidModelSo, _spawnerGO, _spawnRadius);
                    _listOfAsteroids.Add(asteroid);
                    _listOfAsteroidsRbSpeed.Add(asteroid.GetComponent<Rigidbody2D>(), asteroidModelSo._speed);
                    _asteroidsCollisionController.AddAsteroidToHandler(asteroid, asteroidModelSo);
                }
            }
        }
        
        private void MoveAsteroids()
        {
            foreach (var asteroidRbSpeed in _listOfAsteroidsRbSpeed)
            {
                Vector2 direction = (Vector2) _meteoritesTarget.transform.position - asteroidRbSpeed.Key.position;
                direction.Normalize();
                asteroidRbSpeed.Key.MovePosition(asteroidRbSpeed.Key.position + direction * (Time.fixedDeltaTime*asteroidRbSpeed.Value));
            }
        }
       
    }
}