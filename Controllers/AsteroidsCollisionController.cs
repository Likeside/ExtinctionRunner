using System.Collections.Generic;
using ExtinctionRunner;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class AsteroidsCollisionController
    {
        private Transform _bonusParent;
        private Dictionary<AsteroidView, AsteroidModelSO> _asteroidsDictionary;
        private Dictionary<Rigidbody2D, float> _listOfAsteroidsRbSpeed;
        private BonusCollisionController _bonusCollisionController;
        public AsteroidsCollisionController(Dictionary<Rigidbody2D, float> listOfAsteroidsRbSpeed, Transform bonusParent, BonusCollisionController bonusCollisionController)
        {
            _bonusParent = bonusParent;
            _asteroidsDictionary = new Dictionary<AsteroidView, AsteroidModelSO>();
            _listOfAsteroidsRbSpeed = listOfAsteroidsRbSpeed;
            _bonusCollisionController = bonusCollisionController;
        }
        void HandleCollision(AsteroidView asteroidView, GameObject other)
        {
            bool isPlayer = other.TryGetComponent(out PlayerView playerView);
            bool isPlanet = other.TryGetComponent(out PlanetView planetView);
            if (isPlayer)
            {
                playerView.HandleCollisionWithAsteroid(_asteroidsDictionary[asteroidView]._damage);
            }

            if (isPlanet)
            {
                if (_asteroidsDictionary[asteroidView]._bonus != null)
                {
                    var bonus = GameObject.Instantiate(_asteroidsDictionary[asteroidView]._bonus,
                        asteroidView.transform.position, Quaternion.identity);
                    _bonusCollisionController.AddBonusToHandler(bonus);
                    bonus.transform.SetParent(_bonusParent);
                }

                asteroidView.OnCollisionHappened -= HandleCollision;
                _listOfAsteroidsRbSpeed.Remove(asteroidView.GetComponent<Rigidbody2D>());
                asteroidView.DestroyThis();
            }
        }


        public void AddAsteroidToHandler(GameObject asteroid, AsteroidModelSO asteroidModelSo)
        {
            AsteroidView asteroidView = asteroid.GetComponent<AsteroidView>();
            _asteroidsDictionary.Add(asteroidView, asteroidModelSo);
            asteroidView.OnCollisionHappened += HandleCollision;
        }
    }
}