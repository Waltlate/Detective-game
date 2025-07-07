namespace Features.Animations
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MoveAnimation : MonoBehaviour
    {
        [SerializeField] private float _speed = 20.0f;
        [SerializeField] private float _height = 10.0f;

        private RectTransform _rectTransform;
        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private Vector3 _buf;
        private float _journeyLength;
        private float _startTime;
        private float _distCovered;
        private float _fractionOfJourney;
        private bool _isActive = true;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition; 
            _targetPosition = _startPosition + new Vector3(0, _height, 0);
            _journeyLength = Vector3.Distance(_startPosition, _targetPosition);
            _startTime = Time.time;
        }

        private void Update()
        {
            if (_isActive)
            {
                _distCovered = (Time.time - _startTime) * _speed;
                _fractionOfJourney = _distCovered / _journeyLength;

                _rectTransform.anchoredPosition = Vector3.Lerp(_startPosition, _targetPosition, Mathf.PingPong(_fractionOfJourney, 1));

                if (_fractionOfJourney >= 1)
                {
                    _buf = _startPosition;
                    _startPosition = _targetPosition;
                    _targetPosition = _buf;

                    _startTime = Time.time;
                }
            }
        }

        private void OnDisable()
        {
            _isActive = false;
        }
    }
}
