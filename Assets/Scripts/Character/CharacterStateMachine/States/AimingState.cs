using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class AimingState : BaseCharacterState
    {
        public AimingState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, Action<bool> HandleAimEvent,
            float moveSpeed, float rotationSpeed) : base(HandleMoveEvent, HandleRotationEvent, HandleAimEvent, moveSpeed, rotationSpeed) { }


    }
}
