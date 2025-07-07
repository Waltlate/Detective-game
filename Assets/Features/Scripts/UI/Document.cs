namespace Features.UI
{
    using Features.Core;
    using Features.ScriptableObjects;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Document : AbstractButton
    {
        public event Action OnInit = delegate { };

        [SerializeField] private TextsModel _textsModel;
        [SerializeField] private DocumentEventModel _docEvent;
        [SerializeField] private DocumentEnum.DocType _docType;
        [SerializeField] private Text _titleText;
        [SerializeField] private string _title;

        private TextDocument _textDocument;
        private ImageDocument _imageDocument;
        private float _maxDoubleClickTime = 0.3f;
        private float _lastClickTime = 0f;
        private int _clickCount = 0;
        private bool _isInit;

        public TextDocument TextDocument => _textDocument;
        public ImageDocument ImageDocument => _imageDocument;
        public DocumentEnum.DocType DocType => _docType;
        public string Title => _title;
        public bool IsInit => _isInit;

        protected override void Awake()
        {
            base.Awake();
            _titleText.text = _title;
            if (_docType == DocumentEnum.DocType.Image)
            {
                _imageDocument = GetComponent<ImageDocument>();
            }
            else
            {
                _textDocument = GetComponent<TextDocument>();

                if (_textsModel.TextDictionary.ContainsKey(_title))
                {
                    _textDocument.MainText = _textsModel.TextDictionary[_title];
                }
                else
                {
                    Debug.Log(_textsModel.TextDictionary.Count);
                    Debug.Log(_textsModel._count);
                    Debug.Log("not fount " + _title);
                }
            }

            _isInit = true;
            OnInit?.Invoke();
        }

        protected override void OnButtonClicked()
        {
            _clickCount++;

            if (_clickCount == 1)
            {
                _lastClickTime = Time.time;
            }
            else if (_clickCount == 2)
            {
                if (Time.time - _lastClickTime <= _maxDoubleClickTime)
                {
                    OnDoubleClick();
                    _clickCount = 0;
                }
                else
                {
                    _lastClickTime = Time.time;
                    _clickCount = 1;
                }
            }

            if (_clickCount == 1 && Time.time - _lastClickTime > _maxDoubleClickTime)
            {
                _clickCount = 0;
            }
        }

        private void OnDoubleClick()
        {
            _docEvent.AddDocument(this);
        }
    }
}
