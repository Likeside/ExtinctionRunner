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
        private int _asteroidsMaxAmount;
        private float _asteroidSpawnRate;
        private float _timer;
        private AsteroidsSpawner _asteroidsSpawner;
        private Transform[] _spawnersGoTransforms;
        private List<(AsteroidModelSO, GameObject)> _listOfAsteroids; //хранит в себе конкретный астероид и модель, которая его создала (Заменить на словарь с РБ?)
        private List<Rigidbody2D> _listOfAsteroidsRB;
        private Transform _meteoritesTarget;
        

        public AsteroidsController(int asteroidsMaxAmount, float asteroidSpawnRate, Transform meteoritesTarget)
        {
            _asteroidsMaxAmount = asteroidsMaxAmount;
            _asteroidSpawnRate = asteroidSpawnRate;
            _meteoritesTarget = meteoritesTarget;
            _asteroidsSpawner = new AsteroidsSpawner(_asteroidsMaxAmount);
            SpawnerGO[] tempList = GameObject.FindObjectsOfType<SpawnerGO>();
            _spawnersGoTransforms = new Transform[tempList.Length];
            _listOfAsteroids = new List<(AsteroidModelSO, GameObject)>();
            _listOfAsteroidsRB = new List<Rigidbody2D>();
            
            for (int i = 0; i < tempList.Length; i++)
            {
                _spawnersGoTransforms[i] = tempList[i].transform;
            }

            _timer = _asteroidSpawnRate;

        }
        
        
        public void Execute()
        {
            //раз в несколько секунд (указывается в геймконтроллере) спавнит астероид из рандомной модели
            _timer -= 1*Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _asteroidSpawnRate;
               var asteroid = _asteroidsSpawner.SpawnSingleAsteroid(_spawnersGoTransforms[Random.Range(0, _spawnersGoTransforms.Length)]);
               _listOfAsteroids.Add(asteroid);
               Rigidbody2D asteroidRB = asteroid.Item2.GetComponent<Rigidbody2D>();
               _listOfAsteroidsRB.Add(asteroidRB);
            }
            
        }

        public void IFixedExecute()
        {
            //двигает астероиды
            foreach (var asteroidRB in _listOfAsteroidsRB)
            {
                //  asteroid.Item2.transform.Translate((new Vector3(0, 5, 0) * (Time.deltaTime * asteroid.Item1._speed)), Space.World);
                Vector2 direction = (Vector2)_meteoritesTarget.transform.position - (Vector2)asteroidRB.position;
                asteroidRB.MovePosition(asteroidRB.position + direction.normalized*Time.deltaTime); // добавить скорость (получить СО астероида с конкретным РБ, возможно стоит использовать словарь)
            }
        }
        public void OnStart()
        {
            //спавнит сразу несколько астероидов, добавляет их в список как и при спавне одного
           var asteroids = _asteroidsSpawner.SpawnAllAsteroids(_spawnersGoTransforms);
           foreach (var asteroid in asteroids)
           {
               _listOfAsteroids.Add(asteroid);
           }

        }

       
    }
}