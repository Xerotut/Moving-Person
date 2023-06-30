using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public interface IMoveHandler 
    {
        public event Action<Vector3, float, bool> OnMoveEvent;
        public event Action<Vector3, float> OnRotationEvent;

        public void RaiseMoveEvent(Vector3 direction, float maxSpeed, bool wantToJump);
        public void RaiseRotationEvent(Vector3 direction, float turnSpeed);
    }
}
