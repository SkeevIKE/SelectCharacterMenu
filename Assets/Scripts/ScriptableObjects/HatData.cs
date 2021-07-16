using UnityEngine;

namespace SelectCharacterMenu
{
    [CreateAssetMenu(fileName = "New_Hat", menuName = "ScriptableObjects/Hat", order = 51)]
    public class HatData : ScriptableObject
    {
        [SerializeField]
        private ArmorTypes _armorType;
        public ArmorTypes ArmorType => _armorType;

        [SerializeField]
        private string _hatName;
        public string HatName => _hatName;

        [SerializeField]
        private EquipmentControl _hatObject;
        public EquipmentControl HatObject => _hatObject;       
    }
}
