namespace Features.Buttons
{
    using Features.ScriptableObjects;
    using Features.Core;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using UnityEngine.UI;

    public class EntryButton : AbstractButton
    {
        public event Action<EntryButton> OnClick = delegate { };

        private const float _multipleSize = 1.1f;

        [SerializeField] private EntryEventModel _entryEventModel;
        [SerializeField] private EntryModel _entryModel;
        [SerializeField] private Transform _currentWindow;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private Sprite _unselectedSprite;
        [SerializeField] private bool _isActive;

        private RectTransform _rectTransform;
        private Vector2 _startSize;
        private Vector2 _expandSize;

        protected override void Awake()
        {
            base.Awake();

            _rectTransform = GetComponent<RectTransform>();
            _startSize = _rectTransform.sizeDelta;
            _expandSize = _startSize;
            _expandSize.x *= _multipleSize;

            if (_isActive)
            {
                ExpandButton();
            }
        }

        protected override void OnButtonClicked()
        {
            _entryEventModel.ChangeView(_entryModel);
            ExpandButton();
            _currentWindow.SetAsLastSibling();
            OnClick?.Invoke(this);
        }

        public void ExpandButton()
        {
            _rectTransform.sizeDelta = _expandSize;
            _image.sprite = _selectedSprite;
        }

        public void CompressButton()
        {
            _rectTransform.sizeDelta = _startSize;
            _image.sprite = _unselectedSprite;
        }
    }
}
