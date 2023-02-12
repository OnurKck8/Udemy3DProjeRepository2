using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class VerticalMover : IMover
    {
        IEntityController _entityController;
        float _moveSpeed;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
            _moveSpeed = _entityController.MoveSpeed;
        }

        public void FixedTick(float vertical=1)
        {
            _entityController.transform.Translate(Vector3.back * Time.deltaTime * vertical * _moveSpeed);
        }
    }
}

   
