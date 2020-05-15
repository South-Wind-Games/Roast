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
                    ""type"": ""Button"",
                    ""id"": ""82807604-d58a-4b56-a303-9ebde1803684"",
                    ""expectedControlType"": ""Button"",
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
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""8b6d7769-f0a9-43d3-a673-2d92f1070e74"",
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
                    ""id"": ""932b352d-f0fc-4846-a0c0-57773e06dc83"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
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
                    ""id"": ""2c80807d-1617-47fb-ac5b-6e10681d4339"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Old School;Default"",
                    ""action"": ""Select"",
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
        }
    ]
}");
        // Default Mode
        m_DefaultMode = asset.FindActionMap("Default Mode", throwIfNotFound: true);
        m_DefaultMode_WASD = m_DefaultMode.FindAction("WASD", throwIfNotFound: true);
        m_DefaultMode_Aim = m_DefaultMode.FindAction("Aim", throwIfNotFound: true);
        m_DefaultMode_Select = m_DefaultMode.FindAction("Select", throwIfNotFound: true);
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
    private readonly InputAction m_DefaultMode_Select;
    public struct DefaultModeActions
    {
        private @RoastsInput m_Wrapper;
        public DefaultModeActions(@RoastsInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_DefaultMode_WASD;
        public InputAction @Aim => m_Wrapper.m_DefaultMode_Aim;
        public InputAction @Select => m_Wrapper.m_DefaultMode_Select;
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
                @Select.started -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_DefaultModeActionsCallbackInterface.OnSelect;
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
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
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
    public interface IDefaultModeActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
