// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace MovingPerson
{
    public class @PlayerInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharControls"",
            ""id"": ""5c74a0e3-69f5-4d21-8f62-088c46cd6ffb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""51e95c6d-0962-40fc-a615-ad1c01b4496d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""97d4169c-f69e-4277-affe-819613d372e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e80abce4-54e6-4922-af5e-66e5c5e4cb1c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53117187-c1b4-46fc-aead-7488c5b86b8a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CharControls
            m_CharControls = asset.FindActionMap("CharControls", throwIfNotFound: true);
            m_CharControls_Move = m_CharControls.FindAction("Move", throwIfNotFound: true);
            m_CharControls_Jump = m_CharControls.FindAction("Jump", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // CharControls
        private readonly InputActionMap m_CharControls;
        private ICharControlsActions m_CharControlsActionsCallbackInterface;
        private readonly InputAction m_CharControls_Move;
        private readonly InputAction m_CharControls_Jump;
        public struct CharControlsActions
        {
            private @PlayerInput m_Wrapper;
            public CharControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_CharControls_Move;
            public InputAction @Jump => m_Wrapper.m_CharControls_Jump;
            public InputActionMap Get() { return m_Wrapper.m_CharControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharControlsActions set) { return set.Get(); }
            public void SetCallbacks(ICharControlsActions instance)
            {
                if (m_Wrapper.m_CharControlsActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_CharControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public CharControlsActions @CharControls => new CharControlsActions(this);
        public interface ICharControlsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
    }
}
