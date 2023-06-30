using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class JumpButtonPressed : Transition
    {

        private bool _jumpRequested;

        private void SetJump()
        {
            _jumpRequested = true;
        }

        protected override bool CheckConditionUpdate() => _jumpRequested;

        public override void Enter()
        {
            base.Enter();
            InputReader.OnJump += SetJump;
        }

        public override void Exit()
        {
            InputReader.OnJump -= SetJump;
            _jumpRequested = false;
            base.Exit();
        }
    }
}
