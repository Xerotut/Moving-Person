using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public abstract class BaseCharacterState : State
    {
        protected readonly Action<Vector3, float> Move;
        protected readonly Action<Vector3, float> Rotate;
        protected readonly Action<float> Jump;
        protected readonly float _moveSpeed;
        protected readonly float _rotationSpeed;
        protected readonly float _jumpForce;


        public BaseCharacterState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, 
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed, float jumpForce)
        {
            Move += HandleMoveEvent;
            Rotate += HandleRotationEvent;
            Jump += HandleJumpEvent;
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            _jumpForce = jumpForce;
        }

        public override void Enter()
        {
            base.Enter();
            InputReader.OnMove += SetDir;
            InputReader.OnMove += SetRotation;
            InputReader.OnJump += SetJump;
        }


        public override void Exit()
        {
            InputReader.OnJump -= SetJump;
            InputReader.OnMove -= SetRotation;
            InputReader.OnMove -= SetDir;
            base.Exit();
        }

        protected abstract void SetDir(Vector2 dirInput);
        protected abstract void SetRotation(Vector2 dirInput);
        protected abstract void SetJump();

    }
}
