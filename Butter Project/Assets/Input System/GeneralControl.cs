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
            ""id"": ""08117c81-ceab-4ced-8de7-74c330f5d47c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""33bf6549-d0fd-47bf-bf57-3c0be834aeef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c6ff1657-1b4b-440a-bdc3-513070a44057"",
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
                    ""id"": ""8cf20610-c6a7-4b9d-90ce-b4013af8741f"",
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
                    ""id"": ""790751a5-eccd-437c-a94b-59fcd904c579"",
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
                    ""id"": ""26df48d5-3a6a-49d1-a523-1d0e1e78e1ed"",
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
                    ""id"": ""3da90ee2-3837-4ae2-8f38-f891e117167a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f0375925-e70e-4388-9886-49c7ed70deed"",
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
                    ""id"": ""55566d9f-8ed8-4301-9464-8c612cfb81a1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""664537f1-1810-4539-a532-3a98f991ac2e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f4a28abe-6598-4c44-a655-d2e0a10cced0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8cd3ab5b-7b05-46b5-ba33-e9977af1e064"",
                    ""path"": ""<Keyboard>/rightArrow"",
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
