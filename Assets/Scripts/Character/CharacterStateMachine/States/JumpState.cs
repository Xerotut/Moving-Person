using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class JumpState : BaseCharacterState
    {
        public JumpState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, Action<bool> HandleAimEvent,
            float moveSpeed, float rotationSpeed, float jumpForce, Action<float>HandleJumpEvent) :
            base(HandleMoveEvent, HandleRotationEvent, HandleAimEvent, moveSpeed, rotationSpeed)
        {
            OnJump += HandleJumpEvent;
            _jumpForce = jumpForce;
        }


        private readonly Action<float> OnJump;

        private readonly float _jumpForce;
        public override void Enter()
        {
            base.Enter();
            OnJump?.Invoke(_jumpForce);
        }

      
    }
}
