namespace Features
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DragOnDrop : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public event Action OnPointerDownEvent = delegate { };
        public event Action OnPointerUpEvent = delegate { };

        private Vector2 _horizontalFrontiers;
        private Vector2 _verticalFrontiers;

        private RectTransform _rectTransform;
        private Vector2 _localPoint;
        private Vector2 _pos;
        private bool _isMove = false;

        private void Awake()
        {
            _horizontalFrontiers.x = -Screen.width / 2f;
            _horizontalFrontiers.y = Screen.width / 2f;
            _verticalFrontiers.x = -Screen.height / 2f + 100f;
            _verticalFrontiers.y = Screen.height / 2f - 30f;

            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
            _isMove = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(_isMove)
            {
                CheckPosition();
                _isMove = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isMove)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    transform.parent.transform as RectTransform,
                    eventData.position,
                    null,
                    out _localPoint);

                _rectTransform.localPosition = _localPoint;
            }
        }

        private void CheckPosition()
        {
            if (_rectTransform.anchoredPosition.x > _horizontalFrontiers.y)
            {
                _pos.x = _horizontalFrontiers.y;
                _pos.y = _rectTransform.anchoredPosition.y;
                _rectTransform.anchoredPosition = _pos;
            }

            if (_rectTransform.anchoredPosition.x < _horizontalFrontiers.x)
            {
                _pos.x = _horizontalFrontiers.x;
                _pos.y = _rectTransform.anchoredPosition.y;
                _rectTransform.anchoredPosition = _pos;
            }

            if (_rectTransform.anchoredPosition.y > _verticalFrontiers.y)
            {
                _pos.x = _rectTransform.anchoredPosition.x;
                _pos.y = _verticalFrontiers.y;
                _rectTransform.anchoredPosition = _pos;
            }

            if (_rectTransform.anchoredPosition.y < _verticalFrontiers.x)
            {
                _pos.x = _rectTransform.anchoredPosition.x;
                _pos.y = _verticalFrontiers.x;
                _rectTransform.anchoredPosition = _pos;
            }
        }
    }
}
