using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingPerson
{
    public static class InputReader
    {

        private readonly static PlayerInput _playerInput;

        public static event Action<Vector2> OnMove;
        public static event Action OnJump;
        public static event Action<bool> OnAim;


        static InputReader()
        {
            _playerInput = new PlayerInput();

            SubscribeToInputs();

            _playerInput.Enable();

        }

        //Modify this as necessary 
        private static void SubscribeToInputs()
        {
            _playerInput.CharControls.Move.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
            _playerInput.CharControls.Move.canceled += ctx => OnMove?.Invoke(Vector2.zero);

            _playerInput.CharControls.Jump.performed += ctx => OnJump?.Invoke();

            _playerInput.CharControls.Aim.performed += ctx => OnAim?.Invoke(true);
            _playerInput.CharControls.Aim.canceled += ctx => OnAim?.Invoke(false);

        }

    }
}
