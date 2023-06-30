using System;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class IsGrounded : Transition
    {
        public IsGrounded(IGroundedHandler isGroundedHandler) 
        {
            isGroundedHandler.OnGroundedCheck += isGrouned => OnGroundedChange?.Invoke(isGrouned);
        }

        private Action<bool> OnGroundedChange;
        protected bool _isGrounded = true;

        public override void Enter()
        {
            base.Enter();
            OnGroundedChange += SetGrounded;
        }

        public override void Exit()
        {
            OnGroundedChange -= SetGrounded;
            base.Exit();
        }
        public void SetGrounded(bool isGrounded)
        {
            _isGrounded=isGrounded;
        }
    }

    public class LeftGround : IsGrounded
    {
        public LeftGround(IGroundedHandler isGroundedHandler) : base(isGroundedHandler) { }
        protected override bool CheckConditionUpdate() => !_isGrounded;

        public override void Exit()
        {
            base.Exit();
        }

        public override void UpdateTransitionPhysics()
        {
            base.UpdateTransitionPhysics();
        }
    }
    public class LandedOnGround : IsGrounded
    {
        public LandedOnGround(IGroundedHandler isGroundedHandler) : base(isGroundedHandler) { }
        protected override bool CheckConditionUpdate() => _isGrounded;
    }
}
