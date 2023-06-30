using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MovingPerson
{
    public abstract class Transition
    {
        public Action Callback;


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
