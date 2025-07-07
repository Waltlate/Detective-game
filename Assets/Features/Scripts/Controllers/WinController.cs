namespace Features.Controllers
{
    using Features.ScriptableObjects;
    using Features.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class WinController : MonoBehaviour
    {
        [SerializeField] private DocumentViewController _documentViewController;
        [SerializeField] private Document _finalDocument;
        [SerializeField] private Button _buttonCircle;

        private List<Document> _documents = new List<Document>();
        private Button _button;

        private void Awake()
        {
            _button = _finalDocument.transform.GetComponent<Button>();

            foreach(var elem in transform.GetComponentsInChildren<Document>())
            {
                _documents.Add(elem);
            }
        }

        public void ActiveFinalDocument()
        {
            _documentViewController.CloseDocuments();
            _documents.ForEach(obj => obj.gameObject.SetActive(false));
            _finalDocument.gameObject.SetActive(true);
            ActiveWindow();
            _buttonCircle.interactable = false;
        }

        private void ActiveWindow()
        {
            _button.onClick.Invoke();
            _button.onClick.Invoke();
        }
    }
}
