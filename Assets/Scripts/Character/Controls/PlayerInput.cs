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
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""42d3d8de-6e1d-42c0-9724-b542bafddd55"",
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
                    ""name"": ""Move"",
                    ""id"": ""4e72c980-769e-4a4b-a97c-5f5b7570f627"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4578b2f1-57ed-44be-984e-50a733778151"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""01463384-5cf3-4716-a8be-21f395631d84"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dc97b92e-eebe-4c33-aff6-b840f8a286fb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ad68e45-204f-49ff-a3f8-ffd60ea87b51"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                },
                {
                    ""name"": """",
                    ""id"": ""0eb7f565-b91a-4157-a67d-54fd8803eec4"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
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
            m_CharControls_Aim = m_CharControls.FindAction("Aim", throwIfNotFound: true);
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
        private readonly InputAction m_CharControls_Aim;
        public struct CharControlsActions
        {
            private @PlayerInput m_Wrapper;
            public CharControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_CharControls_Move;
            public InputAction @Jump => m_Wrapper.m_CharControls_Jump;
            public InputAction @Aim => m_Wrapper.m_CharControls_Aim;
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
                    @Aim.started -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_CharControlsActionsCallbackInterface.OnAim;
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
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                }
            }
        }
        public CharControlsActions @CharControls => new CharControlsActions(this);
        public interface ICharControlsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
        }
    }
}
