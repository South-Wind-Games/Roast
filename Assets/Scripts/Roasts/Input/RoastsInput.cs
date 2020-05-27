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
            ""name"": ""Roast Map"",
            ""id"": ""5c84e9eb-6d8c-4b42-871b-3dd5e8543ed8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
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
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""8b6d7769-f0a9-43d3-a673-2d92f1070e74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveToCoordinates"",
                    ""type"": ""Button"",
                    ""id"": ""3f42bc93-bd6c-49d2-a3e3-b9c23ea15896"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UsePrimarySkill"",
                    ""type"": ""Button"",
                    ""id"": ""dc6a5ef6-d261-4b5f-944d-2b13149e0300"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseSecondarySkill"",
                    ""type"": ""Button"",
                    ""id"": ""17b6f430-af56-44d2-96f5-4aa89715a498"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2e69f500-2ca4-4205-8609-0f1f14f14bd2"",
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
                    ""id"": ""ba42df34-c46c-4e64-b49a-337e312f9180"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b73f3f7b-07a7-4855-97f1-c7f637fe0827"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bfcaebb5-e9e1-4fb5-8e5b-ae4df6dab9e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""48fa183c-4606-41d9-a784-f841711ee617"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bbb31180-868c-4a04-bce6-82fc4f60d166"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
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
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c80807d-1617-47fb-ac5b-6e10681d4339"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c595ac2-62d8-451e-8f49-cb79bd3f6097"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveToCoordinates"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b66836d-8e3d-479f-9cde-ee94d982036b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""UsePrimarySkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2f3b7be-e1f9-4df1-a9b1-a5ccdb8a8645"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""UseSecondarySkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
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
        // Roast Map
        m_RoastMap = asset.FindActionMap("Roast Map", throwIfNotFound: true);
        m_RoastMap_Move = m_RoastMap.FindAction("Move", throwIfNotFound: true);
        m_RoastMap_Aim = m_RoastMap.FindAction("Aim", throwIfNotFound: true);
        m_RoastMap_Select = m_RoastMap.FindAction("Select", throwIfNotFound: true);
        m_RoastMap_MoveToCoordinates = m_RoastMap.FindAction("MoveToCoordinates", throwIfNotFound: true);
        m_RoastMap_UsePrimarySkill = m_RoastMap.FindAction("UsePrimarySkill", throwIfNotFound: true);
        m_RoastMap_UseSecondarySkill = m_RoastMap.FindAction("UseSecondarySkill", throwIfNotFound: true);
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

    // Roast Map
    private readonly InputActionMap m_RoastMap;
    private IRoastMapActions m_RoastMapActionsCallbackInterface;
    private readonly InputAction m_RoastMap_Move;
    private readonly InputAction m_RoastMap_Aim;
    private readonly InputAction m_RoastMap_Select;
    private readonly InputAction m_RoastMap_MoveToCoordinates;
    private readonly InputAction m_RoastMap_UsePrimarySkill;
    private readonly InputAction m_RoastMap_UseSecondarySkill;
    public struct RoastMapActions
    {
        private @RoastsInput m_Wrapper;
        public RoastMapActions(@RoastsInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_RoastMap_Move;
        public InputAction @Aim => m_Wrapper.m_RoastMap_Aim;
        public InputAction @Select => m_Wrapper.m_RoastMap_Select;
        public InputAction @MoveToCoordinates => m_Wrapper.m_RoastMap_MoveToCoordinates;
        public InputAction @UsePrimarySkill => m_Wrapper.m_RoastMap_UsePrimarySkill;
        public InputAction @UseSecondarySkill => m_Wrapper.m_RoastMap_UseSecondarySkill;
        public InputActionMap Get() { return m_Wrapper.m_RoastMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RoastMapActions set) { return set.Get(); }
        public void SetCallbacks(IRoastMapActions instance)
        {
            if (m_Wrapper.m_RoastMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnAim;
                @Select.started -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnSelect;
                @MoveToCoordinates.started -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnMoveToCoordinates;
                @MoveToCoordinates.performed -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnMoveToCoordinates;
                @MoveToCoordinates.canceled -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnMoveToCoordinates;
                @UsePrimarySkill.started -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnUsePrimarySkill;
                @UsePrimarySkill.performed -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnUsePrimarySkill;
                @UsePrimarySkill.canceled -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnUsePrimarySkill;
                @UseSecondarySkill.started -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnUseSecondarySkill;
                @UseSecondarySkill.performed -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnUseSecondarySkill;
                @UseSecondarySkill.canceled -= m_Wrapper.m_RoastMapActionsCallbackInterface.OnUseSecondarySkill;
            }
            m_Wrapper.m_RoastMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MoveToCoordinates.started += instance.OnMoveToCoordinates;
                @MoveToCoordinates.performed += instance.OnMoveToCoordinates;
                @MoveToCoordinates.canceled += instance.OnMoveToCoordinates;
                @UsePrimarySkill.started += instance.OnUsePrimarySkill;
                @UsePrimarySkill.performed += instance.OnUsePrimarySkill;
                @UsePrimarySkill.canceled += instance.OnUsePrimarySkill;
                @UseSecondarySkill.started += instance.OnUseSecondarySkill;
                @UseSecondarySkill.performed += instance.OnUseSecondarySkill;
                @UseSecondarySkill.canceled += instance.OnUseSecondarySkill;
            }
        }
    }
    public RoastMapActions @RoastMap => new RoastMapActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
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
    public interface IRoastMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnMoveToCoordinates(InputAction.CallbackContext context);
        void OnUsePrimarySkill(InputAction.CallbackContext context);
        void OnUseSecondarySkill(InputAction.CallbackContext context);
    }
}
