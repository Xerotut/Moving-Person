using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class JumpState : BaseCharacterState
    {
        public JumpState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, 
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed, float jumpForce, float gravity ) : 
            base(HandleMoveEvent, HandleRotationEvent, HandleJumpEvent, moveSpeed, rotationSpeed)
        {
            _startingJumpForce = jumpForce;
            _gravity = gravity;
        }

        private float _startingJumpForce;
        private float _gravity;

        private float _leftJumpForce;

        private Vector2 _moveInput;

        public override void Enter()
        {
            base.Enter();
            _leftJumpForce = _startingJumpForce;
            SetDir(Vector2.zero);
            Debug.Log("Entered jump State");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            _moveDirection = new Vector3(_moveInput.x, _leftJumpForce, _moveInput.y);
            Move?.Invoke(_moveDirection, _moveSpeed);
            Rotate?.Invoke(_rotationDirection, _rotationSpeed);
            _leftJumpForce += _gravity * Time.deltaTime;
            Debug.Log(_leftJumpForce);
            if (_leftJumpForce<0) _leftJumpForce = 0;
        }

        public override void Exit()
        {
            Debug.Log("Exited jump state");
            _leftJumpForce = 0f;
            base.Exit();
        }

        protected override void SetDir(Vector2 dirInput)
        {

            _moveInput = new Vector3(dirInput.x, 0, dirInput.y);
        }


        protected override void SetRotation(Vector2 dirInput)
        {
            _rotationDirection = new Vector3(dirInput.x, 0, dirInput.y);
        }
    }
}
