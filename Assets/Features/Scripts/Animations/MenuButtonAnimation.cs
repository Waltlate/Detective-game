namespace Features.Animations
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class MenuButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const float _multipleScale = 1.2f;

        [SerializeField] private AudioSource _audioSource;

        private RectTransform _buttonRT;
        private Vector3 _startScale;

        private void Awake()
        {
            _buttonRT = GetComponent<RectTransform>();
            _startScale = _buttonRT.localScale;
        }

        private void OnEnable()
        {
            _buttonRT.localScale = _startScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _buttonRT.localScale = _startScale * _multipleScale;
            _audioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _buttonRT.localScale = _startScale;
        }
    }
}
