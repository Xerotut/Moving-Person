using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public interface IMoveHandler 
    {
        public event Action<Vector3, float> OnMoveEvent;
        public event Action<Vector3, float> OnRotationEvent;
        public event Action<float> OnJumpEvent;

        public void RaiseMoveEvent(Vector3 direction, float maxSpeed);
        public void RaiseRotationEvent(Vector3 direction, float turnSpeed);
        public void RaiseJumpEvent(float jumpForce);
    }
}
