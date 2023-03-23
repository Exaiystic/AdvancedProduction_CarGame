// GENERATED AUTOMATICALLY FROM 'Assets/Input/Driving.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Driving : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Driving()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Driving"",
    ""maps"": [
        {
            ""name"": ""PlayerSteering"",
            ""id"": ""d3d06454-d291-439a-a627-ac46a1af7a4d"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d874eb7c-05cf-438f-a24e-4e54353e3c18"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bac56593-1f22-403d-bea9-370ecceddfad"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""fc0fe658-7da4-4bb6-bdf5-215b2d1941d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d68c6b39-35de-4b6c-93d8-4f976e1b24ef"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bd601f7f-0f1e-4730-a929-e2eda1ba3f8d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""67d06443-23a3-48b7-8a64-3913a63b884e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""d3bbb708-8353-4256-b8cd-f0e732ccb043"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1f5317c2-3b92-4519-ad98-347066d8a0c8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b54c88fa-bcc6-4263-8b2e-84507ecb4c6a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f24e865c-887b-40ce-b278-6894a11de525"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerSteering
        m_PlayerSteering = asset.FindActionMap("PlayerSteering", throwIfNotFound: true);
        m_PlayerSteering_Throttle = m_PlayerSteering.FindAction("Throttle", throwIfNotFound: true);
        m_PlayerSteering_Steering = m_PlayerSteering.FindAction("Steering", throwIfNotFound: true);
        m_PlayerSteering_Pause = m_PlayerSteering.FindAction("Pause", throwIfNotFound: true);
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

    // PlayerSteering
    private readonly InputActionMap m_PlayerSteering;
    private IPlayerSteeringActions m_PlayerSteeringActionsCallbackInterface;
    private readonly InputAction m_PlayerSteering_Throttle;
    private readonly InputAction m_PlayerSteering_Steering;
    private readonly InputAction m_PlayerSteering_Pause;
    public struct PlayerSteeringActions
    {
        private @Driving m_Wrapper;
        public PlayerSteeringActions(@Driving wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_PlayerSteering_Throttle;
        public InputAction @Steering => m_Wrapper.m_PlayerSteering_Steering;
        public InputAction @Pause => m_Wrapper.m_PlayerSteering_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerSteering; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerSteeringActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerSteeringActions instance)
        {
            if (m_Wrapper.m_PlayerSteeringActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnThrottle;
                @Steering.started -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnSteering;
                @Pause.started -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerSteeringActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerSteeringActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerSteeringActions @PlayerSteering => new PlayerSteeringActions(this);
    public interface IPlayerSteeringActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
