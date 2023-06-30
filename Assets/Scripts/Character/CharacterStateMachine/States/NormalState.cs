using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class NormalState : BaseCharacterState
    {


      

        private const float DOWNWARD_FORCE = -0.05f;

        private Vector3 _direction;
        private Vector3 _rotationDirection;

        public NormalState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent,
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed, float jumpForce) :
            base(HandleMoveEvent, HandleRotationEvent, HandleJumpEvent, moveSpeed, rotationSpeed, jumpForce) { }
        

     

        public override void UpdateState()
        {
            Move?.Invoke(_direction, _moveSpeed);
            Rotate?.Invoke(_rotationDirection, _rotationSpeed);
            base.UpdateState();
        }

        public override void Exit()
        {
            _direction = Vector3.zero;
            base.Exit();
        }


        protected override void SetDir(Vector2 dirInput)
        {
            _direction = new Vector3(dirInput.x, DOWNWARD_FORCE, dirInput.y);
            
            _rotationDirection.y = 0;
        }

        protected override void SetRotation(Vector2 dirInput)
        {
            _rotationDirection = new Vector3(dirInput.x, 0, dirInput.y);
        }

        protected override void SetJump()
        {
            Jump(_jumpForce);
        }

    }
}
