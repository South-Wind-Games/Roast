// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Roasts/Input/RoastsInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @RoastsInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @RoastsInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RoastsInput"",
    ""maps"": [
        {
            ""name"": ""Default Mode"",
            ""id"": ""5c84e9eb-6d8c-4b42-871b-3dd5e8543ed8"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""82807604-d58a-4b56-a303-9ebde1803684"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""93535ad5-da75-4f13-95c8-ee39a721204d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""a9b32a91-d398-4a91-ba32-ddb0349e817e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""ScaleVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rocket"",
                    ""type"": ""Button"",
                    ""id"": ""97fe58d4-8ec4-4298-8c50-477ae8994ce2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2e69f500-2ca4-4205-8609-0f1f14f14bd2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ba42df34-c46c-4e64-b49a-337e312f9180"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b73f3f7b-07a7-4855-97f1-c7f637fe0827"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bfcaebb5-e9e1-4fb5-8e5b-ae4df6dab9e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""48fa183c-4606-41d9-a784-f841711ee617"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6fce0cfc-524a-4735-9151-a75dbf234cf8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""932b352d-f0fc-4846-a0c0-57773e06dc83"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d16932af-01f7-40df-bea3-1019db330cfd"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6584cb6-b95b-4a41-a451-0721f9a11520"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b88c9e39-bd81-441c-a177-76bc47299ac6"",
                    ""path"": ""<Keyboard>/#(1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Rocket"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5957f4b5-93a4-4aed-8a64-fe0c460f0c2c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Rocket"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default"",
            ""bindingGroup"": ""Default"",
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
        },
        {
            ""name"": ""Old School"",
            ""bindingGroup"": ""Old School"",
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
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Default Mode
        m_DefaultMode = asset.FindActionMap("Default Mode", throwIfNotFound: true);
        m_DefaultMode_WASD = m_DefaultMode.FindAction("WASD", throwIfNotFound: true);
        m_DefaultMode_Aim = m_DefaultMode.FindAction("Aim", throwIfNotFound: true);
        m_DefaultMode_Fire = m_DefaultMode.FindAction("Fire", throwIfNotFound: true);
        m_DefaultMode_Rocket = m_DefaultMode.FindAction("Rocket", throwIfNotFound: true);
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

    // Default Mode
    private readonly InputActionMap m_DefaultMode;
    private IDefaultModeActions m_DefaultModeActionsCallbackInterface;
    private readonly InputAction m_DefaultMode_WASD;
    private readonly InputAction m_DefaultMode_Aim;
    private readonly InputAction m_DefaultMode_Fire;
    private readonly InputAction m_DefaultMode_Rocket;
    public struct DefaultModeActions
    {
        private @RoastsInput m_Wrapper;
        public DefaultModeActions(@RoastsInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_DefaultMode_WASD;
        public InputAction @Aim => m_Wrapper.m_DefaultMode_Aim;
        public InputAction @Fire => m_Wrapper.m_DefaultMode_Fire;
        public InputAction @Rocket => m_Wrapper.m_DefaultMode_Rocket;
        public InputActionMap Get() { return m_Wrapper.m_DefaultMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultModeActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultModeActions instance)
        {
            if (m_Wrapper.m_DefaultModeActionsCallbackInterface != null)
            {
                @WASD.started -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnWASD;
                @Aim.started -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnAim;
                @Fire.started -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnFire;
                @Rocket.started -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnRocket;
                @Rocket.performed -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnRocket;
                @Rocket.canceled -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnRocket;
            }
            m_Wrapper.m_DefaultModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Rocket.started += instance.OnRocket;
                @Rocket.performed += instance.OnRocket;
                @Rocket.canceled += instance.OnRocket;
            }
        }
    }
    public DefaultModeActions @DefaultMode => new DefaultModeActions(this);
    private int m_DefaultSchemeIndex = -1;
    public InputControlScheme DefaultScheme
    {
        get
        {
            if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.FindControlSchemeIndex("Default");
            return asset.controlSchemes[m_DefaultSchemeIndex];
        }
    }
    private int m_OldSchoolSchemeIndex = -1;
    public InputControlScheme OldSchoolScheme
    {
        get
        {
            if (m_OldSchoolSchemeIndex == -1) m_OldSchoolSchemeIndex = asset.FindControlSchemeIndex("Old School");
            return asset.controlSchemes[m_OldSchoolSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IDefaultModeActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnRocket(InputAction.CallbackContext context);
    }
}
