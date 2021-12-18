// GENERATED AUTOMATICALLY FROM 'Assets/Input System/GeneralControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GeneralControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GeneralControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GeneralControl"",
    ""maps"": [
        {
            ""name"": ""Butter"",
            ""id"": ""ac03632a-cefc-45a8-8d15-8e9cdfb46c92"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9c6746b6-3331-4a3f-9422-714d9999d162"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5e495746-ba1f-42d0-9f30-1f47254ffac2"",
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
                    ""id"": ""b4b52e9d-f499-4f52-b2bb-24e5bb7b414b"",
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
                    ""id"": ""f284e53a-5c7e-4373-aaac-c98d79677618"",
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
                    ""id"": ""f795d93d-10d8-4ffe-bc8f-cc3c8a12d817"",
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
                    ""id"": ""4a952547-b7f4-467e-a929-819d0ced148e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Butter
        m_Butter = asset.FindActionMap("Butter", throwIfNotFound: true);
        m_Butter_Move = m_Butter.FindAction("Move", throwIfNotFound: true);
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

    // Butter
    private readonly InputActionMap m_Butter;
    private IButterActions m_ButterActionsCallbackInterface;
    private readonly InputAction m_Butter_Move;
    public struct ButterActions
    {
        private @GeneralControl m_Wrapper;
        public ButterActions(@GeneralControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Butter_Move;
        public InputActionMap Get() { return m_Wrapper.m_Butter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ButterActions set) { return set.Get(); }
        public void SetCallbacks(IButterActions instance)
        {
            if (m_Wrapper.m_ButterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ButterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ButterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ButterActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_ButterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public ButterActions @Butter => new ButterActions(this);
    public interface IButterActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
