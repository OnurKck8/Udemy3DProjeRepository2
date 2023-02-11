using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] EnemyController _enemyPrefab;
        [Range(0.1f,5f)] [SerializeField] float _min=0.1f;
        [Range(5f,15f)] [SerializeField] float _max=15f;

        float _maxSpawnTime = 10f;
        float _currentSpawnTime = 0f;

        void OnEnable()
        {
            GetRandomMaxTime();
        }

        void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if(_currentSpawnTime>_maxSpawnTime)
            {
                Spawn();
            }
        }

        void Spawn()
        {
            EnemyController newenemy= Instantiate(_enemyPrefab, transform.position, transform.rotation);
            newenemy.transform.parent = this.transform;

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }
    }

}
