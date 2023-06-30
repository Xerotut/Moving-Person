using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class StateMachine : MonoBehaviour
    {
        private BaseCharacterState _currentState;


        protected void Init(BaseCharacterState initialState, Dictionary<BaseCharacterState, Dictionary<Transition, BaseCharacterState>> states)
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

        private void ChangeState(BaseCharacterState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

    }
}
