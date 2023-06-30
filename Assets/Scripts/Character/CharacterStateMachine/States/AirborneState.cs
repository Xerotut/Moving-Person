using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class AirborneState : BaseCharacterState
    {


        public AirborneState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent,
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed) :
            base(HandleMoveEvent, HandleRotationEvent, HandleJumpEvent, moveSpeed, rotationSpeed) { }



        public override void UpdateState()
        {
            Move?.Invoke(_moveDirection, _moveSpeed);
            Rotate?.Invoke(_rotationDirection, _rotationSpeed);
            base.UpdateState();
        }


        protected override void SetDir(Vector2 dirInput)
        {
            _moveDirection = new Vector3(dirInput.x, 0, dirInput.y);
        }

        protected override void SetRotation(Vector2 dirInput)
        {
            _rotationDirection = new Vector3(dirInput.x, 0, dirInput.y);
        }

    }
}
