using UnityEngine;

namespace SelectCharacterMenu
{
    public class PlaceControl : MonoBehaviour
    {
        [SerializeField]
        private CharacterNames _placeForCharacter;
        public CharacterNames PlaceForCharacter => _placeForCharacter;
    }
}
