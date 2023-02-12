using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class EnemyManager : SingletonBehaviorObject<EnemyManager>
    {
        [SerializeField] EnemyController _enemyPrefab;
        Queue<EnemyController> _enemies = new Queue<EnemyController>();

        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitialiazePool();
        }

        void InitialiazePool()
        {
            for(int i=0; i<10; i++)
            {
                EnemyController newEnemey = Instantiate(_enemyPrefab);
                newEnemey.gameObject.SetActive(false);
                newEnemey.transform.parent = this.transform;
                _enemies.Enqueue(newEnemey);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            _enemies.Enqueue(enemyController);
        }

        public EnemyController GetPool()
        {
            if(_enemies.Count == 0)
            {
                InitialiazePool();
            }

            return _enemies.Dequeue();
        }

    }

    
}
