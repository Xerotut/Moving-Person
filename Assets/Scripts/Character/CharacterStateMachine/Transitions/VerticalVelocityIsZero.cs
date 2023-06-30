using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class VerticalVelocityIsZero : Transition
    {
        public VerticalVelocityIsZero(Rigidbody charRB)
        {
            _charRB = charRB;
        }

        private Rigidbody _charRB;

        protected override bool CheckConditionUpdate() => _charRB.velocity.y < 0;

    }
}
