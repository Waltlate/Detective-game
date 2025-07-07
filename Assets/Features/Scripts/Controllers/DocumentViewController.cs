namespace Features.Controllers
{
    using Features.ScriptableObjects;
    using Features.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class DocumentViewController : MonoBehaviour
    {
        private const int _size = 15;

        [SerializeField] private Transform _windowsTransform;
        [SerializeField] private DocumentEventModel _documentEventModel;
        [SerializeField] private EntryDocument _entryDocumentPrefab;
        [SerializeField] private WindowDocument _windowDocumentPrefab;

        private readonly Vector2 _startPos = new Vector2(-500, 400);

        private Dictionary<string, EntryDocument> _documentsDictionary = new Dictionary<string, EntryDocument>();
        private List<EntryDocument> _activeDocuments = new List<EntryDocument>();
        private EntryDocument _entryDocument;
        private WindowDocument _windowDocument;
        private Vector2 _posWindow;
        private int _activeDocumentCount;

        public int ActiveDocumentCount
        {
            get { return _activeDocumentCount; }
            set { _activeDocumentCount = value; }
        }

        private void Awake()
        {
            _documentEventModel.OnAddDocument += AddEntry;
        }

        private void OnDestroy()
        {
            _documentEventModel.OnAddDocument -= AddEntry;
        }

        public void CollapseDocuments()
        {
            foreach(var document in _activeDocuments)
            {
                document.WindowDocument.Collapse();
            }
        }

        public void CloseDocuments()
        {
            foreach (var document in _activeDocuments)
            {
                document.WindowDocument.Close();
            }
        }

        private void AddEntry(Document document)
        {
            if (!_documentsDictionary.ContainsKey(document.Title))
            {
                CreateNewEntry(document);
            }
            else
            {
                _entryDocument = _documentsDictionary[document.Title];

                if (_entryDocument.gameObject.activeSelf)
                {
                    _entryDocument.WindowDocument.transform.SetAsLastSibling();
                    _entryDocument.WindowDocument.Open();
                }
                else
                {
                    _entryDocument.gameObject.SetActive(true);
                    _entryDocument.WindowDocument.gameObject.SetActive(true);
                    _entryDocument.transform.SetAsLastSibling();
                    _entryDocument.WindowDocument.transform.SetAsLastSibling();
                    _entryDocument.WindowDocument.Open();
                    SetWindowPosition(_entryDocument.WindowDocument);
                }
            }

            _activeDocumentCount++;
            _activeDocuments.Add(_entryDocument);
        }

        private void CreateNewEntry(Document document)
        {
            _entryDocument = Instantiate(_entryDocumentPrefab, transform.position, Quaternion.identity);
            _entryDocument.transform.SetParent(transform);
            _entryDocument.Init(document);

            _windowDocument = Instantiate(_windowDocumentPrefab, transform.position, Quaternion.identity);
            _windowDocument.transform.SetParent(_windowsTransform);
            _windowDocument.Init(document);

            _windowDocument.EntryDocument = _entryDocument;
            _entryDocument.WindowDocument = _windowDocument;
            _entryDocument.DocumentViewController = this;

            SetWindowPosition(_windowDocument);

            _documentsDictionary.Add(document.Title, _entryDocument);
        }

        private void SetWindowPosition(WindowDocument windowDocument)
        {
            _posWindow.x = _activeDocumentCount * _size;
            _posWindow.y = -_activeDocumentCount * _size;
            windowDocument.MainRect.anchoredPosition = _startPos + _posWindow;
        }
    }
}
