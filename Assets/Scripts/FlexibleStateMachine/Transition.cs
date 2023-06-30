using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MovingPerson
{
    public abstract class Transition
    {
        //This us used to change current state when the transition requirements are met.
        public Action Callback;

        //These are two methods that check whether or not the transition requirements are met. 
        protected virtual bool CheckConditionUpdate() => true;
        protected virtual bool CheckConditionFixedUpdate() => true;
        private bool _physicsCheck;

        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void UpdateTransition()
        {
            if (!(CheckConditionUpdate() && _physicsCheck)) return;

            if (Callback != null)
            {
                Callback.Invoke();
            }
            else
            {
                Enter();
            }
        }
        public virtual void UpdateTransitionPhysics()
        {
            _physicsCheck = CheckConditionFixedUpdate();
        }


    }
}
