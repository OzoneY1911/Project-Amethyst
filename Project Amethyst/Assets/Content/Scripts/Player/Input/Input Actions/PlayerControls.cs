//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Content/Scripts/Player/Input/Input Actions/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ad41168f-83a9-463f-9c8b-2a11c4d3f14f"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dfe64068-06ad-4172-a0b7-0ed8617f4e80"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""367f577a-3bd0-4be2-97fc-f1ebea2ad3a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a01446da-0d7a-4d68-a1b3-15f46b705079"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fb2030bc-6f98-4918-a18c-d3c5bc52fb13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""69535215-7172-49ca-a5df-de6d23f2e652"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""2b730aa9-1182-42a2-a89a-1b3c8a0c67c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DrawPistol"",
                    ""type"": ""Button"",
                    ""id"": ""d8638fbd-f92d-44b7-b899-fafe4bb6c5c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DrawShotgun"",
                    ""type"": ""Button"",
                    ""id"": ""0e1e1474-a6ee-4fd9-9668-0ede42c92e72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DrawRifle"",
                    ""type"": ""Button"",
                    ""id"": ""e8c39586-b180-44e7-8073-ad3918ade88b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3a1fa560-1e74-4eb5-b559-80751c6b82a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""348f2f7a-5b51-41eb-92ff-a3176a3044de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""05caaf7b-7ac1-4d22-940f-fb8ec8c4d63e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2a5133ab-d7cc-4639-a4d1-8d6b3aa63cff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8608707d-b501-436f-bf47-6a67c30fbdb2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d5031e95-cab1-4c32-bf7c-e54536a78bd0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""af9129cd-0d73-49f3-9913-e63aa888a73c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""35a6bf4e-5f28-4829-8b60-0d7c8c2f0642"",
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
                    ""id"": ""3b818a6a-6b78-49e6-bf64-6e0c9ece9e3b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0b7c17a-1876-497f-98f9-9dfb3a3502c7"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9039f835-3257-4a18-88dd-1e68b9df4886"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f246db77-fc01-4352-870c-905183bd3939"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47d34d2f-e862-4057-926e-7d961521acbb"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DrawPistol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""931095c0-67fe-4a9e-9509-d7d4f34d4fcb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DrawShotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7a2a4e-3c2f-4c43-b8b4-116d3d69e0d8"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DrawRifle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""035ac5d2-1f9d-4300-b6a9-57ea84c5f83d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427db4bb-160b-42c2-bedb-1645ff58018a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""d0312076-f627-428c-9459-399112afdf28"",
            ""actions"": [
                {
                    ""name"": ""EscapeUI"",
                    ""type"": ""Button"",
                    ""id"": ""bef0abfd-03f3-4274-b8d1-7899d42d6eb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CloseUI"",
                    ""type"": ""Button"",
                    ""id"": ""e43060d3-69f5-4934-b65f-075858cbe098"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""8f9c7a97-faab-4da6-9e01-c1c3a1610181"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""21dbb7e7-a85f-4177-b474-13ef35a459e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""0b37c7a3-8707-4185-8fcb-efdc982b564b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a534c5ac-f2c0-4de9-a513-41de8e6a424d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EscapeUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7f662a1-9b41-4aff-91ce-3c941a11c6d6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CloseUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62654477-9fb5-4d31-9fff-c402349361e6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5dae75e-f261-4ba8-8c0a-92d6f1d7e623"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e60fb9aa-3fa5-46d9-a294-d77bc0868088"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
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
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Shot = m_Player.FindAction("Shot", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_DrawPistol = m_Player.FindAction("DrawPistol", throwIfNotFound: true);
        m_Player_DrawShotgun = m_Player.FindAction("DrawShotgun", throwIfNotFound: true);
        m_Player_DrawRifle = m_Player.FindAction("DrawRifle", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_PauseMenu = m_Player.FindAction("PauseMenu", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_EscapeUI = m_UI.FindAction("EscapeUI", throwIfNotFound: true);
        m_UI_CloseUI = m_UI.FindAction("CloseUI", throwIfNotFound: true);
        m_UI_Left = m_UI.FindAction("Left", throwIfNotFound: true);
        m_UI_Up = m_UI.FindAction("Up", throwIfNotFound: true);
        m_UI_Right = m_UI.FindAction("Right", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Shot;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_DrawPistol;
    private readonly InputAction m_Player_DrawShotgun;
    private readonly InputAction m_Player_DrawRifle;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_PauseMenu;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Shot => m_Wrapper.m_Player_Shot;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @DrawPistol => m_Wrapper.m_Player_DrawPistol;
        public InputAction @DrawShotgun => m_Wrapper.m_Player_DrawShotgun;
        public InputAction @DrawRifle => m_Wrapper.m_Player_DrawRifle;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @PauseMenu => m_Wrapper.m_Player_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Shot.started += instance.OnShot;
            @Shot.performed += instance.OnShot;
            @Shot.canceled += instance.OnShot;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @DrawPistol.started += instance.OnDrawPistol;
            @DrawPistol.performed += instance.OnDrawPistol;
            @DrawPistol.canceled += instance.OnDrawPistol;
            @DrawShotgun.started += instance.OnDrawShotgun;
            @DrawShotgun.performed += instance.OnDrawShotgun;
            @DrawShotgun.canceled += instance.OnDrawShotgun;
            @DrawRifle.started += instance.OnDrawRifle;
            @DrawRifle.performed += instance.OnDrawRifle;
            @DrawRifle.canceled += instance.OnDrawRifle;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @PauseMenu.started += instance.OnPauseMenu;
            @PauseMenu.performed += instance.OnPauseMenu;
            @PauseMenu.canceled += instance.OnPauseMenu;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Shot.started -= instance.OnShot;
            @Shot.performed -= instance.OnShot;
            @Shot.canceled -= instance.OnShot;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @DrawPistol.started -= instance.OnDrawPistol;
            @DrawPistol.performed -= instance.OnDrawPistol;
            @DrawPistol.canceled -= instance.OnDrawPistol;
            @DrawShotgun.started -= instance.OnDrawShotgun;
            @DrawShotgun.performed -= instance.OnDrawShotgun;
            @DrawShotgun.canceled -= instance.OnDrawShotgun;
            @DrawRifle.started -= instance.OnDrawRifle;
            @DrawRifle.performed -= instance.OnDrawRifle;
            @DrawRifle.canceled -= instance.OnDrawRifle;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @PauseMenu.started -= instance.OnPauseMenu;
            @PauseMenu.performed -= instance.OnPauseMenu;
            @PauseMenu.canceled -= instance.OnPauseMenu;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_EscapeUI;
    private readonly InputAction m_UI_CloseUI;
    private readonly InputAction m_UI_Left;
    private readonly InputAction m_UI_Up;
    private readonly InputAction m_UI_Right;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @EscapeUI => m_Wrapper.m_UI_EscapeUI;
        public InputAction @CloseUI => m_Wrapper.m_UI_CloseUI;
        public InputAction @Left => m_Wrapper.m_UI_Left;
        public InputAction @Up => m_Wrapper.m_UI_Up;
        public InputAction @Right => m_Wrapper.m_UI_Right;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @EscapeUI.started += instance.OnEscapeUI;
            @EscapeUI.performed += instance.OnEscapeUI;
            @EscapeUI.canceled += instance.OnEscapeUI;
            @CloseUI.started += instance.OnCloseUI;
            @CloseUI.performed += instance.OnCloseUI;
            @CloseUI.canceled += instance.OnCloseUI;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Up.started += instance.OnUp;
            @Up.performed += instance.OnUp;
            @Up.canceled += instance.OnUp;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @EscapeUI.started -= instance.OnEscapeUI;
            @EscapeUI.performed -= instance.OnEscapeUI;
            @EscapeUI.canceled -= instance.OnEscapeUI;
            @CloseUI.started -= instance.OnCloseUI;
            @CloseUI.performed -= instance.OnCloseUI;
            @CloseUI.canceled -= instance.OnCloseUI;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Up.started -= instance.OnUp;
            @Up.performed -= instance.OnUp;
            @Up.canceled -= instance.OnUp;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnDrawPistol(InputAction.CallbackContext context);
        void OnDrawShotgun(InputAction.CallbackContext context);
        void OnDrawRifle(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnEscapeUI(InputAction.CallbackContext context);
        void OnCloseUI(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
