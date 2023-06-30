using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class VerticalVelocityIsZero : Transition
    {
        public VerticalVelocityIsZero(CharacterController charController)
        {
            _charController = charController;
        }

        private CharacterController _charController;

        protected override bool CheckConditionUpdate() => _charController.velocity.y <= 0;

    }
}
