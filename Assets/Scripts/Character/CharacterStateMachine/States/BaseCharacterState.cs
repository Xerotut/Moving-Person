using System;
using UnityEngine;

namespace MovingPerson
{
    public abstract class BaseCharacterState : State
    {
        protected readonly Action<Vector3, float> Move;
        protected readonly Action<Vector3, float> Rotate;
        protected readonly Action<bool> Aim;
        protected readonly float _moveSpeed;
        protected readonly float _rotationSpeed;

        protected Vector3 _moveDirection;
        protected Vector3 _rotationDirection;


        public BaseCharacterState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, Action<bool> HandleAimEvent, 
            float moveSpeed, float rotationSpeed)
        {
            Move += HandleMoveEvent;
            Rotate += HandleRotationEvent;
            Aim += HandleAimEvent;
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            InputReader.OnMove += SetDir;
            InputReader.OnMove += SetRotation;
            InputReader.OnAim += SetAim;
        }

      

        public override void UpdateStatePhysics()
        {
            Move?.Invoke(_moveDirection, _moveSpeed);
            Rotate?.Invoke(_rotationDirection, _rotationSpeed);
            base.UpdateStatePhysics();
        }

        protected virtual void SetAim(bool isAiming)
        {
            Aim?.Invoke(isAiming);
        }

        protected virtual void SetDir(Vector2 dirInput)
        {
            _moveDirection = new Vector3(dirInput.x, 0, dirInput.y);

        }
        protected virtual void SetRotation(Vector2 dirInput)
        {
            _rotationDirection = new Vector3(dirInput.x, 0, dirInput.y);
        }

    }
}
