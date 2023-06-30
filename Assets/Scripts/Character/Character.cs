using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class Character : MonoBehaviour, IMoveHandler
    {

        [field: SerializeField] public CharacterStats Stats { get; private set; }
        
        public event Action<Vector3, float, bool> OnMoveEvent;
        public event Action<Vector3, float> OnRotationEvent;

        public void RaiseMoveEvent(Vector3 direction, float maxSpeed, bool wantToJump)
        {
            OnMoveEvent?.Invoke(direction, maxSpeed, wantToJump);
        }

        public void RaiseRotationEvent(Vector3 direction, float turnSpeed)
        {
            OnRotationEvent?.Invoke(direction, turnSpeed);
        }
    }
}
