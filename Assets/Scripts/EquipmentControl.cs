using System.Collections;
using UnityEngine;

namespace SelectCharacterMenu
{
    public class EquipmentControl : MonoBehaviour
    {
        [SerializeField]
        private Transform _itemTransform;

        private MeshRenderer _meshRenderer;

        [SerializeField]
        private PlaceControl[] _itemArrayPlaces;
        public PlaceControl[] ItemArrayPlaces => _itemArrayPlaces;

        [SerializeField]
        private Material _normalMaterial, _alphaMaterial;    

        private void Awake()
        {
            _meshRenderer = _itemTransform.GetComponent<MeshRenderer>();
        }

        public void SetItemTransformProperty(Transform transform)
        {
            _itemTransform.position = transform.position;
            _itemTransform.rotation = transform.rotation;
            _itemTransform.localScale = transform.localScale;
        }

        public IEnumerator FadeIn()
        {

            _meshRenderer.material = _alphaMaterial;
            Color alphaColore = _meshRenderer.material.color;
            alphaColore.a = 0;
            _meshRenderer.material.color = alphaColore;

            for (float i = 0f; i <= 1; i += 0.1f)
            {
                Color newColore = _meshRenderer.material.color;
                newColore.a = i;
                _meshRenderer.material.color = newColore;

                yield return new WaitForSeconds(.01f);
            }

            _meshRenderer.material = _normalMaterial;
            alphaColore.a = 1;
            _meshRenderer.material.color = alphaColore;

        }

        public IEnumerator FadeOut()
        {
            _meshRenderer.material = _alphaMaterial;
            Color alphaColore = _meshRenderer.material.color;
            alphaColore.a = 1;
            _meshRenderer.material.color = alphaColore;

            for (float i = 1f; i >= 0; i -= 0.1f)
            {
                Color newColore = _meshRenderer.material.color;
                newColore.a = i;
                _meshRenderer.material.color = newColore;

                yield return new WaitForSeconds(.01f);
            }

            _meshRenderer.material = _normalMaterial;
            alphaColore.a = 0;
            _meshRenderer.material.color = alphaColore;

        }
    }
}
