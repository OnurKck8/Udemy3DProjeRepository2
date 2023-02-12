using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {

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
            EnemyController newenemy = EnemyManager.Instance.GetPool();
            newenemy.transform.parent = this.transform;
            newenemy.transform.position = this.transform.position;
            newenemy.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }
    }

}
