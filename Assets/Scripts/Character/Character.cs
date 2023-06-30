using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class Character : MonoBehaviour, IMoveHandler, IGroundedHandler, IWeaponHandler
    {

        [field: SerializeField] public CharacterStats Stats { get; private set; }
        
        public event Action<Vector3, float> OnMoveEvent;
        public event Action<Vector3, float> OnRotationEvent;
        public event Action<float> OnJumpEvent;

        public event Action<bool> OnGroundedCheck;
        public event Action<bool> OnAim;

        

        public void RaiseMoveEvent(Vector3 direction, float maxSpeed)
        {
            OnMoveEvent?.Invoke(direction, maxSpeed);
        }

        public void RaiseRotationEvent(Vector3 direction, float turnSpeed)
        {
            OnRotationEvent?.Invoke(direction, turnSpeed);
        }
        public void RaiseJumpEvent(float jumpForce)
        {
            OnJumpEvent?.Invoke(jumpForce);
        }

        public void RaiseOnGroundedCheck(bool isGrounded)
        {
            OnGroundedCheck?.Invoke(isGrounded);
        }

        public void RaiseAimEvent(bool isAiming)
        {
            OnAim?.Invoke(isAiming);
        }
    }
}
