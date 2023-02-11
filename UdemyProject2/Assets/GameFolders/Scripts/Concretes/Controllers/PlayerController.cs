using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Inputs;
using UdemyProject2.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _newSpeed = 10f;
        [SerializeField] float _jumpForce = 100f;

        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jump;
        IInputReader _input;
        float _horizontal;
        bool _isJump;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        void Update()
        {
            _horizontal = _input.Horizontal;
            if(_input.isJump)
            {
                _isJump = true;
            }
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal,_newSpeed);

            if(_isJump)
            {
                _jump.TickFixed(_jumpForce);             
            }
            _isJump = false;
        }
    }

}