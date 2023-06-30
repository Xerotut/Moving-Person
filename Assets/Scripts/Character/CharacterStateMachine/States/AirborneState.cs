using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

namespace MovingPerson
{
    public class AirborneState : BaseCharacterState
    {

        private float _gravity;
        private Vector3 _direction;
        private Vector3 _rotationDirection;

        public AirborneState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, 
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed, float jumpForce, float gravity) : 
            base(HandleMoveEvent, HandleRotationEvent, HandleJumpEvent, moveSpeed, rotationSpeed, jumpForce)
        {
            _gravity = gravity;
        }

        public override void UpdateState()
        {
            Move?.Invoke(_direction, _moveSpeed);
            Rotate?.Invoke(_rotationDirection, _rotationSpeed);
            base.UpdateState();
        }

        protected override void SetDir(Vector2 dirInput)
        {
            _direction = new Vector3(dirInput.x, _gravity, dirInput.y);
        }

        protected override void SetRotation(Vector2 dirInput)
        {
            _rotationDirection = new Vector3(dirInput.x, 0, dirInput.y);
        }

        protected override void SetJump()
        {
        }

    }
}
