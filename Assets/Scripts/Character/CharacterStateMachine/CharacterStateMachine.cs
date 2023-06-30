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




            State _normalState = new NormalState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseJumpEvent, 
                character.Stats.MaxSpeed, character.Stats.RotationSpeed, character.Stats.JumpForce);

            State _airborneState = new AirborneState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseJumpEvent,
                character.Stats.MaxSpeed * character.Stats.AirMaxSpeedMultiplier, character.Stats.RotationSpeed, character.Stats.JumpForce, character.Stats.Gravity);
            State _aimingState = new AimingState();

            Init(_normalState, new Dictionary<State, Dictionary<Transition, State>>()
            {

            });
        }

    }
}
