using UnityEngine;
using UnityEngine.UI;

namespace SelectCharacterMenu
{
    public class CharacterPreviewScreen : MonoBehaviour
    {
        private CharacterPanelControl _curentCharacterPanelControl;
        private Toggle[] _toggles;
        private string _animationName;

        private void Awake()
        {
            _toggles = GetComponentsInChildren<Toggle>();
        }

        public void ToggleClick(string animationName)
        {
            _curentCharacterPanelControl.CurentCharacterSceneControl.PlaySelectAnimation(animationName);
        }

        public void ToggleClick(Toggle toggle)
        {
            for (int i = 0; i < _toggles.Length; i++)
            {
                if (_toggles[i] == toggle && toggle.name == _animationName)
                {
                    _curentCharacterPanelControl.CurentCharacterSceneControl.PlaySelectAnimation(_animationName);
                }
            }
        }
    }
}
