using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SelectCharacterMenu
{
    public class CharacterPanelControl : MonoBehaviour
    {
        [SerializeField]
        private CharacterData _characterData;
        private TextMeshProUGUI _nameText;

        public CharacterSceneControl CurentCharacterSceneControl { get; private set; }

        private const string _idleAnimationConst = "Idle";      

        [SerializeField]
        private bool _isSelectCharacterScene;

        private void Awake()
        {           

            if (_isSelectCharacterScene)
            {
                if (_characterData == null)
                {
                    Debug.LogError($"Character Data in {name} cannot be empty");
                    return;
                }
            }
            else
            {
                _characterData = CharacterSelectManager.InstanceSelectManager.CurentCharacterData;
                GetComponentInChildren<RawImage>().texture = _characterData.RenderTexture;               
            }

            _nameText = GetComponentInChildren<TextMeshProUGUI>();
            _nameText.text = _characterData.CharacterName.ToString();

            CurentCharacterSceneControl = Instantiate(_characterData.CharacterScene);
            CurentCharacterSceneControl.InitialiseSpawnCharacterItems(_characterData);

            // setting the speed of playing animations
            CurentCharacterSceneControl.SetAnimationSpeed(speed: _characterData.CharacterAnimationSpeed);

            // initial animation(scene dependent)
            if (_isSelectCharacterScene)
            {
                CurentCharacterSceneControl.PlayRandomAnimation();
            }
            else
            {
                CurentCharacterSceneControl.PlaySelectAnimation(_idleAnimationConst);
                CurentCharacterSceneControl.CameraInScene.rect = new Rect(0, 0, 1, 1);
            }
        }

        public void ClickSelectCharacterPanel()
        {
            CharacterSelectManager characterSelectManager = CharacterSelectManager.InstanceSelectManager;

            characterSelectManager.CurentCharacterData = _characterData;          
            SceneManager.LoadScene(1);
        }

        public void ClickApplyButton()
        {
            _characterData.EquippedHat = CurentCharacterSceneControl.OldHatdata;
            _characterData.EquippedWeapon = CurentCharacterSceneControl.OldWeaponData;
        }

        public void ClickBuckButton()
        {
            SceneManager.LoadScene(0);
        }

        public void AnimationButtonClick(string animationName)
        {
            CurentCharacterSceneControl.PlaySelectAnimation(animationName);
        }
    }
}
