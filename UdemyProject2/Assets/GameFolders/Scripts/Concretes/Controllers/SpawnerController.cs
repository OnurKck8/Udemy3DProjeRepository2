using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Enums;
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
        int _index = 0;
        float _maxAddEnemyTime;

        public bool CanIncrease =>_index < EnemyManager.Instance.Count;

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

            if(!CanIncrease)
            {
                return;
            }

            if(_maxAddEnemyTime<Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

      

        void Spawn()
        {
            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

        void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }

      
    }

}
