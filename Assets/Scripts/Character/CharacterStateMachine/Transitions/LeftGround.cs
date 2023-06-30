using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class LeftGround : Transition
    {

        private bool _isGrounded;

        public override void Enter()
        {
            base.Enter();
            InputReader.OnJump += SetJump;
        }

        public override void Exit()
        {
            InputReader.OnJump -= SetJump;
            base.Exit();
        }
        public void SetJump()
        {
        }

        //protected override bool CheckConditionUpdate()
        //{
        //}

    }
}
