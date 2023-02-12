using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        VerticalMover _verticalMover;
        float _currenLifeTime=0f;

        [SerializeField] float _moveSpeed=10f;
        [SerializeField] float _maxLifeTime=10f;


        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _verticalMover = new VerticalMover(this);
        }

        private void Update()
        {
            _currenLifeTime += Time.deltaTime;
            if(_currenLifeTime>_maxLifeTime)
            {
                _currenLifeTime = 0f;
                KillYourSelf();
            }
        }


        private void FixedUpdate()
        {
            _verticalMover.FixedTick();
        }


        void KillYourSelf()
        {
            EnemyManager.Instance.SetPool(this);
        }
    }

}

