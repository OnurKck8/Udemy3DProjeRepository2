using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.ScripTableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New", order = 1)]

    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefab;
        [SerializeField] GameObject _spawnersPrefab;
        [SerializeField] Material _skyboxMaterial;
        [SerializeField] float _moveSpeed=10f;
        [SerializeField] float _addDelayTime=50f;

        public FloorController FloorPrefab => _floorPrefab;
        public GameObject SpawnerPrefab => _spawnersPrefab;
        public Material SkyboxMaterial => _skyboxMaterial;
        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;
    }
}

