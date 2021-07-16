using System.Collections;
using UnityEngine;

namespace SelectCharacterMenu
{
    public class CharacterSceneControl : MonoBehaviour
    {
        private Animator _characterAnimator;

        [SerializeField]
        private Rigidbody _rigedbodyCharacter;

        [SerializeField]
        private Transform _hatPlace;

        [SerializeField]
        private Transform _rightHandWeaponPlace;

        [SerializeField]
        private InteractionSettings _interactionSettings;

        private EquipmentControl _oldHatEquipment;
        private EquipmentControl _oldWeaponEquipment;

        private float _currentRotationSpeed;
        private float _rotationDirection;

        private bool _isSpeedUp, _isSpeedDown;

        public Camera CameraInScene { get; private set; }

        public HatData OldHatdata { get; private set; }
        public WeaponData OldWeaponData { get; private set; }        

        private void Awake()
        {
            _characterAnimator = GetComponentInChildren<Animator>();
            CameraInScene = GetComponentInChildren<Camera>();
            _rigedbodyCharacter.angularDrag = _interactionSettings.RotationInertion;
        }

        public void SetDirectionRotation(float rotationDirection)
        {
            _rigedbodyCharacter.AddRelativeTorque(Vector3.up * -rotationDirection * _interactionSettings.RotationSpeed);           
        }
      
        public void InitialiseSpawnCharacterItems(CharacterData characterData)
        {
            if (characterData.EquippedHat != null)
            {
                EquipmentControl newHat = Instantiate(characterData.EquippedHat.HatObject, _hatPlace);
                OldHatdata = characterData.EquippedHat;
                _oldHatEquipment = newHat;
                newHat.transform.parent = _hatPlace;
                CheckItemTransformProperty(characterData, newHat);
            }

            if (characterData.EquippedWeapon != null)
            {
                EquipmentControl newWeapon = Instantiate(characterData.EquippedWeapon.WeaponObject, _rightHandWeaponPlace);
                OldWeaponData = characterData.EquippedWeapon;
                _oldWeaponEquipment = newWeapon;
                newWeapon.transform.parent = _rightHandWeaponPlace;
                CheckItemTransformProperty(characterData, newWeapon);
            }
        }

        public void ChangeSpawnCharacterItems(bool isHat, HatData newHat, WeaponData newWeapon)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeItem(isHat, newHat, newWeapon));
        }

        private static void CheckItemTransformProperty(CharacterData characterData, EquipmentControl newItem)
        {
            for (int i = 0; i < newItem.ItemArrayPlaces.Length; i++)
            {
                if (newItem.ItemArrayPlaces[i]?.PlaceForCharacter == characterData.CharacterName)
                {
                    newItem.SetItemTransformProperty(newItem.ItemArrayPlaces[i].transform);
                }
            }
        }

        public void SetAnimationSpeed(float speed)
        {
            _characterAnimator.speed = speed;
        }

        public void PlayRandomAnimation()
        {
            _characterAnimator.SetLayerWeight(1, 0);
            _characterAnimator.SetInteger("AnimationSelectCount", Random.Range(0, 3));            
        }

        public void PlaySelectAnimation(string animationClipName)
        {
            _characterAnimator.SetLayerWeight(1, 1);
            _characterAnimator.SetTrigger(animationClipName);
        }

        public IEnumerator ChangeItem(bool isHat, HatData hat, WeaponData weapon)
        {
            CharacterData characterData = CharacterSelectManager.InstanceSelectManager.CurentCharacterData;

            if (isHat)
            {
                if (_oldHatEquipment != null && hat == null)
                {
                    yield return _oldHatEquipment.FadeOut();
                    Destroy(_oldHatEquipment.gameObject);
                    OldHatdata = null;
                    _oldHatEquipment = null;                    
                }

                if (hat != null && hat.HatName != OldHatdata?.HatName)
                {                    
                    if (_oldHatEquipment != null)
                    {
                        yield return _oldHatEquipment.FadeOut();
                        Destroy(_oldHatEquipment.gameObject);
                        _oldHatEquipment = null;
                        OldHatdata = null;
                    }

                    EquipmentControl newHat = Instantiate(hat.HatObject, _hatPlace);
                    OldHatdata = hat;
                    _oldHatEquipment = newHat;
                    newHat.transform.parent = _hatPlace;
                    CheckItemTransformProperty(characterData, newHat);

                    yield return newHat.FadeIn();
                }
            }
            else
            {
                if (_oldWeaponEquipment != null && weapon == null)
                {
                    yield return _oldWeaponEquipment.FadeOut();
                    Destroy(_oldWeaponEquipment.gameObject);
                    OldWeaponData = null;
                    _oldWeaponEquipment = null;
                }

                if (weapon != null &&  weapon.WeaponName != OldWeaponData?.WeaponName)
                {                    
                    if (_oldWeaponEquipment != null)
                    {
                        yield return _oldWeaponEquipment.FadeOut();
                        Destroy(_oldWeaponEquipment.gameObject);
                        OldWeaponData = null;
                        _oldWeaponEquipment = null;                        
                    }

                    EquipmentControl newWeapon = Instantiate(weapon.WeaponObject, _rightHandWeaponPlace);
                    OldWeaponData = weapon;
                    _oldWeaponEquipment = newWeapon;
                    newWeapon.transform.parent = _rightHandWeaponPlace;
                    CheckItemTransformProperty(characterData, newWeapon);

                    yield return newWeapon.FadeIn();
                }
            }
        }
    }
}