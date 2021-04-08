using System.Collections.Generic;
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
        

        public AsteroidsController(int asteroidsMaxAmount, float asteroidSpawnRate)
        {
            _asteroidsMaxAmount = asteroidsMaxAmount;
            _asteroidSpawnRate = asteroidSpawnRate;
            _asteroidsSpawner = new AsteroidsSpawner(_asteroidsMaxAmount);
            SpawnerGO[] tempList = GameObject.FindObjectsOfType<SpawnerGO>();
            _spawnersGoTransforms = new Transform[tempList.Length];

            for (int i = 0; i < tempList.Length; i++)
            {
                _spawnersGoTransforms[i] = tempList[i].transform;
            }

            _timer = _asteroidSpawnRate;

        }
        
        
        public void Execute()
        {
            _timer -= 1*Time.deltaTime;
            Debug.Log(_timer);
            if (_timer < 0)
            {
                _timer = _asteroidSpawnRate;
                Debug.Log("TimerZero");
                _asteroidsSpawner.SpawnSingleAsteroid(_spawnersGoTransforms[Random.Range(0, _spawnersGoTransforms.Length)]);
            }
        }

        public void OnStart()
        {
            _asteroidsSpawner.SpawnAllAsteroids(_spawnersGoTransforms);
            Debug.Log("OnstartCalled");
        }
    }
}