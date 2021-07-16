using UnityEngine;

namespace SelectCharacterMenu
{
    [CreateAssetMenu(fileName = "New_Weapon", menuName = "ScriptableObjects/Weapon", order = 51)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField]
        private WeaponTypes _weaponType;
        public WeaponTypes WeaponType => _weaponType;

        [SerializeField]
        private string _weaponName;
        public string WeaponName => _weaponName;

        [SerializeField]
        private EquipmentControl _weaponObject;
        public EquipmentControl WeaponObject => _weaponObject;
    }
}
