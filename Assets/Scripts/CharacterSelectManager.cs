using UnityEngine;
using System.Collections.Generic;

namespace SelectCharacterMenu
{   
    public class CharacterSelectManager : MonoBehaviour
    {

        private static CharacterSelectManager _instanceSelectManager;

        public CharacterData CurentCharacterData { get; set; }

        [SerializeField]
        private CharacterData[] _characters;
        public CharacterData[] Characters => _characters;

        public static CharacterSelectManager InstanceSelectManager
        {
            get
            {
                if (_instanceSelectManager == null)
                {
                    GameObject instance = new GameObject("Character Select Manager");
                    instance.AddComponent<CharacterSelectManager>();
                }

                return _instanceSelectManager;
            }
        }

        private void Awake()
        {
            if (_instanceSelectManager != null && _instanceSelectManager != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                _instanceSelectManager = this;
            }
            DontDestroyOnLoad(gameObject);
        }

    }
}
