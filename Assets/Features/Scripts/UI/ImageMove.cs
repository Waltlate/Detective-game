namespace Features.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class ImageMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        [SerializeField] private RectTransform _imageRT;
        [SerializeField] private Vector2 _moveVector;
        [SerializeField] private Vector2 _horizontalBorder = new Vector2(0, 0);
        [SerializeField] private Vector2 _verticalBorder = new Vector2(0, 0);

        private Coroutine _moveCoroutine;
        private Vector2 _newPosition;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_moveCoroutine == null)
            {
                _moveCoroutine = StartCoroutine(MoveImage());
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }
        }

        private IEnumerator MoveImage()
        {
            while (isActiveAndEnabled)
            {
                _newPosition = _imageRT.anchoredPosition + _moveVector;

                if (_newPosition.x < _horizontalBorder.x)
                {
                    _newPosition.x = _horizontalBorder.x;
                }
                else if (_newPosition.x > _horizontalBorder.y)
                {
                    _newPosition.x = _horizontalBorder.y;
                }

                if (_newPosition.y < _verticalBorder.x)
                {
                    _newPosition.y = _verticalBorder.x;
                }
                else if (_newPosition.y > _verticalBorder.y)
                {
                    _newPosition.y = _verticalBorder.y;
                }

                _imageRT.anchoredPosition = _newPosition;

                yield return null;
            }
        }
    }
}
