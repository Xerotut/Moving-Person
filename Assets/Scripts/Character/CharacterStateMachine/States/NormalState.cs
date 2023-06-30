using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class NormalState : BaseCharacterState
    {

        public NormalState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent,
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed) :
            base(HandleMoveEvent, HandleRotationEvent, HandleJumpEvent, moveSpeed, rotationSpeed) { }


        public override void Exit()
        {
            base.Exit();
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
