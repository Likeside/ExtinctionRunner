using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtinctionRunner
{
    public enum AsteroidType
    {
        Healing,
        Speed,
        VolcanoBonus
    }
    [CreateAssetMenu(fileName = "AsteroidModelSO", menuName = "Configs/AsteroidModelSO", order = 2)]
    public class AsteroidModelSO : ScriptableObject
    {
        public AsteroidType _type;
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
