using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public interface IGroundedHandler 
    {
        public event Action<bool> OnGroundedCheck;

        public void RaiseOnGroundedCheck(bool isGrounded);
    }
}
