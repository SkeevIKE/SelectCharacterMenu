using UnityEngine;

namespace SelectCharacterMenu
{
    public class ItemPanel : MonoBehaviour
    {
        [SerializeField]
        private CharacterPanelControl characterPanelControl;

        private CharacterData _curentCharacterData;

        [SerializeField]
        private HatData _hatData;

        [SerializeField]
        private WeaponData _weaponData;

        [SerializeField]
        private bool isHat;

        private void Start()
        {            
            _curentCharacterData = CharacterSelectManager.InstanceSelectManager.CurentCharacterData;
        }

        public void ClickItemPanel()
        {           
            characterPanelControl.CurentCharacterSceneControl.ChangeSpawnCharacterItems(isHat, _hatData, _weaponData);
        }
    }
}
