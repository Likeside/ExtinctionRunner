using System.Collections.Generic;
using ExtinctionRunner.Models;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class AsteroidsCollisionController
    {
        private Transform _bonusParent;
        private Transform _meteoritesTarget;
        private Dictionary<AsteroidView, AsteroidModelSO> _asteroidsDictionary;
        private Dictionary<Rigidbody2D, float> _listOfAsteroidsRbSpeed;
        private BonusesHandler _bonusesHandler;

        public AsteroidsCollisionController(Dictionary<Rigidbody2D, float> listOfAsteroidsRbSpeed, Transform bonusParent, BonusesHandler bonusHandler, Transform meteoritesTarget)
        {
            _bonusParent = bonusParent;
            _meteoritesTarget = meteoritesTarget;
            _asteroidsDictionary = new Dictionary<AsteroidView, AsteroidModelSO>();
            _listOfAsteroidsRbSpeed = listOfAsteroidsRbSpeed;
            _bonusesHandler = bonusHandler;
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
                Vector3 asteroidPos = asteroidView.transform.position;
                if (_asteroidsDictionary[asteroidView]._bonus != null)
                {
                    
                    Vector3 asteroidRot = asteroidView.transform.rotation.eulerAngles;
                    Vector3 bonusPosDirection = (asteroidPos - _meteoritesTarget.transform.position).normalized;
                    Vector3 bonusRotation = asteroidRot + new Vector3(0, 0, 90);
                    var bonus = GameObject.Instantiate(_asteroidsDictionary[asteroidView]._bonus,
                        asteroidPos + bonusPosDirection * _asteroidsDictionary[asteroidView]._bonusHeightFromPlanet, Quaternion.Euler(bonusRotation));
                    
                    _bonusesHandler.AddBonusToHandler(bonus.GetComponent<BonusView>());
                    bonus.transform.SetParent(_bonusParent);
                }
                var particle = GameObject.Instantiate(_asteroidsDictionary[asteroidView]._particleSystem, asteroidPos,
                    Quaternion.identity);
               particle.transform.SetParent(_bonusParent);

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