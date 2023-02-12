using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Inputs;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4.5f;
        [SerializeField] float _newSpeed = 10f;
        [SerializeField] float _jumpForce = 100f;

        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jump;
        IInputReader _input;
        float _horizontal;
        bool _isJump;
        bool _isDead=false;

        public float MoveSpeed => _newSpeed;
        public float MoveBoundary => _moveBoundary;


        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        void Update()
        {
            if(_isDead)
            {
                return;
            }

            _horizontal = _input.Horizontal;
            if(_input.isJump)
            {
                _isJump = true;
            }
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal);

            if(_isJump)
            {
                _jump.TickFixed(_jumpForce);             
            }
            _isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }

}