using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

namespace MovingPerson
{
    public abstract class BaseCharacterState : State
    {
        protected readonly Action<Vector3, float> Move;
        protected readonly Action<Vector3, float> Rotate;
        protected readonly Action<float> Jump;
        protected readonly float _moveSpeed;
        protected readonly float _rotationSpeed;

        protected Vector3 _moveDirection;
        protected Vector3 _rotationDirection;


        public BaseCharacterState(Action<Vector3, float> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, 
            Action<float> HandleJumpEvent, float moveSpeed, float rotationSpeed)
        {
            Move += HandleMoveEvent;
            Rotate += HandleRotationEvent;
            Jump += HandleJumpEvent;
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            InputReader.OnMove += SetDir;
            InputReader.OnMove += SetRotation;
        }

      
     

        protected abstract void SetDir(Vector2 dirInput);
        protected abstract void SetRotation(Vector2 dirInput);

    }
}
