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

            CharacterController characterController = GetComponent<CharacterController>();


            Transition normalToAirborne = new LeftGround(character);
            Transition airborneToNormal = new LandedOnGround(character);
            Transition normalToJump = new JumpButtonPressed();
            Transition jumpToAirborne = new VerticalVelocityIsZero(characterController);


            State normalState = new NormalState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseJumpEvent, 
                character.Stats.MaxSpeed, character.Stats.RotationSpeed);

            State airborneState = new AirborneState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseJumpEvent,
                character.Stats.MaxSpeed * character.Stats.AirMaxSpeedMultiplier, character.Stats.RotationSpeed);
            State jumpState = new JumpState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseJumpEvent,
                character.Stats.MaxSpeed * character.Stats.AirMaxSpeedMultiplier, character.Stats.RotationSpeed, character.Stats.JumpForce, character.Stats.Gravity);

            Init(normalState, new Dictionary<State, Dictionary<Transition, State>>()
            {
                { jumpState,  new Dictionary<Transition, State> { { jumpToAirborne  , airborneState } } },
                { normalState, new Dictionary<Transition, State> { { normalToAirborne , airborneState }, { normalToJump, jumpState } } },
                { airborneState, new Dictionary<Transition, State> { { airborneToNormal , normalState } } },
            });
        }

    }
}
