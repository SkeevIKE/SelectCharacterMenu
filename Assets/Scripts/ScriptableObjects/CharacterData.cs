using UnityEngine;

namespace SelectCharacterMenu
{
    [CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObjects/Character", order = 51)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField]
        private CharacterNames _characterName;
        public CharacterNames CharacterName => _characterName;

        [SerializeField]
        private CharacterSceneControl _characterScene;
        public CharacterSceneControl CharacterScene => _characterScene;

        [Header("SPEED VALUE ANIMATION")]        
        [SerializeField][Range(0.5f, 1.5f)]
        private float _characterAnimationSpeed;
        public float CharacterAnimationSpeed => _characterAnimationSpeed;
        
        [Header("CHARACTER WEARING HAT")]
        [SerializeField]
        private ArmorTypes _armorTypesPermitted;
        public ArmorTypes ArmorTypesPermitted => _armorTypesPermitted;
       
        [SerializeField]
        private HatData _equippedHat;
        public HatData EquippedHat { get => _equippedHat; set => _equippedHat = value; }

        [Header("CHARACTER USE WEAPON")]
        [SerializeField]
        private WeaponTypes _weaponTypesPermitted;
        public WeaponTypes WeaponTypesPermitted => _weaponTypesPermitted;
        
        [SerializeField]
        private WeaponData _equippedWeapon;
        public WeaponData EquippedWeapon { get => _equippedWeapon; set => _equippedWeapon = value; }

        [SerializeField]
        private RenderTexture _renderTexture;
        public RenderTexture RenderTexture  => _renderTexture;
    }
}
