using UnityEngine;

namespace ExtinctionRunner.Models
{
    [CreateAssetMenu(fileName = "AsteroidModelSO", menuName = "Configs/AsteroidModelSO", order = 2)]
    public class AsteroidModelSO : ScriptableObject
    {
        public float _speed;
        public int _damage;
        public float _spawnRate;
        public float _defaultSpawnRate;
        public GameObject _asteroid;
        public GameObject _bonus;
        public float _bonusHeightFromPlanet;
        public GameObject _particleSystem;
    }

}
