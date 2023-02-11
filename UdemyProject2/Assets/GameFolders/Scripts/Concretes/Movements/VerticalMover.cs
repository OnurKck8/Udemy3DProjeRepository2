using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class VerticalMover
    {
        EnemyController _enemyController;
        float _moveSpeed=7f;

        public VerticalMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _moveSpeed = _enemyController.MoveSpeed;
        }

        public void FixedTick(float vertical=1)
        {
            _enemyController.transform.Translate(Vector3.back * Time.deltaTime * vertical * _moveSpeed);
        }
    }
}

   
