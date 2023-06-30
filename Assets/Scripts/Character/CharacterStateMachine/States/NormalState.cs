using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class NormalState : State
    {


        private readonly Action<Vector3, float, bool> Move;
        private readonly Action<Vector3, float> Rotate;
        private readonly float _moveSpeed;
        private readonly float _rotationSpeed;

        private Vector3 _direction;
        private bool _wantsToJump;

        public NormalState(Action<Vector3, float, bool> HandleMoveEvent, Action<Vector3, float> HandleRotationEvent, float moveSpeed, float rotationSpeed)
        {
            Move += HandleMoveEvent;
            Rotate += HandleRotationEvent;
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
        }

        public override void Enter()
        {
            base.Enter();
            InputReader.OnMove += SetDir;
            InputReader.OnJump += SetJump;
        }

        public override void UpdateState()
        {
            Move?.Invoke(_direction, _moveSpeed, _wantsToJump);
            Rotate?.Invoke(_direction, _rotationSpeed);
            _wantsToJump = false;
            base.UpdateState();
        }

        public override void Exit()
        {
            _direction = Vector3.zero;
            InputReader.OnJump -= SetJump;
            InputReader.OnMove -= SetDir;
            base.Exit();
        }

        

        private void SetDir(Vector2 dirInput)
        {
            _direction = new Vector3(dirInput.x, 0, dirInput.y);
        }
        private void SetJump()
        {
            _wantsToJump = true;
        }
    }
}
