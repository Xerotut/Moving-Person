using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class StateMachine : MonoBehaviour
    {
        private State _currentState;


        protected void Init(State initialState, Dictionary<State, Dictionary<Transition, State>> states)
        {
            foreach (var state in states)
            {
                foreach (var transition in state.Value)
                {
                    transition.Key.Callback += () => ChangeState(transition.Value);
                    state.Key.AddTransition(transition.Key);
                }
            }

            ChangeState(initialState);
        }

        private void Update() => _currentState?.UpdateState();
        private void FixedUpdate() => _currentState?.UpdateStatePhysics();

        private void ChangeState(State newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

    }
}
