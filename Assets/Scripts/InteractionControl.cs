using UnityEngine;
namespace SelectCharacterMenu
{
    public class InteractionControl : MonoBehaviour
    {
        private CharacterMenuActions _characterMenuActions;
        private bool _isRotation;
        private CharacterSceneControl _characterSceneControl;
        private float _oldValueX, _curentValueX;
        private Camera _sceneCamera;
        private void Awake()
        {
            _characterMenuActions = new CharacterMenuActions();
            _characterMenuActions.MainMap.LeftMosePressd.performed += _ => ClickOnRotationZone();
            _characterMenuActions.MainMap.LeftMosePressd.canceled += _ =>
            {
                _isRotation = false;                
            };
            _sceneCamera = Camera.main;
        }
        private void Start()
        {
            _characterSceneControl = GetComponentInChildren<CharacterPanelControl>().CurentCharacterSceneControl;
        }

        private void ClickOnRotationZone()
        {

            Vector2 originPosition = _characterMenuActions.MainMap.MousePosition.ReadValue<Vector2>();
            RaycastHit hit;
            Ray ray = _sceneCamera.ScreenPointToRay(originPosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null && hit.transform.TryGetComponent(out ZoneMark zone))
                {
                    _isRotation = true;
                    _oldValueX = originPosition.x;
                }                
            }
            
            
           
        }

        private void Update()
        {            
            if (_isRotation)
            {
                _curentValueX = _characterMenuActions.MainMap.MousePosition.ReadValue<Vector2>().x;               
                _characterSceneControl.SetDirectionRotation(_curentValueX - _oldValueX);
                _oldValueX = _characterMenuActions.MainMap.MousePosition.ReadValue<Vector2>().x;
            }

        }

        private void OnEnable()
        {
            _characterMenuActions.Enable();
        }

        private void OnDisable()
        {
            _characterMenuActions.Disable();
        }
    }
}
