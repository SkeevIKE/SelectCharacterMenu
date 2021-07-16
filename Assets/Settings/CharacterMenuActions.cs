// GENERATED AUTOMATICALLY FROM 'Assets/Settings/CharacterMenuActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterMenuActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterMenuActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterMenuActions"",
    ""maps"": [
        {
            ""name"": ""MainMap"",
            ""id"": ""eecaa246-84e9-4f73-a807-fa82e4a94b5d"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""df70d285-dea1-43d0-be00-89c29bd2873d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMosePressd"",
                    ""type"": ""Button"",
                    ""id"": ""3dad9b48-f37a-4e2d-8b3d-8e351c74315b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4ec0a10f-bec8-4389-a712-a26f3367d201"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07223846-ff75-4354-b358-722fd7dcf743"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMosePressd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMap
        m_MainMap = asset.FindActionMap("MainMap", throwIfNotFound: true);
        m_MainMap_MousePosition = m_MainMap.FindAction("MousePosition", throwIfNotFound: true);
        m_MainMap_LeftMosePressd = m_MainMap.FindAction("LeftMosePressd", throwIfNotFound: true);
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

    // MainMap
    private readonly InputActionMap m_MainMap;
    private IMainMapActions m_MainMapActionsCallbackInterface;
    private readonly InputAction m_MainMap_MousePosition;
    private readonly InputAction m_MainMap_LeftMosePressd;
    public struct MainMapActions
    {
        private @CharacterMenuActions m_Wrapper;
        public MainMapActions(@CharacterMenuActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_MainMap_MousePosition;
        public InputAction @LeftMosePressd => m_Wrapper.m_MainMap_LeftMosePressd;
        public InputActionMap Get() { return m_Wrapper.m_MainMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMapActions set) { return set.Get(); }
        public void SetCallbacks(IMainMapActions instance)
        {
            if (m_Wrapper.m_MainMapActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnMousePosition;
                @LeftMosePressd.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnLeftMosePressd;
                @LeftMosePressd.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnLeftMosePressd;
                @LeftMosePressd.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnLeftMosePressd;
            }
            m_Wrapper.m_MainMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @LeftMosePressd.started += instance.OnLeftMosePressd;
                @LeftMosePressd.performed += instance.OnLeftMosePressd;
                @LeftMosePressd.canceled += instance.OnLeftMosePressd;
            }
        }
    }
    public MainMapActions @MainMap => new MainMapActions(this);
    public interface IMainMapActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnLeftMosePressd(InputAction.CallbackContext context);
    }
}
