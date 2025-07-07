namespace Features.UI
{
    using Features.Controllers;
    using Features.Core;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class EntryDocument : AbstractButton
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _back;
        [SerializeField] private Sprite _imageSprite;
        [SerializeField] private Sprite _docSprite;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private Sprite _unselectedSprite;
        [SerializeField] private Text _titleText;

        private WindowDocument _windowDocument;
        private DocumentViewController _documentViewController;

        protected override void OnButtonClicked()
        {
            if (!_windowDocument.IsActive)
            {
                _windowDocument.Open();
            }
            _windowDocument.transform.SetAsLastSibling();
        }

        public WindowDocument WindowDocument
        {
            get { return _windowDocument; }
            set { _windowDocument = value; }
        }

        public DocumentViewController DocumentViewController
        {
            get { return _documentViewController; }
            set { _documentViewController = value; }
        }

        public void Init(Document document)
        {
            _titleText.text = document.Title.ToString();

            if(document.DocType == DocumentEnum.DocType.Image)
            {
                _icon.sprite = _imageSprite;
            }
            else
            {
                _icon.sprite = _docSprite;
            }
        }

        public void ChangeBack()
        {
            if (_windowDocument.IsActive)
            {
                _back.sprite = _selectedSprite;
            }
            else
            {
                _back.sprite = _unselectedSprite;
            }
        }
    }
}
