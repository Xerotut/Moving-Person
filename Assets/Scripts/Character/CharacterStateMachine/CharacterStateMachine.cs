using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public class CharacterStateMachine : StateMachine
    {
      


        private void Awake()
        {

            Character character = GetComponent<Character>();




            State _normalState = new NormalState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.Stats.MaxSpeed, character.Stats.RotationSpeed);
            State _aimingState = new AimingState();
            State _airborneState = new AirborneState();

            Init(_normalState, new Dictionary<State, Dictionary<Transition, State>>()
            {

            });
        }

    }
}
