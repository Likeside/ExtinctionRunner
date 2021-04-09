using System.Collections.Generic;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class AsteroidsController: IExecutable, IStartable
    {
        private int _asteroidsMaxAmount;
        private float _asteroidSpawnRate;
        private float _timer;
        private AsteroidsSpawner _asteroidsSpawner;
        private Transform[] _spawnersGoTransforms;
        private List<(AsteroidModelSO, GameObject)> _listOfAsteroids; //хранит в себе конкретный астероид и модель, которая его создала
        

        public AsteroidsController(int asteroidsMaxAmount, float asteroidSpawnRate)
        {
            _asteroidsMaxAmount = asteroidsMaxAmount;
            _asteroidSpawnRate = asteroidSpawnRate;
            _asteroidsSpawner = new AsteroidsSpawner(_asteroidsMaxAmount);
            SpawnerGO[] tempList = GameObject.FindObjectsOfType<SpawnerGO>();
            _spawnersGoTransforms = new Transform[tempList.Length];
            _listOfAsteroids = new List<(AsteroidModelSO, GameObject)>();
            
            for (int i = 0; i < tempList.Length; i++)
            {
                _spawnersGoTransforms[i] = tempList[i].transform;
            }

            _timer = _asteroidSpawnRate;

        }
        
        
        public void Execute()
        {
            _timer -= 1*Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _asteroidSpawnRate;
               var asteroid = _asteroidsSpawner.SpawnSingleAsteroid(_spawnersGoTransforms[Random.Range(0, _spawnersGoTransforms.Length)]);
               _listOfAsteroids.Add(asteroid);
            }

            foreach (var asteroid in _listOfAsteroids)
            {
                asteroid.Item2.transform.Translate((new Vector3(0, 5, 0) * (Time.deltaTime * asteroid.Item1._speed)), Space.World);
            }
        }

        public void OnStart()
        {
            _asteroidsSpawner.SpawnAllAsteroids(_spawnersGoTransforms);
        }
    }
}