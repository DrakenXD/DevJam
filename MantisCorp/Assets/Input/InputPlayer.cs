// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPlayer"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""130752d3-639b-4179-83fa-3178b21fd7af"",
            ""actions"": [
                {
                    ""name"": ""PlayerMove"",
                    ""type"": ""Button"",
                    ""id"": ""a56f70d8-0527-4791-8aa5-05d29ddd4e62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayerJump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1a78270a-b507-4e86-86b8-c252ef06d939"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayerShoot"",
                    ""type"": ""Button"",
                    ""id"": ""b2e81ea6-9334-410e-9473-43e5e1d370d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0bd4712b-058e-4c7f-a7f8-8daef0e3d5ee"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1fccafba-62b4-4b06-bf54-8d0c92a08c2a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fef0e0d0-9795-42f7-ae92-ca5cb8553ce6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""33785b21-d6d0-436f-abf7-98f01120049f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""387f94c2-71a3-43f6-ae1b-57e062c2eddd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PlayerMove = m_Player.FindAction("PlayerMove", throwIfNotFound: true);
        m_Player_PlayerJump = m_Player.FindAction("PlayerJump", throwIfNotFound: true);
        m_Player_PlayerShoot = m_Player.FindAction("PlayerShoot", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PlayerMove;
    private readonly InputAction m_Player_PlayerJump;
    private readonly InputAction m_Player_PlayerShoot;
    public struct PlayerActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMove => m_Wrapper.m_Player_PlayerMove;
        public InputAction @PlayerJump => m_Wrapper.m_Player_PlayerJump;
        public InputAction @PlayerShoot => m_Wrapper.m_Player_PlayerShoot;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PlayerMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerMove;
                @PlayerMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerMove;
                @PlayerMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerMove;
                @PlayerJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerJump;
                @PlayerJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerJump;
                @PlayerJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerJump;
                @PlayerShoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerShoot;
                @PlayerShoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerShoot;
                @PlayerShoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerShoot;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlayerMove.started += instance.OnPlayerMove;
                @PlayerMove.performed += instance.OnPlayerMove;
                @PlayerMove.canceled += instance.OnPlayerMove;
                @PlayerJump.started += instance.OnPlayerJump;
                @PlayerJump.performed += instance.OnPlayerJump;
                @PlayerJump.canceled += instance.OnPlayerJump;
                @PlayerShoot.started += instance.OnPlayerShoot;
                @PlayerShoot.performed += instance.OnPlayerShoot;
                @PlayerShoot.canceled += instance.OnPlayerShoot;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPlayerMove(InputAction.CallbackContext context);
        void OnPlayerJump(InputAction.CallbackContext context);
        void OnPlayerShoot(InputAction.CallbackContext context);
    }
}
