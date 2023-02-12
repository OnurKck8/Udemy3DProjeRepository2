using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        
        [SerializeField] float _maxLifeTime=10f;

        VerticalMover _verticalMover;
        float _currenLifeTime = 0f;

        public Transform MyProperty => throw new System.NotImplementedException();

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

