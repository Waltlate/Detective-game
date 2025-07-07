namespace Features.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class WindowDocument : MonoBehaviour
    {
        [SerializeField] private ManageGameObject _mainImageGO;
        [SerializeField] private ManageGameObject _mainTextGO;
        [SerializeField] private Sprite _imageSprite;
        [SerializeField] private Sprite _docSprite;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _mainImage;
        [SerializeField] private Text _titleText;
        [SerializeField] private TextMeshProUGUI _mainText;

        private EntryDocument _entryDocument;
        private RectTransform _rectTransform;
        private bool _isActive;

        public EntryDocument EntryDocument
        {
            get { return _entryDocument; }
            set { _entryDocument = value; }
        }

        public RectTransform MainRect => _rectTransform;
        public bool IsActive => _isActive;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Init(Document document)
        {
            _titleText.text = document.Title;

            if(document.DocType == DocumentEnum.DocType.Image)
            {
                InitImage(document);
            }
            else
            {
                InitText(document);
            }
        }

        public void Collapse()
        {
            transform.localScale = Vector3.zero;
            _isActive = false;
            _entryDocument.ChangeBack();
        }

        public void Open()
        {
            transform.localScale = Vector3.one;
            _isActive = true;
            _entryDocument.ChangeBack();
        }

        public void Close()
        {
            EntryDocument.DocumentViewController.ActiveDocumentCount--;
            EntryDocument.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void InitImage(Document document)
        {
            _mainImageGO.Active();
            _icon.sprite = _imageSprite;
            _mainImage.sprite = document.ImageDocument.MainSprite;
        }

        private void InitText(Document document)
        {
            _mainTextGO.Active();
            _icon.sprite = _docSprite;
            _mainText.text = document.TextDocument.MainText;
        }
    }
}
