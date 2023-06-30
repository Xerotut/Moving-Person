using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public abstract class State
    {

        private List<Transition> _transitions = new List<Transition>();

        public void AddTransition(Transition transition)
        {
            _transitions.Add(transition);
        }

        public virtual void Enter()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].Enter();
            }
        }

        public virtual void Exit()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].Exit();
            }
        }

        public virtual void UpdateState()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].UpdateTransition();
            }
        }
        public virtual void UpdateStatePhysics()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].UpdateTransitionPhysics();
            }
        }



    }
}
