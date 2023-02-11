using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _newSpeed = 10f;
        [SerializeField] float _horizontalDirection = 0f;
        [SerializeField] float _jumpForce = 100f;
        [SerializeField] bool _isJump;

        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jump;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontalDirection,_newSpeed);

            if(_isJump)
            {
                _jump.TickFixed(_jumpForce);             
            }
            _isJump = false;
        }
    }

}