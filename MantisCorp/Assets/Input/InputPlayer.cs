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
                    ""type"": ""Value"",
                    ""id"": ""a56f70d8-0527-4791-8aa5-05d29ddd4e62"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayerJump"",
                    ""type"": ""Button"",
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
                },
                {
                    ""name"": ""PlayerVisionNight"",
                    ""type"": ""Button"",
                    ""id"": ""ab044b33-4d75-4721-9228-a2d3184b5edd"",
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
                    ""groups"": ""KeyBoard"",
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
                    ""groups"": ""KeyBoard"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8d4c02e6-198d-4dae-9cba-47f47d2ea6b2"",
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
                    ""id"": ""a64b9deb-97be-4128-a409-3ad01fcfc8c4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controle"",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""93dd6bd2-f502-459c-9d99-16720cd94558"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controle"",
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
                    ""groups"": ""KeyBoard"",
                    ""action"": ""PlayerJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c987f81f-0547-4485-8e78-bb902a393b43"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controle"",
                    ""action"": ""PlayerJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""387f94c2-71a3-43f6-ae1b-57e062c2eddd"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""PlayerShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0bb3ab4-10fa-4f6c-9ac9-d2a252639105"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controle"",
                    ""action"": ""PlayerShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9692518c-f80d-4d9d-a65d-8caa30916c37"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""PlayerVisionNight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acd1c841-6c7b-4875-bcf5-dedb10a2fa40"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controle"",
                    ""action"": ""PlayerVisionNight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controle"",
            ""bindingGroup"": ""Controle"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PlayerMove = m_Player.FindAction("PlayerMove", throwIfNotFound: true);
        m_Player_PlayerJump = m_Player.FindAction("PlayerJump", throwIfNotFound: true);
        m_Player_PlayerShoot = m_Player.FindAction("PlayerShoot", throwIfNotFound: true);
        m_Player_PlayerVisionNight = m_Player.FindAction("PlayerVisionNight", throwIfNotFound: true);
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
    private readonly InputAction m_Player_PlayerVisionNight;
    public struct PlayerActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMove => m_Wrapper.m_Player_PlayerMove;
        public InputAction @PlayerJump => m_Wrapper.m_Player_PlayerJump;
        public InputAction @PlayerShoot => m_Wrapper.m_Player_PlayerShoot;
        public InputAction @PlayerVisionNight => m_Wrapper.m_Player_PlayerVisionNight;
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
                @PlayerVisionNight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerVisionNight;
                @PlayerVisionNight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerVisionNight;
                @PlayerVisionNight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerVisionNight;
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
                @PlayerVisionNight.started += instance.OnPlayerVisionNight;
                @PlayerVisionNight.performed += instance.OnPlayerVisionNight;
                @PlayerVisionNight.canceled += instance.OnPlayerVisionNight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_ControleSchemeIndex = -1;
    public InputControlScheme ControleScheme
    {
        get
        {
            if (m_ControleSchemeIndex == -1) m_ControleSchemeIndex = asset.FindControlSchemeIndex("Controle");
            return asset.controlSchemes[m_ControleSchemeIndex];
        }
    }
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnPlayerMove(InputAction.CallbackContext context);
        void OnPlayerJump(InputAction.CallbackContext context);
        void OnPlayerShoot(InputAction.CallbackContext context);
        void OnPlayerVisionNight(InputAction.CallbackContext context);
    }
}
