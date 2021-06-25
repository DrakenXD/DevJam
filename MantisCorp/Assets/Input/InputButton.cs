// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputButton.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputButton : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputButton()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputButton"",
    ""maps"": [
        {
            ""name"": ""Joystick"",
            ""id"": ""21ca41bb-53ce-4a41-b58e-77eabf0d9938"",
            ""actions"": [
                {
                    ""name"": ""StickUp"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d38ccb20-35b6-4aeb-a48f-e45f94b4dc75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StickDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""266b10c6-bff6-4db2-8290-a31f5b907098"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""e2695474-992e-44f8-b818-9b54266f8e64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a8255616-20d0-4028-9596-7f8a9d883e11"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af3f9f50-b3e7-4a8b-b1e0-5b32e96b549b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a63593a6-093c-4ad2-8fa6-80dab5ca6409"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd2d4048-34b7-4aa0-b0d0-7fa64eb8d844"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07e2b9b8-66af-47f0-b5e1-ab05827c2dd1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""329248c6-a599-40d9-b59f-58c2abfe06ae"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56bdc93b-944c-49a8-9452-fde1cfadf9d2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0a5d146-3883-40da-8e87-349d6d1174c7"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70d27488-8038-4cb9-91ee-efb728cfd903"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Joystick
        m_Joystick = asset.FindActionMap("Joystick", throwIfNotFound: true);
        m_Joystick_StickUp = m_Joystick.FindAction("StickUp", throwIfNotFound: true);
        m_Joystick_StickDown = m_Joystick.FindAction("StickDown", throwIfNotFound: true);
        m_Joystick_Enter = m_Joystick.FindAction("Enter", throwIfNotFound: true);
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

    // Joystick
    private readonly InputActionMap m_Joystick;
    private IJoystickActions m_JoystickActionsCallbackInterface;
    private readonly InputAction m_Joystick_StickUp;
    private readonly InputAction m_Joystick_StickDown;
    private readonly InputAction m_Joystick_Enter;
    public struct JoystickActions
    {
        private @InputButton m_Wrapper;
        public JoystickActions(@InputButton wrapper) { m_Wrapper = wrapper; }
        public InputAction @StickUp => m_Wrapper.m_Joystick_StickUp;
        public InputAction @StickDown => m_Wrapper.m_Joystick_StickDown;
        public InputAction @Enter => m_Wrapper.m_Joystick_Enter;
        public InputActionMap Get() { return m_Wrapper.m_Joystick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoystickActions set) { return set.Get(); }
        public void SetCallbacks(IJoystickActions instance)
        {
            if (m_Wrapper.m_JoystickActionsCallbackInterface != null)
            {
                @StickUp.started -= m_Wrapper.m_JoystickActionsCallbackInterface.OnStickUp;
                @StickUp.performed -= m_Wrapper.m_JoystickActionsCallbackInterface.OnStickUp;
                @StickUp.canceled -= m_Wrapper.m_JoystickActionsCallbackInterface.OnStickUp;
                @StickDown.started -= m_Wrapper.m_JoystickActionsCallbackInterface.OnStickDown;
                @StickDown.performed -= m_Wrapper.m_JoystickActionsCallbackInterface.OnStickDown;
                @StickDown.canceled -= m_Wrapper.m_JoystickActionsCallbackInterface.OnStickDown;
                @Enter.started -= m_Wrapper.m_JoystickActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_JoystickActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_JoystickActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_JoystickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StickUp.started += instance.OnStickUp;
                @StickUp.performed += instance.OnStickUp;
                @StickUp.canceled += instance.OnStickUp;
                @StickDown.started += instance.OnStickDown;
                @StickDown.performed += instance.OnStickDown;
                @StickDown.canceled += instance.OnStickDown;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public JoystickActions @Joystick => new JoystickActions(this);
    public interface IJoystickActions
    {
        void OnStickUp(InputAction.CallbackContext context);
        void OnStickDown(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}
