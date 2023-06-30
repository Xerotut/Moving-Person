using System;
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

            Rigidbody charRB = GetComponent<Rigidbody>();


            Transition jumpToAirborne = new VerticalVelocityIsZero(charRB);
            Transition normalToAirborne = new LeftGround(character);
            Transition airborneToNormal = new LandedOnGround(character);
            Transition normalToJump = new JumpButtonPressed();
            Transition normalToAim = new StartedAiming(character);
            Transition aimToNormal = new StopedAiming(character);
            Transition aimToAirborne = new LeftGround(character);
            Transition aimToJump = new JumpButtonPressed();



            BaseCharacterState normalState = new NormalState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseAimEvent,
                character.Stats.MaxSpeed, character.Stats.RotationSpeed);
            BaseCharacterState airborneState = new AirborneState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseAimEvent,
                character.Stats.MaxSpeed * character.Stats.AirMaxSpeedMultiplier, character.Stats.RotationSpeed);
            BaseCharacterState jumpState = new JumpState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseAimEvent,
                character.Stats.MaxSpeed * character.Stats.AirMaxSpeedMultiplier, character.Stats.RotationSpeed, character.Stats.JumpForce, character.RaiseJumpEvent);
            BaseCharacterState aimState = new AimingState(character.RaiseMoveEvent, character.RaiseRotationEvent, character.RaiseAimEvent,
                character.Stats.MaxSpeed * character.Stats.AimingMaxSpeedMultiplier, character.Stats.RotationSpeed);

            Init(normalState, new Dictionary<BaseCharacterState, Dictionary<Transition, BaseCharacterState>>()
            {
                { normalState, new Dictionary<Transition, BaseCharacterState> { { normalToJump, jumpState }, { normalToAirborne , airborneState }, {normalToAim, aimState } } },
                { airborneState, new Dictionary<Transition, BaseCharacterState> { { airborneToNormal , normalState } } },
                { jumpState,  new Dictionary<Transition, BaseCharacterState> { { jumpToAirborne  , airborneState } } },
                { aimState, new Dictionary<Transition, BaseCharacterState> {  {aimToAirborne, airborneState }, {aimToNormal, normalState }, { aimToJump, jumpState}  } }
            });
        }

    }
}
