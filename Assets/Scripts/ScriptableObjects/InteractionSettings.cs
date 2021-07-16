using UnityEngine;

namespace SelectCharacterMenu
{
    [CreateAssetMenu(fileName = "New_InteractionSettings", menuName = "ScriptableObjects/InteractionSettings", order = 51)]
    public class InteractionSettings : ScriptableObject
    {
        [SerializeField]
        [Range(0.01f, 100f)]        
        private float _rotationSpeed;
        public float RotationSpeed => _rotationSpeed;

        [SerializeField]
        [Range(0.01f, 10f)]
        private float _rotationInertion;
        public float RotationInertion => _rotationInertion;
    }
}
