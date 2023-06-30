using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class StateMachine : MonoBehaviour
    {
        private BaseCharacterState _currentState;

        /// <summary>
        /// This setup allows to decouple states from transitions (and basically from the state machine itself). It is more convoluted then basic state machine,
        /// but allows quick changing and adding states and transitions.
        /// It may also be converted to hierarchical state machine relatively easy. 
        /// </summary>
        /// <param name="initialState">Initial state at which an object will start it's existence</param>
        /// <param name="states">Dictionary, which maps states to the transition-state pairs for that state. Each transition has to be unique instance, because
        /// otherwise it's callback will be overwritten</param>
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
